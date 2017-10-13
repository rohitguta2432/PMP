
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
    public class TaskPriorityMasterController : ApiController
    {
        private PMP.PMPEntities db = new PMP.PMPEntities();

        public IQueryable<TaskPriorityMasterDTO> GetTaskPriorityMasters(int pageSize = 10
                        ,System.Int32? CreatedBy = null
                        ,System.Int32? ModifiedBy = null
                )
        {
            var model = db.TaskPriorityMasters.AsQueryable();
                                if(CreatedBy != null){
                        model = model.Where(m=> m.CreatedBy == CreatedBy.Value);
                    }
                                if(ModifiedBy != null){
                        model = model.Where(m=> m.ModifiedBy == ModifiedBy.Value);
                    }
                        
            return model.Select(TaskPriorityMasterDTO.SELECT).Take(pageSize);
        }

        [ResponseType(typeof(TaskPriorityMasterDTO))]
        public async Task<IHttpActionResult> GetTaskPriorityMaster(int id)
        {
            var model = await db.TaskPriorityMasters.Select(TaskPriorityMasterDTO.SELECT).FirstOrDefaultAsync(x => x.TaskPriorityID == id);
            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        public async Task<IHttpActionResult> PutTaskPriorityMaster(int id, TaskPriorityMaster model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != model.TaskPriorityID)
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
                if (!TaskPriorityMasterExists(id))
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

        [ResponseType(typeof(TaskPriorityMasterDTO))]
        public async Task<IHttpActionResult> PostTaskPriorityMaster(TaskPriorityMaster model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TaskPriorityMasters.Add(model);
            await db.SaveChangesAsync();
            var ret = await db.TaskPriorityMasters.Select(TaskPriorityMasterDTO.SELECT).FirstOrDefaultAsync(x => x.TaskPriorityID == model.TaskPriorityID);
            return CreatedAtRoute("DefaultApi", new { id = model.TaskPriorityID }, model);
        }

        [ResponseType(typeof(TaskPriorityMasterDTO))]
        public async Task<IHttpActionResult> DeleteTaskPriorityMaster(int id)
        {
            TaskPriorityMaster model = await db.TaskPriorityMasters.FindAsync(id);
            if (model == null)
            {
                return NotFound();
            }

            db.TaskPriorityMasters.Remove(model);
            await db.SaveChangesAsync();
            var ret = await db.TaskPriorityMasters.Select(TaskPriorityMasterDTO.SELECT).FirstOrDefaultAsync(x => x.TaskPriorityID == model.TaskPriorityID);
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

        private bool TaskPriorityMasterExists(int id)
        {
            return db.TaskPriorityMasters.Count(e => e.TaskPriorityID == id) > 0;
        }
    }
}