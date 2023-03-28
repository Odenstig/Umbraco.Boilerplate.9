using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.Dashboards;
using Umbraco.Cms.Core.DependencyInjection;

namespace Boilerplate.Core.Settings.Composers
{
    public class DashboardComposer : IComposer
    {
        public void Compose(IUmbracoBuilder builder)
        {
            builder.Dashboards().Remove<RedirectUrlDashboard>();
        }
    }
}
