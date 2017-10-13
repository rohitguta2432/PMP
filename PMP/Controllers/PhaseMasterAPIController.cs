
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
    public class PhaseMasterController : ApiController
    {
        private PMP.PMPEntities db = new PMP.PMPEntities();

        public IQueryable<PhaseMasterDTO> GetPhaseMasters(int pageSize = 10
                        ,System.Int32? CreatedBy = null
                        ,System.Int32? ModifiedBy = null
                )
        {
            var model = db.PhaseMasters.AsQueryable();
                                if(CreatedBy != null){
                        model = model.Where(m=> m.CreatedBy == CreatedBy.Value);
                    }
                                if(ModifiedBy != null){
                        model = model.Where(m=> m.ModifiedBy == ModifiedBy.Value);
                    }
                        
            return model.Select(PhaseMasterDTO.SELECT).Take(pageSize);
        }

        [ResponseType(typeof(PhaseMasterDTO))]
        public async Task<IHttpActionResult> GetPhaseMaster(int id)
        {
            var model = await db.PhaseMasters.Select(PhaseMasterDTO.SELECT).FirstOrDefaultAsync(x => x.PhaseID == id);
            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        public async Task<IHttpActionResult> PutPhaseMaster(int id, PhaseMaster model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != model.PhaseID)
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
                if (!PhaseMasterExists(id))
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

        [ResponseType(typeof(PhaseMasterDTO))]
        public async Task<IHttpActionResult> PostPhaseMaster(PhaseMaster model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PhaseMasters.Add(model);
            await db.SaveChangesAsync();
            var ret = await db.PhaseMasters.Select(PhaseMasterDTO.SELECT).FirstOrDefaultAsync(x => x.PhaseID == model.PhaseID);
            return CreatedAtRoute("DefaultApi", new { id = model.PhaseID }, model);
        }

        [ResponseType(typeof(PhaseMasterDTO))]
        public async Task<IHttpActionResult> DeletePhaseMaster(int id)
        {
            PhaseMaster model = await db.PhaseMasters.FindAsync(id);
            if (model == null)
            {
                return NotFound();
            }

            db.PhaseMasters.Remove(model);
            await db.SaveChangesAsync();
            var ret = await db.PhaseMasters.Select(PhaseMasterDTO.SELECT).FirstOrDefaultAsync(x => x.PhaseID == model.PhaseID);
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

        private bool PhaseMasterExists(int id)
        {
            return db.PhaseMasters.Count(e => e.PhaseID == id) > 0;
        }
    }
}