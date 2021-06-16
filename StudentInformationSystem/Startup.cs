using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(StudentInformationSystem.Startup))]
namespace StudentInformationSystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
