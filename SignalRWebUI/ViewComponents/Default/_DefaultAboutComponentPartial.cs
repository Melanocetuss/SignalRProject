using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.ViewComponents.Default
{
    public class _DefaultAboutComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
