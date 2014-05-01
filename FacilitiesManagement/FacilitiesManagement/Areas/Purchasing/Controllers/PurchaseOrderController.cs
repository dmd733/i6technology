using System.Web.Mvc;

namespace FacilitiesManagement.Areas.Purchasing.Controllers
{
    public class PurchaseOrderController : Controller
    {
        //
        // GET: /PurchaseOrder/
        public ActionResult Index()
        {
            return View();
        }

        
        public ActionResult PlaceOrder()
        {
            return View();
        }
    }
}