using IMS.Common;
using IMS.DataModel.ViewModels;
using PagedList;
using Serializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IMS.UI.Controllers
{
    public class QuotationController : BaseController
    {
        readonly JsonNetSerialization serializer = new JsonNetSerialization();
        readonly HttpHelpers httpHelpers = new HttpHelpers();
        const int pageSize = 10;

        // GET: Quotation
        public ActionResult Index(string sOdr, int? page)
        {
            List<QuotationViewModels> obj = new List<QuotationViewModels>();
            var content = httpHelpers.GetHttpContent(string.Format("{0}/{1}", IMSConst.API_SERVICE_BASE_ADRS, IMSConst.QUOT_GET_ENDPNT));
            List<QuotationViewModels> custModel = serializer.DeSerialize<List<QuotationViewModels>>(content) as List<QuotationViewModels>;
            custModel = GetPagination(custModel, sOdr, page);
            int pSize = ViewBag.PageSize == null ? 0 : ViewBag.PageSize;
            int pNo = ViewBag.PageNo == null ? 0 : ViewBag.PageNo;

            return View(custModel.ToPagedList(pNo, pSize));
        }

        // GET: Quotation/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Quotation/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Quotation/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Quotation/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Quotation/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Quotation/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Quotation/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        #region "Private Methods"
        private List<QuotationViewModels> GetPagination(List<QuotationViewModels> cust, string sOdr, int? page)
        {
            ViewBag.CurrentSort = sOdr;

            if (cust != null && cust.Count > 0)
            {
                ViewBag.CustSort = string.IsNullOrEmpty(sOdr) ? "Cust_desc" : "";
                ViewBag.CodeSort = sOdr == "Code_desc" ? "Code_asc" : "Code_desc";
                switch (sOdr)
                {
                    case "Code_desc":
                        cust = cust.OrderByDescending(s => s.QUOTE_CODE).ToList();
                        break;
                    case "Cust_desc":
                        cust = cust.OrderByDescending(s => s.CUSTOMER).ToList();
                        break;
                    case "Cust_asc":
                        cust = cust.OrderBy(s => s.CUSTOMER).ToList();
                        break;
                    default:
                        cust = cust.OrderBy(s => s.QUOTE_CODE).ToList();
                        break;
                }
            }

            ViewBag.PageSize = pageSize;
            ViewBag.PageNo = (page ?? 1);
            return cust;
        }
        #endregion
    }
}
