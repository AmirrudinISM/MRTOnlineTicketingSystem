using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MRTOnlineTicketingSystem.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MRTOnlineTicketingSystem.Controllers {
    public class HomeController : Controller {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger) {
            _logger = logger;
        }

        public IActionResult Index() {
            return View();
        }

        [HttpGet]
        public IActionResult UserHome()
        {
            MRTTicket mrt = new MRTTicket();
            mrt.CurrentLocationIndex = -1;
            mrt.DestinationLocationIndex = -1;
            mrt.TicketIndex = -1;

            return View(mrt);
          
        }

        [HttpPost]

        public IActionResult UserHome(MRTTicket mrt)
        {

            if (ModelState.IsValid)
            {
                Console.WriteLine(mrt.CheckRate);

                ViewBag.Rate = mrt.CheckRate;
                return View(mrt);

            }
            else
            {

                ViewBag.ErrorMsg = "Please Choose your station";
                return View(mrt);
            }

              

       

        }
        public IActionResult Privacy() {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Book()
        {
            return View("/User/TicketForm");
        }
    }
}
