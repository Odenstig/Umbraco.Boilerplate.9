using Umbraco.Cms.Core.Events;
using Umbraco.Cms.Core.Notifications;

namespace Boilerplate.Core.Settings.Notifications
{
    public class OnContentSavedNotification : INotificationHandler<ContentSavedNotification>
    {
        public void Handle(ContentSavedNotification notification)
        {
            // Do stuff here ...
        }
    }
}
