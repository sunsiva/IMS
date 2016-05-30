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
    public class QuotationController : ApiController
    {
        private IMSEntities db = new IMSEntities();

        // GET: api/QUOTATION
        public IQueryable<QUOTATION> GetQUOTATIONs()
        {
            return db.QUOTATIONs;
        }

        // GET: api/QUOTATION/5
        [ResponseType(typeof(QUOTATION))]
        public async Task<IHttpActionResult> GetQUOTATION(Guid id)
        {
            QUOTATION qUOTATION = await db.QUOTATIONs.FindAsync(id);
            if (qUOTATION == null)
            {
                return NotFound();
            }

            return Ok(qUOTATION);
        }

        // PUT: api/QUOTATION/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutQUOTATION(Guid id, QUOTATION qUOTATION)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != qUOTATION.QUOTE_ID)
            {
                return BadRequest();
            }

            db.Entry(qUOTATION).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QUOTATIONExists(id))
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

        // POST: api/QUOTATION
        [ResponseType(typeof(QUOTATION))]
        public async Task<IHttpActionResult> PostQUOTATION(QUOTATION qUOTATION)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.QUOTATIONs.Add(qUOTATION);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (QUOTATIONExists(qUOTATION.QUOTE_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = qUOTATION.QUOTE_ID }, qUOTATION);
        }

        // DELETE: api/QUOTATION/5
        [ResponseType(typeof(QUOTATION))]
        public async Task<IHttpActionResult> DeleteQUOTATION(Guid id)
        {
            QUOTATION qUOTATION = await db.QUOTATIONs.FindAsync(id);
            if (qUOTATION == null)
            {
                return NotFound();
            }

            db.QUOTATIONs.Remove(qUOTATION);
            await db.SaveChangesAsync();

            return Ok(qUOTATION);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool QUOTATIONExists(Guid id)
        {
            return db.QUOTATIONs.Count(e => e.QUOTE_ID == id) > 0;
        }
    }
}