
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
    public class OverallStatuController : ApiController
    {
        private PMP.PMPEntities db = new PMP.PMPEntities();

        public IQueryable<OverallStatuDTO> GetOverallStatus(int pageSize = 10
                        ,System.Int32? CreatedBy = null
                        ,System.Int32? ModifiedBy = null
                )
        {
            var model = db.OverallStatus.AsQueryable();
                                if(CreatedBy != null){
                        model = model.Where(m=> m.CreatedBy == CreatedBy.Value);
                    }
                                if(ModifiedBy != null){
                        model = model.Where(m=> m.ModifiedBy == ModifiedBy.Value);
                    }
                        
            return model.Select(OverallStatuDTO.SELECT).Take(pageSize);
        }

        [ResponseType(typeof(OverallStatuDTO))]
        public async Task<IHttpActionResult> GetOverallStatu(int id)
        {
            var model = await db.OverallStatus.Select(OverallStatuDTO.SELECT).FirstOrDefaultAsync(x => x.OverallStatusID == id);
            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        public async Task<IHttpActionResult> PutOverallStatu(int id, OverallStatu model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != model.OverallStatusID)
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
                if (!OverallStatuExists(id))
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

        [ResponseType(typeof(OverallStatuDTO))]
        public async Task<IHttpActionResult> PostOverallStatu(OverallStatu model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.OverallStatus.Add(model);
            await db.SaveChangesAsync();
            var ret = await db.OverallStatus.Select(OverallStatuDTO.SELECT).FirstOrDefaultAsync(x => x.OverallStatusID == model.OverallStatusID);
            return CreatedAtRoute("DefaultApi", new { id = model.OverallStatusID }, model);
        }

        [ResponseType(typeof(OverallStatuDTO))]
        public async Task<IHttpActionResult> DeleteOverallStatu(int id)
        {
            OverallStatu model = await db.OverallStatus.FindAsync(id);
            if (model == null)
            {
                return NotFound();
            }

            db.OverallStatus.Remove(model);
            await db.SaveChangesAsync();
            var ret = await db.OverallStatus.Select(OverallStatuDTO.SELECT).FirstOrDefaultAsync(x => x.OverallStatusID == model.OverallStatusID);
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

        private bool OverallStatuExists(int id)
        {
            return db.OverallStatus.Count(e => e.OverallStatusID == id) > 0;
        }
    }
}