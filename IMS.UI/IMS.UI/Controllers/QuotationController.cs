using IMS.Common;
using IMS.DataModel.ViewModels;
using Microsoft.AspNet.Identity;
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
        Guid _uid = new Guid();

        public QuotationController()
        {
            //_uid = CookieStore.GetCookie(CacheKey.Uid.ToString()) == null ? Guid.Parse(User.Identity.GetUserId()) : Guid.Parse(CookieStore.GetCookie(CacheKey.Uid.ToString()));

        }

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

        #region "RFQ"
        // GET: RFQ
        public ActionResult RFQIndex(string sOdr, int? page)
        {
            List<RFQViewModels> obj = new List<RFQViewModels>();
            var content = httpHelpers.GetHttpContent(string.Format("{0}/{1}", IMSConst.API_SERVICE_BASE_ADRS, IMSConst.RFQ_GET_ENDPNT));
            List<RFQViewModels> custModel = serializer.DeSerialize<List<RFQViewModels>>(content) as List<RFQViewModels>;
            custModel = GetPagination(custModel, sOdr, page);
            int pSize = ViewBag.PageSize == null ? 0 : ViewBag.PageSize;
            int pNo = ViewBag.PageNo == null ? 0 : ViewBag.PageNo;

            return View(custModel.ToPagedList(pNo, pSize));
        }

        // GET: RFQ/Create
        [HttpGet]
        public ActionResult RFQCreate()
        {
            return View();
        }

        /// <summary>
        /// CREATE: RFQCreate
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult RFQCreate(RFQViewModels model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _uid = Guid.Parse(User.Identity.GetUserId());
                    //Insert Location
                    LocationViewModels locmodel = new LocationViewModels();
                    locmodel.LOC_ID = Guid.NewGuid();
                    locmodel.LOC_ADDRESS = model.LOC_ID.ToString();
                    locmodel.CREATED_BY = _uid;
                    locmodel.CREATED_ON = DateTime.Now;
                    var locresult = httpHelpers.GetHttpResponseMessage(HttpMethods.POST, string.Format("{0}{1}", IMSConst.API_SERVICE_BASE_ADRS
                        , IMSConst.LOC_NEW_ENDPNT), serializer.Serialize<LocationViewModels>(model));

                    //Insert RFQ
                    model.RFQ_ID = Guid.NewGuid();
                    model.LOC_ID = locmodel.LOC_ID;
                    model.ISACTIVE = true;
                    model.CREATED_BY = _uid;
                    model.CREATED_ON = DateTime.Now;
                    var result = httpHelpers.GetHttpResponseMessage(HttpMethods.POST, string.Format("{0}{1}", IMSConst.API_SERVICE_BASE_ADRS
                        , IMSConst.RFQ_NEW_ENDPNT), serializer.Serialize<RFQViewModels>(model));
                    
                    if (result.IsSuccessStatusCode)
                    {
                        return View(model);
                    }
                    ModelState.AddModelError("RFQCreate", result.ReasonPhrase);
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return View(model);
        }

        // GET: RFQ/Edit/5
        public ActionResult Edit(Guid? id)
        {
            var content = httpHelpers.GetHttpContent(string.Format("{0}/{1}/{2}", IMSConst.API_SERVICE_BASE_ADRS, IMSConst.RFQ_GET_BYID_ENDPNT, id));
            RFQViewModels resp = serializer.DeSerialize<RFQViewModels>(content) as RFQViewModels;
            return View(resp);
        }

        /// <summary>
        /// EDIT: RFQEdit
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult RFQEdit(RFQViewModels model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _uid = Guid.Parse(User.Identity.GetUserId());
                    model.MODIFIED_BY = _uid;
                    model.MODIFIED_ON = DateTime.Now;

                    var result = httpHelpers.GetHttpResponseMessage(HttpMethods.PUT, string.Format("{0}{1}", IMSConst.API_SERVICE_BASE_ADRS
                        , IMSConst.RFQ_UPD_ENDPNT),
                       serializer.Serialize<RFQViewModels>(model));

                    if (result.IsSuccessStatusCode)
                    {
                        return View(model);
                    }
                    ModelState.AddModelError("RFQCreate", result.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return View(model);
        }

        /// <summary>
        /// DELETE: RFQDelete
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult RFQDelete(Guid Id)
        {
            return View();
        }
        #endregion

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
                    case "Cust_desc":
                        cust = cust.OrderByDescending(s => s.CUSTOMER).ToList();
                        break;
                    case "Code_desc":
                        cust = cust.OrderByDescending(s => s.QUOTE_CODE).ToList();
                        break;
                    case "Code_asc":
                        cust = cust.OrderBy(s => s.QUOTE_CODE).ToList();
                        break;
                    default:
                        cust = cust.OrderBy(s => s.CUSTOMER).ToList();
                        break;
                }
            }

            ViewBag.PageSize = pageSize;
            ViewBag.PageNo = (page ?? 1);
            return cust;
        }

        private List<RFQViewModels> GetPagination(List<RFQViewModels> cust, string sOdr, int? page)
        {
            ViewBag.CurrentSort = sOdr;
            if (cust != null && cust.Count > 0)
            {
                ViewBag.NameSort = string.IsNullOrEmpty(sOdr) ? "Name_desc" : "";
                ViewBag.DateSort = sOdr == "Date_desc" ? "Date_asc" : "Date_desc";
                switch (sOdr)
                {
                    case "Name_desc":
                        cust = cust.OrderByDescending(s => s.RFQ_NAME).ToList();
                        break;
                    case "Date_desc":
                        cust = cust.OrderByDescending(s => s.RFQ_DATE).ToList();
                        break;
                    case "Date_asc":
                        cust = cust.OrderBy(s => s.RFQ_DATE).ToList();
                        break;
                    default:
                        cust = cust.OrderBy(s => s.RFQ_NAME).ToList();
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
