using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.ViewComponents.SignalRComponents
{
    public class _SignalRScriptsComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
