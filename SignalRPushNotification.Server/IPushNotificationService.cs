using System.Threading.Tasks;

namespace SignalRPushNotification.Server
{
    /// <summary>
    /// 
    /// </summary>
    public interface IPushNotificationService
    {
        Task SendAsync(PushNotificationModel notification);
    }
}