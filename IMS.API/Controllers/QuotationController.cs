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
    [RoutePrefix("api/Quotation")]
    public class QuotationController : ApiController
    {
        private IMSEntities db = new IMSEntities();

        // GET: api/QUOTATION/{action}
        public IQueryable<QUOTATION> GetQUOTATIONs()
        {
            return db.QUOTATIONs;
        }

        // GET: api/QUOTATION/{action}/5
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

        // PUT: api/QUOTATION/{action}/5
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

        // POST: api/QUOTATION/{action}
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

        // DELETE: api/QUOTATION/{action}/5
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

        #region "RFQ"
        // GET: api/Quotation/{action}
        public IQueryable<RFQ> GetRFQs()
        {
            return db.RFQs;
        }

        // GET: api/Quotation/{action}/5
        public async Task<IHttpActionResult> GetRFQById(Guid id)
        {
            RFQ rfq = await db.RFQs.FindAsync(id);
            if (rfq == null)
            {
                return NotFound();
            }

            return Ok(rfq);
        }

        // PUT: api/Quotation/{action}/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutRFQ(Guid id, RFQ rfq)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != rfq.RFQ_ID)
            {
                return BadRequest();
            }

            db.Entry(rfq).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RFQExists(id))
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

        // POST: api/Quotation/{action}
        [ResponseType(typeof(RFQ))]
        public async Task<IHttpActionResult> PostRFQ(RFQ rfq)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.RFQs.Add(rfq);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (RFQExists(rfq.RFQ_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = rfq.RFQ_ID }, rfq);
        }

        // DELETE: api/Quotation/{action}/5
        [ResponseType(typeof(RFQ))]
        public async Task<IHttpActionResult> DeleteRFQ(Guid id)
        {
            RFQ rfq = await db.RFQs.FindAsync(id);
            if (rfq == null)
            {
                return NotFound();
            }

            db.RFQs.Remove(rfq);
            await db.SaveChangesAsync();

            return Ok(rfq);
        }

        private bool RFQExists(Guid id)
        {
            return db.RFQs.Count(e => e.RFQ_ID == id) > 0;
        }
        #endregion
    }
}