using System;
using SGEJ.Models.Models;

namespace SGEJ.Models.Common
{
    /// <summary>
    /// This is where you customize the navigation sidebar
    /// </summary>
    public static class ModuleHelper
    {
        public enum Module
        {
            Home,
            About,
            Contact,
            Error,
            Login,
            Register,
            Jogos,
            Amigos,
            Emprestimos
        }

        public static SidebarMenu AddHeader(string name)
        {
            return new SidebarMenu
            {
                Type = SidebarMenuType.Header,
                Name = name
            };
        }

        public static SidebarMenu AddTree(string name, string iconClassName = "fa fa-link")
        {
            return new SidebarMenu
            {
                Type = SidebarMenuType.Tree,
                IsActive = false,
                Name = name,
                IconClassName = iconClassName,
                URLPath = "#"
            };
        }

        public static SidebarMenu AddModule(Module module, Tuple<int, int, int> counter = null)
        {
            if (counter == null)
                counter = Tuple.Create(0, 0, 0);

            switch (module)
            {
                case Module.Home:
                    return new SidebarMenu
                    {
                        Type = SidebarMenuType.Link,
                        Name = "Home",
                        IconClassName = "fa fa-link",
                        URLPath = "/",
                        LinkCounter = counter
                    };
                case Module.Login:
                    return new SidebarMenu
                    {
                        Type = SidebarMenuType.Link,
                        Name = "Login",
                        IconClassName = "fa fa-sign-in",
                        URLPath = "/Account/Login",
                        LinkCounter = counter
                    };
                case Module.Register:
                    return new SidebarMenu
                    {
                        Type = SidebarMenuType.Link,
                        Name = "Register",
                        IconClassName = "fa fa-user-plus",
                        URLPath = "/Account/Register",
                        LinkCounter = counter
                    };
                case Module.About:
                    return new SidebarMenu
                    {
                        Type = SidebarMenuType.Link,
                        Name = "About",
                        IconClassName = "fa fa-group",
                        URLPath = "/Home/About",
                        LinkCounter = counter
                    };
                case Module.Contact:
                    return new SidebarMenu
                    {
                        Type = SidebarMenuType.Link,
                        Name = "Contact",
                        IconClassName = "fa fa-phone",
                        URLPath = "/Home/Contact",
                        LinkCounter = counter
                    };
                case Module.Error:
                    return new SidebarMenu
                    {
                        Type = SidebarMenuType.Link,
                        Name = "Error",
                        IconClassName = "fa fa-warning",
                        URLPath = "/Home/Error",
                        LinkCounter = counter
                    };
                case Module.Jogos:
                    return new SidebarMenu
                    {
                        Type = SidebarMenuType.Link,
                        Name = "Jogos",
                        IconClassName = "fa fa-gamepad",
                        URLPath = "/Jogos/Index",
                        LinkCounter = counter
                    };
                case Module.Amigos:
                    return new SidebarMenu
                    {
                        Type = SidebarMenuType.Link,
                        Name = "Amigos",
                        IconClassName = "fa fa-users",
                        URLPath = "/Amigos/Index",
                        LinkCounter = counter
                    };
                case Module.Emprestimos:
                    return new SidebarMenu
                    {
                        Type = SidebarMenuType.Link,
                        Name = "Emprestimos",
                        IconClassName = "fa fa-share-square-o",
                        URLPath = "/Emprestimos/Index",
                        LinkCounter = counter
                    };

                default:
                    break;
            }

            return null;
        }
    }
}
