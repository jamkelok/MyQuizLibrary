using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyQuizGameWebApp.Startup))]
namespace MyQuizGameWebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
