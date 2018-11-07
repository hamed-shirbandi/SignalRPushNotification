using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using System;

namespace SignalRPushNotification.Server
{

    /// <summary>
    /// 
    /// </summary>
    public static class PushNotificationExtensions
    {



        /// <summary>
        /// 
        /// </summary>
        public static IServiceCollection AddPushNotification(this IServiceCollection services, Action<PushNotificationOptions> setupAction)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            if (setupAction == null)
            {
                throw new ArgumentNullException(nameof(setupAction));
            }

            services.Configure(setupAction);
            services.TryAddSingleton<IPushNotificationService, PushNotificationService>();
            services.AddSignalR();
            return services;
        }






        /// <summary>
        /// 
        /// </summary>
        public static IApplicationBuilder UsePushNotification(this IApplicationBuilder app)
        {
            if (app == null)
            {
                throw new ArgumentNullException(nameof(app));
            }

            var options = app.ApplicationServices.GetRequiredService<IOptions<PushNotificationOptions>>();


            app.UseSignalR(routes =>
            {
                routes.MapHub<PushNotificationHub>(path: options.Value.Path);
            });


            return app;
        }


    }
}
