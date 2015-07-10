using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using FacilitiesManagement.Models;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;

namespace FacilitiesManagement.Areas.Purchasing.Controllers
{
    public class PurchaseOrderController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Load([DataSourceRequest] DataSourceRequest request)
        {
            var requests = OrderRequests.ToList();
            return Json(requests.ToDataSourceResult(request));
        }

        [HttpPost]
        public ActionResult Update([DataSourceRequest] DataSourceRequest request, EditOrderRequest model)
        {
            var orderRequest = OrderRequests.Find(item => item.OrderRequestId == model.OrderRequestId);

            if (orderRequest != null)
            {
                orderRequest.LastUpdate = model.LastUpdate;
                orderRequest.BudgetYear = model.BudgetYear;
                orderRequest.ReferenceNumber = model.ReferenceNumber;
                orderRequest.Department = model.Department;
            }
            else
            {
                ModelState.AddModelError(string.Empty,
                    String.Format("Could not find Order Request with id {0}", model.OrderRequestId));
            }

            return Json(new[] {model}.ToDataSourceResult(request, ModelState));
        }

        public ActionResult PlaceOrder()
        {
            return View();
        }

        private List<EditOrderRequest> OrderRequests
        {
            get
            {
                var orderRequest = Session["OrderRequest"] as List<EditOrderRequest>;
                if (orderRequest == null)
                {
                    orderRequest = new List<EditOrderRequest>();

                    for (int i = 0; i < 50; i++)
                    {
                        var order = new EditOrderRequest
                        {
                            OrderRequestId = i + 1,
                            BudgetYear = "2015",
                            ReferenceNumber = "PO" + i,
                            LastUpdate = DateTime.Now,
                            Department = "Department " + ((char) (i + 65)).ToString().ToUpper()
                        };

                        orderRequest.Add(order);
                    }

                    Session["OrderRequest"] = orderRequest;
                }

                return orderRequest;
            }
        }
    }
}