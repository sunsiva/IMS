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
    public class CustomerController : ApiController
    {
        private IMSEntities db = new IMSEntities();

        // GET: api/Customer
        public IQueryable<CUSTOMER> GetCUSTOMERs()
        {
            return db.CUSTOMERs; 
        }

        // GET: api/Customer/5
        [ResponseType(typeof(CUSTOMER))]
        public async Task<IHttpActionResult> GetCUSTOMER(Guid id)
        {
            CUSTOMER cUSTOMER = await db.CUSTOMERs.FindAsync(id);
            if (cUSTOMER == null)
            {
                return NotFound();
            }

            return Ok(cUSTOMER);
        }

        // PUT: api/Customer/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCUSTOMER(Guid id, CUSTOMER cUSTOMER)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cUSTOMER.CUST_ID)
            {
                return BadRequest();
            }

            db.Entry(cUSTOMER).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CUSTOMERExists(id))
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

        // POST: api/Customer
        [ResponseType(typeof(CUSTOMER))]
        public async Task<IHttpActionResult> PostCUSTOMER(CUSTOMER cUSTOMER)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CUSTOMERs.Add(cUSTOMER);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CUSTOMERExists(cUSTOMER.CUST_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = cUSTOMER.CUST_ID }, cUSTOMER);
        }

        // DELETE: api/Customer/5
        [ResponseType(typeof(CUSTOMER))]
        public async Task<IHttpActionResult> DeleteCUSTOMER(Guid id)
        {
            CUSTOMER cUSTOMER = await db.CUSTOMERs.FindAsync(id);
            if (cUSTOMER == null)
            {
                return NotFound();
            }

            db.CUSTOMERs.Remove(cUSTOMER);
            await db.SaveChangesAsync();

            return Ok(cUSTOMER);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CUSTOMERExists(Guid id)
        {
            return db.CUSTOMERs.Count(e => e.CUST_ID == id) > 0;
        }
    }
}