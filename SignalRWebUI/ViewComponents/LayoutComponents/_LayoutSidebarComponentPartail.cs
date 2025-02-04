using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.ViewComponents.LayoutComponents
{
    public class _LayoutSidebarComponentPartail : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}