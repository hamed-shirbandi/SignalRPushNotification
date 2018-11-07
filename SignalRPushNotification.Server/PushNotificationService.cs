using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SignalRPushNotification.Server
{

    /// <summary>
    /// 
    /// </summary>
    public class PushNotificationService : IPushNotificationService
    {
        #region Fields

        private readonly IHubContext<PushNotificationHub, IClientPushNotification> _pushNotificationHubContext;

        #endregion

        #region Ctor


       
        public PushNotificationService(IHubContext<PushNotificationHub, IClientPushNotification> pushNotificationHubContext,IOptions<PushNotificationOptions> options)
        {
            _pushNotificationHubContext = pushNotificationHubContext;

        }

        #endregion

        #region Public Methods




        /// <summary>
        /// 
        /// </summary>
        public async Task SendAsync(PushNotificationModel notification)
        {
          //sent to one or more connectionId
            if (!string.IsNullOrEmpty(notification.ReciversConnectionIds))
            {
                var connectionIds = notification.ReciversConnectionIds.Split(',');
               
                await _pushNotificationHubContext.Clients.Clients(connectionIds).Recive(notification);
                return;
            }


            // send to all clients except caller
            if (!string.IsNullOrEmpty(notification.CallerConnectionId))
            {
                await _pushNotificationHubContext.Clients.AllExcept(notification.CallerConnectionId).Recive(notification);
                return;
            }

            

        }



        #endregion

        #region Private Methods



        #endregion


    }

 
}
