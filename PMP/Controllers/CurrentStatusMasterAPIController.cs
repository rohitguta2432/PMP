
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
    public class CurrentStatusMasterController : ApiController
    {
        private PMP.PMPEntities db = new PMP.PMPEntities();

        public IQueryable<CurrentStatusMasterDTO> GetCurrentStatusMasters(int pageSize = 10
                        ,System.Int32? CreatedBy = null
                        ,System.Int32? ModifiedBy = null
                )
        {
            var model = db.CurrentStatusMasters.AsQueryable();
                                if(CreatedBy != null){
                        model = model.Where(m=> m.CreatedBy == CreatedBy.Value);
                    }
                                if(ModifiedBy != null){
                        model = model.Where(m=> m.ModifiedBy == ModifiedBy.Value);
                    }
                        
            return model.Select(CurrentStatusMasterDTO.SELECT).Take(pageSize);
        }

        [ResponseType(typeof(CurrentStatusMasterDTO))]
        public async Task<IHttpActionResult> GetCurrentStatusMaster(int id)
        {
            var model = await db.CurrentStatusMasters.Select(CurrentStatusMasterDTO.SELECT).FirstOrDefaultAsync(x => x.CurrentStatusID == id);
            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        public async Task<IHttpActionResult> PutCurrentStatusMaster(int id, CurrentStatusMaster model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != model.CurrentStatusID)
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
                if (!CurrentStatusMasterExists(id))
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

        [ResponseType(typeof(CurrentStatusMasterDTO))]
        public async Task<IHttpActionResult> PostCurrentStatusMaster(CurrentStatusMaster model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CurrentStatusMasters.Add(model);
            await db.SaveChangesAsync();
            var ret = await db.CurrentStatusMasters.Select(CurrentStatusMasterDTO.SELECT).FirstOrDefaultAsync(x => x.CurrentStatusID == model.CurrentStatusID);
            return CreatedAtRoute("DefaultApi", new { id = model.CurrentStatusID }, model);
        }

        [ResponseType(typeof(CurrentStatusMasterDTO))]
        public async Task<IHttpActionResult> DeleteCurrentStatusMaster(int id)
        {
            CurrentStatusMaster model = await db.CurrentStatusMasters.FindAsync(id);
            if (model == null)
            {
                return NotFound();
            }

            db.CurrentStatusMasters.Remove(model);
            await db.SaveChangesAsync();
            var ret = await db.CurrentStatusMasters.Select(CurrentStatusMasterDTO.SELECT).FirstOrDefaultAsync(x => x.CurrentStatusID == model.CurrentStatusID);
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

        private bool CurrentStatusMasterExists(int id)
        {
            return db.CurrentStatusMasters.Count(e => e.CurrentStatusID == id) > 0;
        }
    }
}