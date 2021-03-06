﻿using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SGEJ.Models.Models;

namespace SGEJ.ViewComponents
{
    public class MenuNotificationViewComponent : ViewComponent
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
                FontAwesomeIcon = "fa fa-users text-aqua",
                ShortDesc = "5 new members joined today",
                URLPath = "#"
            });

            return messages;
        }
    }
}
