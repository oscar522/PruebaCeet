using AspNetIdentity.WebClientAdmin.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;

namespace AspNetIdentity.WebClientAdmin.Controllers
{
    public class LayoutController : BaseController
    {
        [Authorize]
        public ActionResult Sidebar()
        {
            string role = GetTokenObject().role;

            GeneralConfigurations generalConfigurations = GetConfig();
            SidebarUserLevel sidebarUserLevel = generalConfigurations.menus.Where(w => w.role.Equals(role, System.StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
            List<SidebarItem> SidebarItemList = sidebarUserLevel.links;
            
            return PartialView(SidebarItemList);
        }

        [Authorize]
        public ActionResult Navbar()
        {
            ViewBag.FullName = GetTokenObject().FullName;
            ViewBag.IdU = GetTokenObject().FullName;

            return PartialView();
        }
    }
}