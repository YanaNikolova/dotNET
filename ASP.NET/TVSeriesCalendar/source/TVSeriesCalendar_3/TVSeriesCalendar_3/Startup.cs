using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TVSeriesCalendar_3.Startup))]
namespace TVSeriesCalendar_3
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
