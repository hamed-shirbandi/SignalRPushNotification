using System.Threading.Tasks;

namespace SignalRPushNotification.Server
{
    public interface IClientPushNotification
    {
        Task Recive(PushNotificationModel notification );
        Task Connect( string connectionId );
    }
}
