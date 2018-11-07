using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRPushNotification.Server
{
    public class PushNotificationHub : Hub<IClientPushNotification>
    {

        public override Task OnConnectedAsync()
        {
            Clients.Caller.Connect(Context.ConnectionId);

            return base.OnConnectedAsync();
        }





        public override Task OnDisconnectedAsync(Exception exception)
        {
            return base.OnDisconnectedAsync(exception);
        }

    }


}
