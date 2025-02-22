using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.ViewComponents.SignalRComponents
{
    public class _SignalRScriptClientUserCountComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}