using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Cors;

using Microsoft.Owin;
using Microsoft.Owin.Cors;

using Owin;

[assembly: OwinStartup(typeof(CorsApi.Startup))]

namespace CorsApi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ////app.UseCors(new CorsOptions()
            ////{
            ////    PolicyProvider = new CorsPolicyProvider()
            ////    {
            ////        PolicyResolver = request =>
            ////        {
            ////            if (request.Path.StartsWithSegments(new PathString("/token")))
            ////            {
            ////                return Task.FromResult(new CorsPolicy { AllowAnyOrigin = true });
            ////            }
            ////            return Task.FromResult<CorsPolicy>(null);
            ////        }
            ////    }
            ////});

            this.ConfigureAuth(app);
        }
    }
}
