using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SocialTest.Startup))]
namespace SocialTest
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
          
        }
    }
}