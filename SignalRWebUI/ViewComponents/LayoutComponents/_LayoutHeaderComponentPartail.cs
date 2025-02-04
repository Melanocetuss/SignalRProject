using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.ViewComponents.LayoutComponents
{
    public class _LayoutHeaderComponentPartail : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
