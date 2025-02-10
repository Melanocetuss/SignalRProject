using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.ViewComponents.Default
{
    public class _DefaultSliderComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}