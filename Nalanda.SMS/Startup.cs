using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Nalanda.SMS.Startup))]
namespace Nalanda.SMS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
