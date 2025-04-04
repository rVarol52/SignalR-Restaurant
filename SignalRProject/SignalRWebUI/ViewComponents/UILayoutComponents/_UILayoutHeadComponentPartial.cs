using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.ViewComponents.UILayouComponents
{
    public class _UILayoutHeadComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
