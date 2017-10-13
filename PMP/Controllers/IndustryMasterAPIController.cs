
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
    public class IndustryMasterController : ApiController
    {
        private PMP.PMPEntities db = new PMP.PMPEntities();

        public IQueryable<IndustryMasterDTO> GetIndustryMasters(int pageSize = 10
                        ,System.Int32? CreatedBy = null
                        ,System.Int32? ModifiedBy = null
                )
        {
            var model = db.IndustryMasters.AsQueryable();
                                if(CreatedBy != null){
                        model = model.Where(m=> m.CreatedBy == CreatedBy.Value);
                    }
                                if(ModifiedBy != null){
                        model = model.Where(m=> m.ModifiedBy == ModifiedBy.Value);
                    }
                        
            return model.Select(IndustryMasterDTO.SELECT).Take(pageSize);
        }

        [ResponseType(typeof(IndustryMasterDTO))]
        public async Task<IHttpActionResult> GetIndustryMaster(int id)
        {
            var model = await db.IndustryMasters.Select(IndustryMasterDTO.SELECT).FirstOrDefaultAsync(x => x.IndustryID == id);
            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        public async Task<IHttpActionResult> PutIndustryMaster(int id, IndustryMaster model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != model.IndustryID)
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
                if (!IndustryMasterExists(id))
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

        [ResponseType(typeof(IndustryMasterDTO))]
        public async Task<IHttpActionResult> PostIndustryMaster(IndustryMaster model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.IndustryMasters.Add(model);
            await db.SaveChangesAsync();
            var ret = await db.IndustryMasters.Select(IndustryMasterDTO.SELECT).FirstOrDefaultAsync(x => x.IndustryID == model.IndustryID);
            return CreatedAtRoute("DefaultApi", new { id = model.IndustryID }, model);
        }

        [ResponseType(typeof(IndustryMasterDTO))]
        public async Task<IHttpActionResult> DeleteIndustryMaster(int id)
        {
            IndustryMaster model = await db.IndustryMasters.FindAsync(id);
            if (model == null)
            {
                return NotFound();
            }

            db.IndustryMasters.Remove(model);
            await db.SaveChangesAsync();
            var ret = await db.IndustryMasters.Select(IndustryMasterDTO.SELECT).FirstOrDefaultAsync(x => x.IndustryID == model.IndustryID);
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

        private bool IndustryMasterExists(int id)
        {
            return db.IndustryMasters.Count(e => e.IndustryID == id) > 0;
        }
    }
}