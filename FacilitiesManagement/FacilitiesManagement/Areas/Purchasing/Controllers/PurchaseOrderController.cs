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
        public ActionResult Update([DataSourceRequest] DataSourceRequest request, OrderRequest model)
        {
            var orderRequest = OrderRequests.Find(item => item.OrderRequestId == model.OrderRequestId);

            if (orderRequest != null)
            {
                orderRequest.EstimatedReleaseDate = model.EstimatedReleaseDate;
                orderRequest.BudgetYear = model.BudgetYear;
                orderRequest.ReferenceNumber = model.ReferenceNumber;
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

        private List<OrderRequest> OrderRequests
        {
            get
            {
                var orderRequest = Session["OrderRequest"] as List<OrderRequest>;
                if (orderRequest == null)
                {
                    var results = new List<OrderRequest>();

                    for (int i = 0; i < 50; i++)
                    {
                        var order = new OrderRequest
                        {
                            OrderRequestId = i + 1,
                            BudgetYear = "2015",
                            ReferenceNumber = "PO" + i,
                            EstimatedReleaseDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Month, DateTime.Now.AddHours(-1 * i).Hour, 0, 0).ToUniversalTime()
                        };

                        results.Add(order);
                    }

                    Session["OrderRequest"] = results;
                }

                return orderRequest;
            }
        }
    }
}