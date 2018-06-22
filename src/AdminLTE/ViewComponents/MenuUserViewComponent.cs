using Microsoft.AspNetCore.Mvc;

namespace SGEJ.ViewComponents
{
    public class MenuUserViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(string filter)
        {
            return View();
        }
    }
}
