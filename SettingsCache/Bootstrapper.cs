using System.Data;
using Nancy.TinyIoc;

namespace SettingsCache
{
    using Nancy;

    public class Bootstrapper : DefaultNancyBootstrapper
    {
       
        protected override void ConfigureRequestContainer(TinyIoCContainer container, NancyContext context)
        {
            base.ConfigureRequestContainer(container, context);

            var factory =container.Resolve<IDbConnectionFactory>();
            container.Register<IDbConnection>(factory.GetOpenConnection());
            
            container.Register<IRepo, MyRepo>();

        }
    }
}