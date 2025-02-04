using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.ViewComponents.LayoutComponents
{
    public class _LayoutFooterComponentPartail : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
