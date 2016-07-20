using IMS.DataModel.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace IMS.API.Controllers
{
    [RoutePrefix("api/Master")]
    public class MasterController : ApiController
    {
        private IMSEntities db = new IMSEntities();

        //GET: api/LookupCategories
        public IQueryable<LOOKUP_CATEGORIES> GetLookupCategories()
        {
            return db.LOOKUP_CATEGORIES;
        }

        // GET: api/LookupData
        public List<LOOKUP_CATEGORIES> GetAllLookup()
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

        [HttpPost]
        public async Task<IHttpActionResult> PostLocation(LOCATION_MASTER location)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.LOCATION_MASTER.Add(location);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                throw;
            }

            return CreatedAtRoute("DefaultApi", new { id = location.LOC_ID }, location);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        
    }
}
