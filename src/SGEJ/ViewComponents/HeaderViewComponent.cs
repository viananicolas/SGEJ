using Microsoft.AspNetCore.Mvc;

namespace SGEJ.ViewComponents
{
    public class HeaderViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(string filter)
        {
            return View();
        }
    }
}
