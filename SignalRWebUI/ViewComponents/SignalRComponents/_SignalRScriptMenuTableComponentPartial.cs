using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.ViewComponents.SignalRComponents
{
    public class _SignalRScriptMenuTableComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}