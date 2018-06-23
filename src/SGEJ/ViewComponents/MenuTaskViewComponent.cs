﻿using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SGEJ.Models.Models;

namespace SGEJ.ViewComponents
{
    public class MenuTaskViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(string filter)
        {
            var messages = GetData();
            return View(messages);
        }

        private List<Message> GetData()
        {
            var messages = new List<Message>();
            messages.Add(new Message
            {
                Id = 1,
                ShortDesc = "Design some buttons",
                URLPath = "#",
                Percentage = 20
            });

            return messages;
        }
    }
}
