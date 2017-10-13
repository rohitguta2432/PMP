
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
    public class MethodologyMasterController : ApiController
    {
        private PMP.PMPEntities db = new PMP.PMPEntities();

        public IQueryable<MethodologyMasterDTO> GetMethodologyMasters(int pageSize = 10
                        ,System.Int32? CreatedBy = null
                        ,System.Int32? ModifiedBy = null
                )
        {
            var model = db.MethodologyMasters.AsQueryable();
                                if(CreatedBy != null){
                        model = model.Where(m=> m.CreatedBy == CreatedBy.Value);
                    }
                                if(ModifiedBy != null){
                        model = model.Where(m=> m.ModifiedBy == ModifiedBy.Value);
                    }
                        
            return model.Select(MethodologyMasterDTO.SELECT).Take(pageSize);
        }

        [ResponseType(typeof(MethodologyMasterDTO))]
        public async Task<IHttpActionResult> GetMethodologyMaster(int id)
        {
            var model = await db.MethodologyMasters.Select(MethodologyMasterDTO.SELECT).FirstOrDefaultAsync(x => x.MethodID == id);
            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        public async Task<IHttpActionResult> PutMethodologyMaster(int id, MethodologyMaster model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != model.MethodID)
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
                if (!MethodologyMasterExists(id))
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

        [ResponseType(typeof(MethodologyMasterDTO))]
        public async Task<IHttpActionResult> PostMethodologyMaster(MethodologyMaster model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MethodologyMasters.Add(model);
            await db.SaveChangesAsync();
            var ret = await db.MethodologyMasters.Select(MethodologyMasterDTO.SELECT).FirstOrDefaultAsync(x => x.MethodID == model.MethodID);
            return CreatedAtRoute("DefaultApi", new { id = model.MethodID }, model);
        }

        [ResponseType(typeof(MethodologyMasterDTO))]
        public async Task<IHttpActionResult> DeleteMethodologyMaster(int id)
        {
            MethodologyMaster model = await db.MethodologyMasters.FindAsync(id);
            if (model == null)
            {
                return NotFound();
            }

            db.MethodologyMasters.Remove(model);
            await db.SaveChangesAsync();
            var ret = await db.MethodologyMasters.Select(MethodologyMasterDTO.SELECT).FirstOrDefaultAsync(x => x.MethodID == model.MethodID);
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

        private bool MethodologyMasterExists(int id)
        {
            return db.MethodologyMasters.Count(e => e.MethodID == id) > 0;
        }
    }
}