using Colab.API;

using Microsoft.Owin;

[assembly: OwinStartup(typeof(Startup))]

namespace Colab.API
{
    using Owin;

    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            this.ConfigureAuth(app);
        }
    }
}
