using System;

namespace SettingsCache
{
    public interface IAppSettings
    {
        string GetSetting(string key);

        T GetSetting<T>(string key);
    }

    public class MissingSettingException : Exception
    {
        public MissingSettingException(string message) : base(message) { }
    }
}
