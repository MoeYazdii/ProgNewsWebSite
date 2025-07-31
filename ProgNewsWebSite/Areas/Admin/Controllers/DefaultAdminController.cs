using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProgNewsWebSite.Areas.Admin.Controllers
{
    [RouteArea("Admin")]
    public class DefaultAdminController : Controller
    {
        // GET: Admin/DefaultAdmin
        [Route("")]           // This handles /Admin
        public ActionResult Index()
        {
            return View();
        }
    }
}