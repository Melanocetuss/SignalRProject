using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.ViewComponents.SignalRComponents
{
    public class _MenuTableCSSComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
