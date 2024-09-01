using System.Reflection.Metadata;
using System.Reflection;
using System.Text;

using Ats.Api.Configurations;
using Ats.Core.Abstraction;
using Ats.Core.Api;
using Ats.Core.ApiConfig;
using Ats.Core.Authentication;
using Ats.Core.Config;
using Ats.Datalayer.Implementation;
using Ats.Datalayer.Interface;

using Microsoft.AspNetCore.Authentication.JwtBearer;

using Microsoft.IdentityModel.Tokens;

using Microsoft.OpenApi.Models;
using Ats.Core.Config.Authentication;
using Ats.Shared.Constants;
using Microsoft.EntityFrameworkCore.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Setup environment variables initially
// builder.Configuration.AddUserSecrets<Program>();

// Setup configuration
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

var secretsConfig = builder.Configuration.GetSection("MicroServiceConfig")
    .Get<MicroServiceConfig>(c => c.BindNonPublicProperties = true);
if (secretsConfig == null)
{
    throw new Exception("MicroServiceConfig is not configured correctly");
}

builder.Services.AddSingleton<IMicroServiceConfig, MicroServiceConfig>(service => secretsConfig);
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddCoreLogging();
builder.Services.AddCoreControllers();
//builder.Services.AddControllers();
//builder.Services.AddCoreCompression();
builder.Services.AddCoreEntityServices<IEntityService>("Ats.Domain");
builder.Services.AddAtsDatabase(secretsConfig);
builder.Services.AddScoped<IJobCandidateRepository, JobCandidateRepository>();
builder.Services.AddScoped<IJobRoleRepository, JobRoleRepository>();
builder.Services.AddScoped<IJobCandidateAttachmentRepository, JobCandidateAttachmentRepository>();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc(GlobalConstants.DocumentVersion, new OpenApiInfo
    {
        Version = GlobalConstants.DocumentVersion,
        Title = GlobalConstants.DocumentTitle,
        Description = GlobalConstants.DocumentDescription
    });

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    if (File.Exists(xmlPath))
    {
        options.IncludeXmlComments(xmlPath);
    }
});

// Authentication Setup
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<IUserContext, UserContext>();
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        RequireSignedTokens = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretsConfig.JwtConfig!.Key)),

        ValidateLifetime = true,
        RequireExpirationTime = true,

        ValidateIssuer = true,
        ValidIssuer = secretsConfig.JwtConfig.Issuer,

        ValidateAudience = true,
        ValidAudience = secretsConfig.JwtConfig.Audience,
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(policy => policy
.WithOrigins("http://localhost:4200")
/*If you have other environments(like staging or production), make sure to include their origins as well:*/
/*.WithOrigins("http:// localhost:4200", "https:// your-staging-domain.com", "https:// your-production-domain.com")*/
.AllowAnyHeader()
.AllowAnyMethod()
/*.AllowAnyOrigin()*/
.AllowCredentials()); // Allow credentials (cookies, etc.)

app.UseAtsDatabase();
app.UseRouting();


// for authentication
app.UseMiddleware<HttpOnlyMiddleware>(secretsConfig.JwtConfig!.CookieName);
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
