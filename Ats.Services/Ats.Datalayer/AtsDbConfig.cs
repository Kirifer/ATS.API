﻿using Ats.Core.Database.Abstraction.Interface;

namespace Ats.DataLayer
{
    public class AtsDbConfig : IDbConfig
    {
        public required string Host { get; set; }

        public uint Port { get; set; }

        public required string Database { get; set; }

        public required string User { get; set; }

        public required string Password { get; set; }

        public bool Pooling { get; set; }

        public string ConnectionString
        {
            get
            {
                return $"Server={Host};" +
                        $"Port={Port};" +
                        $"Database={Database};" +
                        $"User ID={User};" +
                        $"Password={Password};" +
                        $"Pooling={Pooling};" +
                        $"SslMode={(Host.Equals("localhost") ? "Prefer" : "Prefer")};" +
                        "CommandTimeout=0;";
            }
        }
    }
}
