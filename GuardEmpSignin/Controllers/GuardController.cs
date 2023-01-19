using GuardEmpSignin.Models;
using GuardEmpSignin.Services.Guard;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace GuardEmpSignin.Controllers
{
    public class GuardController : Controller
    {
        private readonly IGService _service;
        public GuardController(IGService service)
        {
            _service = service;
        }
        
        
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult Queue()
        {
            ViewBag.status = TempData["status"];
            var model = _service.BadgeQueue().ToList();
            
            return View(model);
        }       
        [HttpPost]
        
        public ActionResult Queue(int UId, string badge, DateTime assignTime)
        {
            var status = _service.AssignBadge(UId, badge, assignTime);
            TempData["status"] = status;
            return RedirectToAction("Queue");
        }
        
        public ActionResult BadgeOut()
        {
            var model = _service.s_OutList().ToList();
            
            return View(model);
        }
       
        public ActionResult BadgeReport()
        {
            return View();
        }
        [HttpPost]
        public ActionResult BadgeReport(DateTime sDate, DateTime eDate,
        string? fName, string? lName)
        {
                var model = _service.GetReport(sDate, eDate, fName, lName); 
            return View(model);
        }
    }
}