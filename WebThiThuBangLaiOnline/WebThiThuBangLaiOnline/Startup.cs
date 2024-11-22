using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebThiThuBangLaiOnline.Startup))]
namespace WebThiThuBangLaiOnline
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
