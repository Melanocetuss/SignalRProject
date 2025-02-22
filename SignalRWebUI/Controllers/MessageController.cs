using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.Controllers
{
    public class MessageController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.SubPage = "sub_page";
            ViewBag.NavbarDiv = "</div>";
            return View();
        }

        public IActionResult ClientUserCount()
        {
            ViewBag.SubPage = "sub_page";
            ViewBag.NavbarDiv = "</div>";
            return View();
        }
    }
}
