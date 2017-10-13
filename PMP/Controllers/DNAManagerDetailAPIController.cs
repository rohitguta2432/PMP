
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
    public class DNAManagerDetailController : ApiController
    {
        private PMP.PMPEntities db = new PMP.PMPEntities();

        public IQueryable<DNAManagerDetailDTO> GetDNAManagerDetails(int pageSize = 10
                        ,System.Int32? ProjectID = null
                        ,System.Int32? CreatedBy = null
                        ,System.Int32? ModifiedBy = null
                )
        {
            var model = db.DNAManagerDetails.AsQueryable();
                                if(ProjectID != null){
                        model = model.Where(m=> m.ProjectID == ProjectID.Value);
                    }
                                if(CreatedBy != null){
                        model = model.Where(m=> m.CreatedBy == CreatedBy.Value);
                    }
                                if(ModifiedBy != null){
                        model = model.Where(m=> m.ModifiedBy == ModifiedBy.Value);
                    }
                        
            return model.Select(DNAManagerDetailDTO.SELECT).Take(pageSize);
        }

        [ResponseType(typeof(DNAManagerDetailDTO))]
        public async Task<IHttpActionResult> GetDNAManagerDetail(int id)
        {
            var model = await db.DNAManagerDetails.Select(DNAManagerDetailDTO.SELECT).FirstOrDefaultAsync(x => x.DNAManagerID == id);
            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        public async Task<IHttpActionResult> PutDNAManagerDetail(int id, DNAManagerDetail model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != model.DNAManagerID)
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
                if (!DNAManagerDetailExists(id))
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

        [ResponseType(typeof(DNAManagerDetailDTO))]
        public async Task<IHttpActionResult> PostDNAManagerDetail(DNAManagerDetail model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DNAManagerDetails.Add(model);
            await db.SaveChangesAsync();
            var ret = await db.DNAManagerDetails.Select(DNAManagerDetailDTO.SELECT).FirstOrDefaultAsync(x => x.DNAManagerID == model.DNAManagerID);
            return CreatedAtRoute("DefaultApi", new { id = model.DNAManagerID }, model);
        }

        [ResponseType(typeof(DNAManagerDetailDTO))]
        public async Task<IHttpActionResult> DeleteDNAManagerDetail(int id)
        {
            DNAManagerDetail model = await db.DNAManagerDetails.FindAsync(id);
            if (model == null)
            {
                return NotFound();
            }

            db.DNAManagerDetails.Remove(model);
            await db.SaveChangesAsync();
            var ret = await db.DNAManagerDetails.Select(DNAManagerDetailDTO.SELECT).FirstOrDefaultAsync(x => x.DNAManagerID == model.DNAManagerID);
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

        private bool DNAManagerDetailExists(int id)
        {
            return db.DNAManagerDetails.Count(e => e.DNAManagerID == id) > 0;
        }
    }
}