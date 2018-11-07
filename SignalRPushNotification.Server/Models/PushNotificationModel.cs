using System;
using System.Collections.Generic;

namespace SignalRPushNotification.Server
{
    public class PushNotificationModel
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string CallerConnectionId { get; set; }
        public string ReciversConnectionIds { get; set; }
    }
}