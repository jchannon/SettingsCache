using System.Data;

namespace SettingsCache
{
    public interface IDbConnectionFactory
    {
        IDbConnection GetOpenConnection();
    }
}