using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SGEJ.Models.Models;

namespace SGEJ.ViewComponents
{
    public class BreadcrumbViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(string filter)
        {
            if (ViewBag.Breadcrumb == null)
            {
                ViewBag.Breadcrumb = new List<Message>();
            }
            
            return View(ViewBag.Breadcrumb as List<Message>);
        }
    }
}
