using System.Collections.Generic;

namespace AspNetIdentity.WebClientAdmin.Models
{
    public class GeneralConfigurations
    {
        public List<SidebarUserLevel> menus { get; set; }
    }

    public class SidebarUserLevel
    {
        public string role { get; set; }
        public List<SidebarItem> links { get; set; }
    }

    public class SidebarItem
    {
        public int order { get; set; }
        public string controllerName { get; set; }
        public string actionName { get; set; }
        public string linkText { get; set; }
        public string iconText { get; set; }
        public List<SidebarItem> Sub { get; set; }
        public string id { get; set; }


    }
}