using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.ViewComponents.Default
{
    public class _DefaultTestimonialComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
