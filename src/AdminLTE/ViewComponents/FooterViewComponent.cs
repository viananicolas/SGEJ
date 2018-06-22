using Microsoft.AspNetCore.Mvc;

namespace SGEJ.ViewComponents
{
    public class FooterViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(string filter)
        {
            return View();
        }
    }
}
