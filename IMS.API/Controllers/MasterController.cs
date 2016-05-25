using IMS.DataModel.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;

namespace IMS.API.Controllers
{
    public class MasterController : ApiController
    {
        private IMSEntities db = new IMSEntities();

        //GET: api/LookupCategories
        public IQueryable<LOOKUP_CATEGORIES> GetLookupCategories()
        {
            return db.LOOKUP_CATEGORIES;
        }

        // GET: api/LookupData
        [Route("api/Master/GetAllLookup")]
        [HttpGet]
        public List<LOOKUP_CATEGORIES> GetLookupData()
        {
            var lkpDataLst = db.LOOKUP_DATA.ToList().ToList();
            List<LOOKUP_CATEGORIES> lookupData = (from item in db.LOOKUP_CATEGORIES.ToList().Where(x=>x.ISACTIVE==true)
                              select new LOOKUP_CATEGORIES
                              {
                                  LOOKUP_DATA = (lkpDataLst.Where(i => i.LOOKUPCATEGORYID == item.LOOKUPCATEGORYID && i.ISACTIVE == true)).Select(
                                  dt => new LOOKUP_DATA { LOOKUPID = dt.LOOKUPID, LOOKUPCODE = dt.LOOKUPCODE, LOOKUPDESC = dt.LOOKUPDESC }).ToList(),
                                  LOOKUPCATEGORYID = item.LOOKUPCATEGORYID,
                                  LOOKUPCATEGORYCODE = item.LOOKUPCATEGORYCODE,
                                  LOOKUPCATEGORYDESC = item.LOOKUPCATEGORYDESC,
                                  ISAPPSPECIFIC = item.ISAPPSPECIFIC,
                                  ISORGSPECIFIC = item.ISORGSPECIFIC,
                              }).Distinct().ToList().Where(x => x.LOOKUP_DATA.Count() > 0).ToList();
            return lookupData;
        }
    }
}
