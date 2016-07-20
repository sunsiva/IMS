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
    public class ProductController : ApiController
    {
        private IMSEntities db = new IMSEntities();

        // GET: api/Product
        public IQueryable<PRODUCT> GetPRODUCTS() 
        {
            return db.PRODUCTS;
        }

        // GET: api/Product/5
        [ResponseType(typeof(PRODUCT))]
        public async Task<IHttpActionResult> GetPRODUCT(Guid id)
        {
            PRODUCT pRODUCT = await db.PRODUCTS.FindAsync(id);
            if (pRODUCT == null)
            {
                return NotFound();
            }

            return Ok(pRODUCT);
        }

        // PUT: api/Product/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPRODUCT(Guid id, PRODUCT pRODUCT)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pRODUCT.PRODUCT_ID)
            {
                return BadRequest();
            }

            db.Entry(pRODUCT).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PRODUCTExists(id))
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

        // POST: api/Product
        [ResponseType(typeof(PRODUCT))]
        public async Task<IHttpActionResult> PostPRODUCT(PRODUCT pRODUCT)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PRODUCTS.Add(pRODUCT);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PRODUCTExists(pRODUCT.PRODUCT_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = pRODUCT.PRODUCT_ID }, pRODUCT);
        }

        // DELETE: api/Product/5
        [ResponseType(typeof(PRODUCT))]
        public async Task<IHttpActionResult> DeletePRODUCT(Guid id)
        {
            PRODUCT pRODUCT = await db.PRODUCTS.FindAsync(id);
            if (pRODUCT == null)
            {
                return NotFound();
            }

            db.PRODUCTS.Remove(pRODUCT);
            await db.SaveChangesAsync();

            return Ok(pRODUCT);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PRODUCTExists(Guid id)
        {
            return db.PRODUCTS.Count(e => e.PRODUCT_ID == id) > 0;
        }
    }
}