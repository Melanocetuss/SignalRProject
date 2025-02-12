using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.Controllers
{
    public class MenuController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.SubPage = "sub_page";
            ViewBag.NavbarDiv = "</div>";
            return View();
        }
    }
}
