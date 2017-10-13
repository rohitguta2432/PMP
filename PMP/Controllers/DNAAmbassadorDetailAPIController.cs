
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

namespace PMP
{
    public class DNAAmbassadorDetailController : ApiController
    {
        private PMP.PMPEntities db = new PMP.PMPEntities();

        public IQueryable<DNAAmbassadorDetailDTO> GetDNAAmbassadorDetails(int pageSize = 10
                        ,System.Int32? ProjectID = null
                        ,System.Int32? CreatedBy = null
                        ,System.Int32? ModifiedBy = null
                )
        {
            var model = db.DNAAmbassadorDetails.AsQueryable();
                                if(ProjectID != null){
                        model = model.Where(m=> m.ProjectID == ProjectID.Value);
                    }
                                if(CreatedBy != null){
                        model = model.Where(m=> m.CreatedBy == CreatedBy.Value);
                    }
                                if(ModifiedBy != null){
                        model = model.Where(m=> m.ModifiedBy == ModifiedBy.Value);
                    }
                        
            return model.Select(DNAAmbassadorDetailDTO.SELECT).Take(pageSize);
        }

        [ResponseType(typeof(DNAAmbassadorDetailDTO))]
        public async Task<IHttpActionResult> GetDNAAmbassadorDetail(int id)
        {
            var model = await db.DNAAmbassadorDetails.Select(DNAAmbassadorDetailDTO.SELECT).FirstOrDefaultAsync(x => x.AmbassadorsID == id);
            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        public async Task<IHttpActionResult> PutDNAAmbassadorDetail(int id, DNAAmbassadorDetail model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != model.AmbassadorsID)
            {
                return BadRequest();
            }

            db.Entry(model).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DNAAmbassadorDetailExists(id))
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

        [ResponseType(typeof(DNAAmbassadorDetailDTO))]
        public async Task<IHttpActionResult> PostDNAAmbassadorDetail(DNAAmbassadorDetail model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DNAAmbassadorDetails.Add(model);
            await db.SaveChangesAsync();
            var ret = await db.DNAAmbassadorDetails.Select(DNAAmbassadorDetailDTO.SELECT).FirstOrDefaultAsync(x => x.AmbassadorsID == model.AmbassadorsID);
            return CreatedAtRoute("DefaultApi", new { id = model.AmbassadorsID }, model);
        }

        [ResponseType(typeof(DNAAmbassadorDetailDTO))]
        public async Task<IHttpActionResult> DeleteDNAAmbassadorDetail(int id)
        {
            DNAAmbassadorDetail model = await db.DNAAmbassadorDetails.FindAsync(id);
            if (model == null)
            {
                return NotFound();
            }

            db.DNAAmbassadorDetails.Remove(model);
            await db.SaveChangesAsync();
            var ret = await db.DNAAmbassadorDetails.Select(DNAAmbassadorDetailDTO.SELECT).FirstOrDefaultAsync(x => x.AmbassadorsID == model.AmbassadorsID);
            return Ok(ret);
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DNAAmbassadorDetailExists(int id)
        {
            return db.DNAAmbassadorDetails.Count(e => e.AmbassadorsID == id) > 0;
        }
    }
}