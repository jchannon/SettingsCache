using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace SettingsCache
{
    /// <summary>
    /// This is registered as per request
    /// </summary>
    public class MyRepo : IRepo
    {
        private readonly IDbConnection dbConnection;
        private readonly int mysettingval;

        public MyRepo(IDbConnection dbConnection, IAppSettings appSettings)
        {
            this.dbConnection = dbConnection;

            mysettingval = appSettings.GetSetting<int>("GracePeriod");
        }

      
    }

    public interface IRepo
    {
    }
}