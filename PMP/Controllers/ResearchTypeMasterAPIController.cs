
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
    public class ResearchTypeMasterController : ApiController
    {
        private PMP.PMPEntities db = new PMP.PMPEntities();

        public IQueryable<ResearchTypeMasterDTO> GetResearchTypeMasters(int pageSize = 10
                        ,System.Int32? CreatedBy = null
                        ,System.Int32? ModifiedBy = null
                )
        {
            var model = db.ResearchTypeMasters.AsQueryable();
                                if(CreatedBy != null){
                        model = model.Where(m=> m.CreatedBy == CreatedBy.Value);
                    }
                                if(ModifiedBy != null){
                        model = model.Where(m=> m.ModifiedBy == ModifiedBy.Value);
                    }
                        
            return model.Select(ResearchTypeMasterDTO.SELECT).Take(pageSize);
        }

        [ResponseType(typeof(ResearchTypeMasterDTO))]
        public async Task<IHttpActionResult> GetResearchTypeMaster(int id)
        {
            var model = await db.ResearchTypeMasters.Select(ResearchTypeMasterDTO.SELECT).FirstOrDefaultAsync(x => x.ResearchTypeID == id);
            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        public async Task<IHttpActionResult> PutResearchTypeMaster(int id, ResearchTypeMaster model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != model.ResearchTypeID)
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
                if (!ResearchTypeMasterExists(id))
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

        [ResponseType(typeof(ResearchTypeMasterDTO))]
        public async Task<IHttpActionResult> PostResearchTypeMaster(ResearchTypeMaster model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ResearchTypeMasters.Add(model);
            await db.SaveChangesAsync();
            var ret = await db.ResearchTypeMasters.Select(ResearchTypeMasterDTO.SELECT).FirstOrDefaultAsync(x => x.ResearchTypeID == model.ResearchTypeID);
            return CreatedAtRoute("DefaultApi", new { id = model.ResearchTypeID }, model);
        }

        [ResponseType(typeof(ResearchTypeMasterDTO))]
        public async Task<IHttpActionResult> DeleteResearchTypeMaster(int id)
        {
            ResearchTypeMaster model = await db.ResearchTypeMasters.FindAsync(id);
            if (model == null)
            {
                return NotFound();
            }

            db.ResearchTypeMasters.Remove(model);
            await db.SaveChangesAsync();
            var ret = await db.ResearchTypeMasters.Select(ResearchTypeMasterDTO.SELECT).FirstOrDefaultAsync(x => x.ResearchTypeID == model.ResearchTypeID);
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

        private bool ResearchTypeMasterExists(int id)
        {
            return db.ResearchTypeMasters.Count(e => e.ResearchTypeID == id) > 0;
        }
    }
}