using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SGEJ.Models.Common;
using SGEJ.Models.Models;

namespace SGEJ.ViewComponents
{
    public class SidebarViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(string filter)
        {
            var sidebars = new List<SidebarMenu>
            {
                ModuleHelper.AddHeader("NAVEGAÇÃO"),
                ModuleHelper.AddModule(ModuleHelper.Module.Jogos, Tuple.Create(0, 0, 0)),
                ModuleHelper.AddModule(ModuleHelper.Module.Amigos, Tuple.Create(0, 0, 0)),
                ModuleHelper.AddModule(ModuleHelper.Module.Emprestimos, Tuple.Create(0, 0, 0))
            };
            return View(sidebars);
        }
    }
}
