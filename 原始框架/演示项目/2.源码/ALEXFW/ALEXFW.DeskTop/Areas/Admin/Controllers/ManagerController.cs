using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ALEXFW.DeskTop.Areas.Admin.Controllers
{
    [EntityAuthorize]
    public class ManagerController : Controller
    {
        // GET: Admin/Clerk
        public ActionResult Index()
        {
            return View();
        }
    }
}