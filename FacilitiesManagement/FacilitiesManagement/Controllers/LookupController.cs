using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Framework.Accounting.Interfaces;

namespace FacilitiesManagement.Controllers
{
    public class LookupController : Controller
    {
        private readonly IGeneralLedgerService _glService;
        public LookupController(IGeneralLedgerService glService)
        {
            _glService = glService;
        }

        //
        // GET: /Lookup/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetGlAccounts()
        {
            var glAccounts = _glService.GetAllGlAccounts();
            return Json(glAccounts, JsonRequestBehavior.AllowGet);
        }

    }
}