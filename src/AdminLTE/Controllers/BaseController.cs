using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SGEJ.Models.Interface;
using SGEJ.Models.Models;

namespace SGEJ.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
        public IUnitOfWork UnitOfWork;
        public BaseController(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public BaseController()
        {
        }
        internal void AddBreadcrumb(string displayName, string urlPath)
        {
            List<Message> messages;

            if (ViewBag.Breadcrumb == null)
            {
                messages = new List<Message>();
            }
            else
            {
                messages = ViewBag.Breadcrumb as List<Message>;
            }

            messages.Add(new Message { DisplayName = displayName, URLPath = urlPath });
            ViewBag.Breadcrumb = messages;
        }

        internal void AddPageHeader(string pageHeader = "", string pageDescription = "")
        {
            ViewBag.PageHeader = Tuple.Create(pageHeader, pageDescription);
        }

        internal enum PageAlertType
        {
            Error,
            Info,
            Warning,
            Success
        }

        internal void AddPageAlerts(PageAlertType pageAlertType, string description)
        {
            List<Message> messages;

            if (ViewBag.PageAlerts == null)
            {
                messages = new List<Message>();
            }
            else
            {
                messages = ViewBag.PageAlerts as List<Message>;
            }

            messages.Add(new Message { Type = pageAlertType.ToString().ToLower(), ShortDesc = description });
            ViewBag.PageAlerts = messages;
        }
    }
}