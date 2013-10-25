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
                //The first request to the app will initiate MyRepo.cs and get an appSetting in the ctor
                return View["index"];
            };

            Get["/anotherrequest"] = parameters =>
                {
                    //This should open then close singleton regsisterd db connection, subsequent requests will get the value from dictionary cache
                    int fsd = appSettings.GetSetting<int>("DaysUntilExpiry");

                    //This should use a connection that is opened on request and be left open
                    var state = repo.GetDbState();
                    return View["index"];
                };
        }
    }
}