using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.ViewComponents.Default
{
    public class _DefaultOfferComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke() 
        {
            return View();
        }
    }
}
