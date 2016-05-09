using IMS.Common;
using IMS.DataModel.ViewModels;
using Serializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IMS.UI.Controllers
{
    public class CustomerController : Controller
    {
        readonly JsonNetSerialization serializer = new JsonNetSerialization();
        readonly HttpHelpers httpHelpers = new HttpHelpers();

        // GET: Customer
        [HttpGet]
        public ActionResult Index()
        {
            List<CustomerViewModels> custModel = new List<CustomerViewModels>();
            return PartialView(custModel);
        }

        public ActionResult Create()
        {
            return PartialView();
        }


        public ActionResult tablist()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CustomerViewModels model)
        {
            var result = httpHelpers.GetHttpResponseMessage(HttpMethods.POST, string.Format("{0}{1}", IMSConst.API_SERVICE_BASE_ADRS, IMSConst.CUST_CREATE_ENDPOINT),
               serializer.Serialize<CustomerViewModels>(model));

            if (result.IsSuccessStatusCode)
            {
                return View();
            }

            ModelState.AddModelError("CustomerCreate", result.ReasonPhrase);
            return View(model);
        }

    }
}