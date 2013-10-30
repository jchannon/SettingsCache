namespace SettingsCache
{
    using Nancy;

    public class IndexModule : NancyModule
    {
        private readonly IRepo repo;

        public IndexModule(IRepo repo, IAppSettings appSettings)
        {
            this.repo = repo;

            Get["/"] = parameters =>
            {
                //The first request to the app will initiate MyRepo.cs and get an appSetting defined in its ctor
                return View["index"];
            };

            Get["/anotherrequest"] = parameters =>
                {
                    //This should open then close a dbconnection from the singleton dbconnectionfactory, subsequent requests will get the value from dictionary cache
                    int fsd = appSettings.GetSetting<int>("DaysUntilExpiry");

                    return View["index"];
                };
        }
    }
}