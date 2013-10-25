using System;
using System.Collections.Concurrent;
using System.ComponentModel;

namespace SettingsCache
{
    public class AppSettings : IAppSettings
    {
        private readonly ISettingRepository settingRepository;
        private readonly ConcurrentDictionary<string, object> cachedValues = new ConcurrentDictionary<string, object>();


        public AppSettings(ISettingRepository settingRepository)
        {
            this.settingRepository = settingRepository;
        }

        public string GetSetting(string key)
        {
            return GetSetting<string>(key);
        }

        public T GetSetting<T>(string key)
        {
            object value;
            if (!cachedValues.TryGetValue(key, out value))
            {
                value = GetValueFromRepository(key, typeof(T));
                cachedValues.TryAdd(key, value);
            }

            return (T)value;
        }

        private object GetValueFromRepository(string key, Type type)
        {
            var stringValue = settingRepository.GetSetting(key);
            if (stringValue == null)
            {
                throw new MissingSettingException(string.Format("A setting with the key '{0}' does not exist.", key));
            }

            if (type == typeof(string))
            {
                return stringValue;
            }

            return ConvertValue(stringValue, type);
        }

        private static object ConvertValue(string stringValue, Type type)
        {
            return TypeDescriptor.GetConverter(type).ConvertFromString(stringValue);
        }
    }
}