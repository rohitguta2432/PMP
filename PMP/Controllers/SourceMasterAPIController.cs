
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
    public class SourceMasterController : ApiController
    {
        private PMP.PMPEntities db = new PMP.PMPEntities();

        public IQueryable<SourceMasterDTO> GetSourceMasters(int pageSize = 10
                        ,System.Int32? CreatedBy = null
                        ,System.Int32? ModifiedBy = null
                )
        {
            var model = db.SourceMasters.AsQueryable();
                                if(CreatedBy != null){
                        model = model.Where(m=> m.CreatedBy == CreatedBy.Value);
                    }
                                if(ModifiedBy != null){
                        model = model.Where(m=> m.ModifiedBy == ModifiedBy.Value);
                    }
                        
            return model.Select(SourceMasterDTO.SELECT).OrderBy(x=>x.SourceDesc).Take(pageSize);
        }

        [ResponseType(typeof(SourceMasterDTO))]
        public async Task<IHttpActionResult> GetSourceMaster(int id)
        {
            var model = await db.SourceMasters.Select(SourceMasterDTO.SELECT).FirstOrDefaultAsync(x => x.SourceID == id);
            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        public async Task<IHttpActionResult> PutSourceMaster(int id, SourceMaster model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != model.SourceID)
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
                if (!SourceMasterExists(id))
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

        [ResponseType(typeof(SourceMasterDTO))]
        public async Task<IHttpActionResult> PostSourceMaster(SourceMaster model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SourceMasters.Add(model);
            await db.SaveChangesAsync();
            var ret = await db.SourceMasters.Select(SourceMasterDTO.SELECT).FirstOrDefaultAsync(x => x.SourceID == model.SourceID);
            return CreatedAtRoute("DefaultApi", new { id = model.SourceID }, model);
        }

        [ResponseType(typeof(SourceMasterDTO))]
        public async Task<IHttpActionResult> DeleteSourceMaster(int id)
        {
            SourceMaster model = await db.SourceMasters.FindAsync(id);
            if (model == null)
            {
                return NotFound();
            }

            db.SourceMasters.Remove(model);
            await db.SaveChangesAsync();
            var ret = await db.SourceMasters.Select(SourceMasterDTO.SELECT).FirstOrDefaultAsync(x => x.SourceID == model.SourceID);
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

        private bool SourceMasterExists(int id)
        {
            return db.SourceMasters.Count(e => e.SourceID == id) > 0;
        }
    }
}