using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.ViewComponents.SignalRComponents
{
    public class _SignalRScriptNotificationComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}