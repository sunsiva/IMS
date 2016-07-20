using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using IMS.API;

namespace IMS.API.Controllers
{
    public class PurchaseOrderController : ApiController
    {
        private IMSEntities db = new IMSEntities();

        // GET: api/PurchaseOrder
        public IQueryable<PURCHASE_ORDER> GetPURCHASE_ORDER()
        {
            return db.PURCHASE_ORDER;  
        }

        // GET: api/PurchaseOrder/5
        [ResponseType(typeof(PURCHASE_ORDER))]
        public async Task<IHttpActionResult> GetPURCHASE_ORDER(Guid id)
        {
            PURCHASE_ORDER pURCHASE_ORDER = await db.PURCHASE_ORDER.FindAsync(id);
            if (pURCHASE_ORDER == null)
            {
                return NotFound();
            }

            return Ok(pURCHASE_ORDER);
        }

        // PUT: api/PurchaseOrder/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPURCHASE_ORDER(Guid id, PURCHASE_ORDER pURCHASE_ORDER)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pURCHASE_ORDER.PO_ID)
            {
                return BadRequest();
            }

            db.Entry(pURCHASE_ORDER).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PURCHASE_ORDERExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/PurchaseOrder
        [ResponseType(typeof(PURCHASE_ORDER))]
        public async Task<IHttpActionResult> PostPURCHASE_ORDER(PURCHASE_ORDER pURCHASE_ORDER)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PURCHASE_ORDER.Add(pURCHASE_ORDER);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PURCHASE_ORDERExists(pURCHASE_ORDER.PO_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = pURCHASE_ORDER.PO_ID }, pURCHASE_ORDER);
        }

        // DELETE: api/PurchaseOrder/5
        [ResponseType(typeof(PURCHASE_ORDER))]
        public async Task<IHttpActionResult> DeletePURCHASE_ORDER(Guid id)
        {
            PURCHASE_ORDER pURCHASE_ORDER = await db.PURCHASE_ORDER.FindAsync(id);
            if (pURCHASE_ORDER == null)
            {
                return NotFound();
            }

            db.PURCHASE_ORDER.Remove(pURCHASE_ORDER);
            await db.SaveChangesAsync();

            return Ok(pURCHASE_ORDER);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PURCHASE_ORDERExists(Guid id)
        {
            return db.PURCHASE_ORDER.Count(e => e.PO_ID == id) > 0;
        }
    }
}