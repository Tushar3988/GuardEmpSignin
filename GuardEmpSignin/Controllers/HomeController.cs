using GuardEmpSignin.Models;
using GuardEmpSignin.Services.Employee;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GuardEmpSignin.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEService _Service;

        public HomeController(ILogger<HomeController> logger,IEService service)
        {
            _logger = logger;
            _Service = service;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult EmpSignIn(string? FirstName, string? LastName)
        {
            var Queue = _Service.SignIn(FirstName, LastName);
            return View("Index",Queue); 
        }

        [HttpPost]

        public IActionResult ApproveReq(int id)
        {
            var Queue = _Service.s_ApproveReq(id);
            return View("Index");
        }
        public ActionResult SignOut()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignOut(string badge)
        {
            var q = _Service.s_SignOut(badge);
            ViewBag.status = q;
            return View("Index");
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}