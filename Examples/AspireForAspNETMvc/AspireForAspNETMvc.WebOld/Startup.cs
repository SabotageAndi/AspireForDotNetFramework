using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AspireForAspNETMvc.WebOld.Startup))]
namespace AspireForAspNETMvc.WebOld
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
