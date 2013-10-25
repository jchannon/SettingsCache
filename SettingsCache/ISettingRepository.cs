namespace SettingsCache
{
    public interface ISettingRepository
    {
        string GetSetting(string key);
    }
}