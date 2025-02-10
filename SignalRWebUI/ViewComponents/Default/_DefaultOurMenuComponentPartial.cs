using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.ViewComponents.Default
{
    public class _DefaultOurMenuComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
