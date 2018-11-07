using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalRPushNotification.Client.Web.Models;
using SignalRPushNotification.Server;

namespace SignalRPushNotification.Client.Web.Controllers
{
    public class HomeController : Controller
    {

        private readonly IPushNotificationService _pushNotificationService;
        public HomeController(IPushNotificationService pushNotificationService)
        {
            _pushNotificationService = pushNotificationService;
        }



        public IActionResult Index()
        {
            return View(new PushNotificationModel());
        }




        [HttpPost]
        public async Task SendNotification(PushNotificationModel notification)
        {
            await _pushNotificationService.SendAsync(notification);
        }

    }
}
