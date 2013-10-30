using System.Data;
using System.Linq;
using DapperExtensions;

namespace SettingsCache
{
    /// <summary>
    /// This is registered as a Singleton
    /// </summary>
    public class SettingRepository : ISettingRepository
    {
        private readonly IDbConnectionFactory dbConnectionFactory;

        public SettingRepository(IDbConnectionFactory dbConnectionFactory)
        {
            this.dbConnectionFactory = dbConnectionFactory;
        }

        public string GetSetting(string key)
        {
            var settingValue = string.Empty;
            using (var dbConnection = dbConnectionFactory.GetOpenConnection())
            {
                var predicate = Predicates.Field<Setting>(x => x.Name, Operator.Eq, key);
                var setting = dbConnection.GetList<Setting>(predicate).FirstOrDefault();
                if (setting != null)
                {
                    settingValue = setting.Value;
                }

                dbConnection.Close();
            }
            return settingValue;
        }
    }
}