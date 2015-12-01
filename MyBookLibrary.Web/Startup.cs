using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyBookLibrary.Web.Startup))]
namespace MyBookLibrary.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
