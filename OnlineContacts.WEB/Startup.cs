using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OnlineContacts.Startup))]
namespace OnlineContacts
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.MapSignalR();
        }

    }
}
