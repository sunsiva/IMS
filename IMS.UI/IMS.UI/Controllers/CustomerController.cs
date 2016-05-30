using IMS.Common;
using IMS.DataModel.ViewModels;
using IMS.UI.Common;
using PagedList;
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
        const int pageSize = 10;

        // GET: Customer
        [HttpGet]
        public ActionResult Index(string sOdr, int? page)
        {
            var content = httpHelpers.GetHttpContent(string.Format("{0}/{1}", IMSConst.API_SERVICE_BASE_ADRS, IMSConst.CUST_GET_ENDPNT));
            List<CustomerViewModels> custModel = serializer.DeSerialize<List<CustomerViewModels>>(content) as List<CustomerViewModels>;
            custModel = GetPagination(custModel, sOdr, page);
            int pSize = ViewBag.PageSize == null ? 0 : ViewBag.PageSize;
            int pNo = ViewBag.PageNo == null ? 0 : ViewBag.PageNo;
            
            return View(custModel.ToPagedList(pNo, pSize));
        }

        public ActionResult Create()
        {
            setDropdownList();
            return View();
        }
        
        public ActionResult tablist()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CustomerViewModels model)
        {
            if (ModelState.IsValid)
            {
                var uid = HttpRuntime.Cache.Get(CacheKey.Uid.ToString()).ToString();
                model.CUST_ID = Guid.NewGuid();
                model.ISACTIVE = true;
                model.CREATED_BY = uid == null ? Guid.NewGuid() : Guid.Parse(uid);
                model.CREATED_ON = DateTime.Now;

                var result = httpHelpers.GetHttpResponseMessage(HttpMethods.POST, string.Format("{0}{1}", IMSConst.API_SERVICE_BASE_ADRS, IMSConst.CUST_NEW_ENDPNT),
                   serializer.Serialize<CustomerViewModels>(model));
            
                if (result.IsSuccessStatusCode)
                {
                    return View();
                }
                ModelState.AddModelError("CustomerCreate", result.ReasonPhrase);
            }

            ModelState.AddModelError("FILD", "Failed to insert customer data.");
            return View(model);
        }

        #region private methods
        private List<CustomerViewModels> GetPagination(List<CustomerViewModels> cust, string sOdr, int? page)
        {
            ViewBag.CurrentSort = sOdr;

            if (cust != null && cust.Count > 0)
            {
                ViewBag.NameSort = string.IsNullOrEmpty(sOdr) ? "Name_desc" : "";
                ViewBag.CodeSort = sOdr == "Code_desc" ? "Code_asc" : "Code_desc";
                //ViewBag.PDateSort = sOdr == "SubDate_desc" ? "SubDate_asc" : "SubDate_desc";
                //ViewBag.SkillSort = sOdr == "Skill_desc" ? "Skill_asc" : "Skill_desc";
                //ViewBag.StatusSort = sOdr == "Sts_desc" ? "Sts_asc" : "Sts_desc";

                switch (sOdr)
                {
                    case "Name_desc":
                        cust = cust.OrderByDescending(s => s.CUST_NAME).ToList();
                        break;
                    case "Code_desc":
                        cust = cust.OrderByDescending(s => s.CUST_CODE).ToList();
                        break;
                    case "Code_asc":
                        cust = cust.OrderBy(s => s.CUST_CODE).ToList();
                        break;
                    default:
                        cust = cust.OrderBy(s => s.CUST_NAME).ToList();
                        break;
                }
            }
            
            ViewBag.PageSize = pageSize;
            ViewBag.PageNo = (page ?? 1);
            return cust;
        }

        private void setDropdownList()
        {
            List<LookupDataViewModels> lstOfLookups = new List<LookupDataViewModels>();
            var content = httpHelpers.GetHttpContent(string.Format("{0}/{1}", IMSConst.API_SERVICE_BASE_ADRS, IMSConst.LOOKUP_GET_ENDPNT));
            List<LookupCategoryViewModels> custModel = serializer.DeSerialize<List<LookupCategoryViewModels>>(content) as List<LookupCategoryViewModels>;

            var LoB = custModel.Where(x => x.LOOKUPCATEGORYCODE == Lookup.LineOfBusiness.ToString()).FirstOrDefault();
            var LoBlst = LoB==null? lstOfLookups : LoB.LOOKUP_DATA.ToList();
            ViewBag.LoB = new SelectList(LoBlst.AsQueryable(), "LOOKUPID", "LOOKUPCODE", 1);

            var discountBand = custModel.Where(x => x.LOOKUPCATEGORYCODE == Lookup.DiscountBand.ToString()).FirstOrDefault();
            var discountBandlst = LoB == null ? lstOfLookups : discountBand.LOOKUP_DATA.ToList();
            ViewBag.discountBand = new SelectList(discountBandlst.AsQueryable(), "LOOKUPID", "LOOKUPCODE", 1);

            var callPreference = custModel.Where(x => x.LOOKUPCATEGORYCODE == Lookup.CallPreference.ToString()).FirstOrDefault();
            var callPreferencelst = LoB == null ? lstOfLookups : callPreference.LOOKUP_DATA.ToList();
            ViewBag.callPreference = new SelectList(callPreferencelst.AsQueryable(), "LOOKUPID", "LOOKUPCODE", 1);
        }
        #endregion
    }
}