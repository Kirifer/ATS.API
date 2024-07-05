namespace Ats.Core.Authentication
{
    public interface IRolePermission
    {
        ICollection<string> GetPermissions();
    }
}
