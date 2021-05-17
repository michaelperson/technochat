using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TechnoChat.Hubs;
using TechnoChat.Hubs.Interfaces;
using TechnoChat.Models;

namespace TechnoChat.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHubContext<ChatHub, IChatClient> _hubContext;
        private Infra.Interfaces.IGroupManager _groupManager;
        public HomeController(
            ILogger<HomeController> logger, 
            IHubContext<ChatHub, IChatClient> hubContext,
            Infra.Interfaces.IGroupManager groupManager)
        {
            _hubContext = hubContext;
            _logger = logger;
            _groupManager = groupManager;
        }

        public IActionResult Index()
        {
            
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Chat()
        {
            _groupManager.AddUserToGroup("", "", "Admin");
            _groupManager.AddUserToGroup("", "", "Guest");

            return View(_groupManager.ListOfGroup());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
