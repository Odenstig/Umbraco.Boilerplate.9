using Boilerplate.Core.Settings.Notifications;
using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.DependencyInjection;
using Umbraco.Cms.Core.Notifications;

namespace Boilerplate.Core.Settings.Composers
{
    public class NotificationsComposer : IComposer
    {
        public void Compose(IUmbracoBuilder builder)
        {
            builder.AddNotificationHandler<ContentSavedNotification, OnContentSavedNotification>();
        }
    }
}
