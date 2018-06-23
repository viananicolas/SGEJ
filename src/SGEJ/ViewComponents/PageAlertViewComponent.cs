using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SGEJ.Models.Models;

namespace SGEJ.ViewComponents
{
    public class PageAlertViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(string filter)
        {
            List<Message> messages;
            if (ViewBag.PageAlerts == null)
            {
                messages = new List<Message>();
            }
            else
            {
                messages = new List<Message>(ViewBag.PageAlerts);
            }
            return View(messages);
        }
    }
}
