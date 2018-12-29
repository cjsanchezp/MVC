using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RentaDePeliculas.Startup))]
namespace RentaDePeliculas
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
