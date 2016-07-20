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
    public class CompanyController : ApiController
    {
        private IMSEntities db = new IMSEntities();

        // GET: api/Company
        public IQueryable<COMPANY> GetCOMPANies() 
        {
            return db.COMPANies;
        }

        // GET: api/Company/5
        [ResponseType(typeof(COMPANY))]
        public async Task<IHttpActionResult> GetCOMPANY(Guid id)
        {
            COMPANY cOMPANY = await db.COMPANies.FindAsync(id);
            if (cOMPANY == null)
            {
                return NotFound();
            }

            return Ok(cOMPANY);
        }

        // PUT: api/Company/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCOMPANY(Guid id, COMPANY cOMPANY)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cOMPANY.COMP_ID)
            {
                return BadRequest();
            }

            db.Entry(cOMPANY).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!COMPANYExists(id))
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

        // POST: api/Company
        [ResponseType(typeof(COMPANY))]
        public async Task<IHttpActionResult> PostCOMPANY(COMPANY cOMPANY)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.COMPANies.Add(cOMPANY);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (COMPANYExists(cOMPANY.COMP_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = cOMPANY.COMP_ID }, cOMPANY);
        }

        // DELETE: api/Company/5
        [ResponseType(typeof(COMPANY))]
        public async Task<IHttpActionResult> DeleteCOMPANY(Guid id)
        {
            COMPANY cOMPANY = await db.COMPANies.FindAsync(id);
            if (cOMPANY == null)
            {
                return NotFound();
            }

            db.COMPANies.Remove(cOMPANY);
            await db.SaveChangesAsync();

            return Ok(cOMPANY);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool COMPANYExists(Guid id)
        {
            return db.COMPANies.Count(e => e.COMP_ID == id) > 0;
        }
    }
}