using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BiuroPodrozyCzapeczka.Startup))]
namespace BiuroPodrozyCzapeczka
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
