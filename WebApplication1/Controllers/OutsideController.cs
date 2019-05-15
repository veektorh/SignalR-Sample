using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using WebApplication1.Hubs;

namespace WebApplication1.Controllers
{

    public class OutsideController : Controller
    {
        private readonly IHubContext<ChatHub> hubContext;

        //Inject an instance of IHubContext in a controller
        public OutsideController(IHubContext<ChatHub> hubContext)
        {
            this.hubContext = hubContext;
        }

        public async Task<IActionResult> Index()
        {
            //send message from outside the hub
            await hubContext.Clients.All.SendAsync("Notify", $"Home page loaded at: {DateTime.Now}");

            return View();
        }
    }
}