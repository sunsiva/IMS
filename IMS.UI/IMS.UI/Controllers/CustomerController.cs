using IMS.Common;
using IMS.Common.Enums;
using IMS.DataModel.Common;
using IMS.DataModel.ViewModels;
using IMS.UI.Common;
using IMS.UI.Models;
using Microsoft.AspNet.Identity;
using PagedList;
using Serializer;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IMS.UI.Controllers
{
    public class CustomerController : BaseController
    {
        readonly JsonNetSerialization serializer = new JsonNetSerialization();
        readonly HttpHelpers httpHelpers = new HttpHelpers();
        const int pageSize = 10;
        Guid _uid = new Guid();

        public CustomerController()
        {
            //_uid = CookieStore.GetCookie(CacheKey.Uid.ToString())==null? Guid.Parse(User.Identity.GetUserId()) : Guid.Parse(CookieStore.GetCookie(CacheKey.Uid.ToString()));
        }

        // GET: Customer
        [HttpGet]
        public ActionResult Index(string sOdr, int? page)
        {
            try
            {
                var content = httpHelpers.GetHttpContent(string.Format("{0}/{1}", IMSConst.API_SERVICE_BASE_ADRS, IMSConst.CUST_GET_ENDPNT));
                List<CustomerViewModels> custModel = serializer.DeSerialize<List<CustomerViewModels>>(content) as List<CustomerViewModels>;
                custModel = GetPagination(custModel, sOdr, page);

                int pSize = ViewBag.PageSize == null ? 0 : ViewBag.PageSize;
                int pNo = ViewBag.PageNo == null ? 0 : ViewBag.PageNo;

                return View(custModel.ToPagedList(pNo, pSize));
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult Details()
        {

            return View();
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
            try
            {
                if (ModelState.IsValid)
                {
                    model.CUST_ID = Guid.NewGuid();
                    model.ISACTIVE = true;
                    model.CREATED_BY = _uid == null ? Guid.Parse(User.Identity.GetUserId()) : _uid;
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
            catch(Exception ex)
            {
                LoggingUtil.LogException(ex, errorLevel: ErrorLevel.Critical);
                throw ex;
            }
        }

        public ActionResult GetLoB(string query)
        {
            return Json(_GetLoB(query), JsonRequestBehavior.AllowGet);
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

        private List<SelectedItemModel> GetAllLoBs()
        {
            List<LookupDataViewModels> lstOfLookups = new List<LookupDataViewModels>();
            var content = httpHelpers.GetHttpContent(string.Format("{0}/{1}", IMSConst.API_SERVICE_BASE_ADRS, IMSConst.LOOKUP_GET_ENDPNT));
            List<LookupCategoryViewModels> custModel = serializer.DeSerialize<List<LookupCategoryViewModels>>(content) as List<LookupCategoryViewModels>;

            var LoB = custModel.Where(x => x.LOOKUPCATEGORYCODE == Lookup.LineOfBusiness.ToString()).FirstOrDefault();
            var LoBlst = LoB == null ? lstOfLookups : LoB.LOOKUP_DATA.ToList();

            List<SelectedItemModel> obj = (from item in LoBlst
                                           select new { sel = item }).Select(row => new SelectedItemModel
                                           {
                                               Id = row.sel.LOOKUPID,
                                               Text = row.sel.LOOKUPCODE,
                                               Selected = true
                                           }).OrderBy(o => o.Text).ToList();
            return obj;
        }

        private void setDropdownList()
        {
            List<LookupDataViewModels> lstOfLookups = new List<LookupDataViewModels>();
            var content = httpHelpers.GetHttpContent(string.Format("{0}/{1}", IMSConst.API_SERVICE_BASE_ADRS, IMSConst.LOOKUP_GET_ENDPNT));
            List<LookupCategoryViewModels> custModel = serializer.DeSerialize<List<LookupCategoryViewModels>>(content) as List<LookupCategoryViewModels>;

            var LoB = custModel.Where(x => x.LOOKUPCATEGORYCODE == Lookup.LineOfBusiness.ToString()).FirstOrDefault();
            var LoBlst = LoB==null? lstOfLookups : LoB.LOOKUP_DATA.ToList();
            ViewBag.LoB = new SelectList(LoBlst.AsQueryable(), "LOOKUPID", "LOOKUPCODE", 1);
            List<SelectedItemModel> obj = (from item in LoBlst
                                           select new { sel = item }).Select(row => new SelectedItemModel
                                           {
                                               Id = row.sel.LOOKUPID,
                                               Text = row.sel.LOOKUPCODE,
                                               Selected = row.sel.LOOKUPID.Equals(1)
                                           }).OrderBy(o=>o.Text).ToList();

            var discountBand = custModel.Where(x => x.LOOKUPCATEGORYCODE == Lookup.DiscountBand.ToString()).FirstOrDefault();
            var discountBandlst = LoB == null ? lstOfLookups : discountBand.LOOKUP_DATA.ToList();
            ViewBag.discountBand = new SelectList(discountBandlst.AsQueryable(), "LOOKUPID", "LOOKUPCODE", 1);

            var callPreference = custModel.Where(x => x.LOOKUPCATEGORYCODE == Lookup.CallPreference.ToString()).FirstOrDefault();
            var callPreferencelst = LoB == null ? lstOfLookups : callPreference.LOOKUP_DATA.ToList();
            ViewBag.callPreference = new SelectList(callPreferencelst.AsQueryable(), "LOOKUPID", "LOOKUPCODE", 1);
        }

        //public List<SelectListModel> GetLocation(List<SelectListModel> selectedLocation = null, List<Guid> careGroupKeys = null)
        //{
        //    selectedLocation = selectedLocation ?? new List<SelectListModel>();
        //    careGroupKeys = careGroupKeys ?? new List<Guid>();
        //    var rowKeys = selectedLocation.Select(r => r.RowKey).ToList();

        //    var locations = this.DataUnit.LocationRepository.Get()
        //        .Where(row => row.IsActive && (careGroupKeys.Count() == 0 || careGroupKeys.Contains(row.CareGroupKey)))
        //        .Select(row => new SelectListModel
        //        {
        //            RowKey = row.RowKey,
        //            Text = row.LocationName,
        //            Selected = rowKeys.Contains(row.RowKey)
        //        }).OrderBy(k => k.Text).ToList();

        //    return locations;
        //}

        private List<SelectedItemModel> _GetLoB(string query)
        {
            List<SelectedItemModel> people = new List<SelectedItemModel>();
            try
            {
                List<LookupDataViewModels> lstOfLookups = new List<LookupDataViewModels>();
                var content = httpHelpers.GetHttpContent(string.Format("{0}/{1}", IMSConst.API_SERVICE_BASE_ADRS, IMSConst.LOOKUP_GET_ENDPNT));
                List<LookupCategoryViewModels> custModel = serializer.DeSerialize<List<LookupCategoryViewModels>>(content) as List<LookupCategoryViewModels>;

                var LoB = custModel.Where(x => x.LOOKUPCATEGORYCODE == Lookup.LineOfBusiness.ToString()).FirstOrDefault();
                var LoBlst = LoB == null ? lstOfLookups : LoB.LOOKUP_DATA.ToList();
                ViewBag.LoB = new SelectList(LoBlst.AsQueryable(), "LOOKUPID", "LOOKUPCODE", 1);
                var results = (from item in LoBlst
                                select new { sel = item }).Select(row => new SelectedItemModel
                                {
                                    Id = row.sel.LOOKUPID,
                                    Text = row.sel.LOOKUPCODE,
                                    Selected = row.sel.LOOKUPID.Equals(1)
                                }).OrderBy(o => o.Text).ToList();

                //var results = (from p in db.People
                //               where (p.FirstName + " " + p.LastName).Contains(query)
                //               orderby p.FirstName, p.LastName
                //               select p).Take(10).ToList();
                //foreach (var r in results)
                //{
                //    // create objects
                //    Autocomplete person = new Autocomplete();
                //    person.Name = string.Format("{0} {1}", r.FirstName, r.LastName);
                //    person.Id = r.PersonId;
                //    people.Add(person);
                //}

            }
            catch (EntityCommandExecutionException eceex)
            {
                if (eceex.InnerException != null)
                {
                    throw eceex.InnerException;
                }
                throw;
            }
            catch
            {
                throw;
            }
            return people;
        }

        #endregion
    }
}