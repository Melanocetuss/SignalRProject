using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.Controllers
{
    public class DefaultAboutController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.SubPage = "sub_page";
            ViewBag.NavbarDiv = "</div>";
            return View();
        }
    }
}
