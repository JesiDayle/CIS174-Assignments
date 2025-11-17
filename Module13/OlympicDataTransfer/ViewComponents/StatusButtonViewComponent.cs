using Microsoft.AspNetCore.Mvc;

namespace OlympicDataTransfer.ViewComponents
{
    public class StatusButtonViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(string status)
        {
            return View("Default", status);
        }
    }
}
