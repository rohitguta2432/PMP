
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
    public class TaskMasterController : ApiController
    {
        private PMP.PMPEntities db = new PMP.PMPEntities();

        public IQueryable<TaskMasterDTO> GetTaskMasters(int pageSize = 10
                        , System.Int32? CreatedBy = null
                        , System.Int32? ModifiedBy = null
                        , System.Int32? StageID = null
                )
        {
            var model = db.TaskMasters.AsQueryable();
            if (CreatedBy != null)
            {
                model = model.Where(m => m.CreatedBy == CreatedBy.Value);
            }
            if (ModifiedBy != null)
            {
                model = model.Where(m => m.ModifiedBy == ModifiedBy.Value);
            }
            if (StageID != null)
            {
                model = model.Where(m => m.Stage == StageID.Value);
            }

            return model.Select(TaskMasterDTO.SELECT).Take(pageSize);
        }


        [ResponseType(typeof(TaskMasterDTO))]
        public async Task<IHttpActionResult> GetTaskMaster(int id)
        {
            var model = await db.TaskMasters.Select(TaskMasterDTO.SELECT).FirstOrDefaultAsync(x => x.TaskID == id);
            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        public async Task<IHttpActionResult> PutTaskMaster(int id, TaskMaster model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != model.TaskID)
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
                if (!TaskMasterExists(id))
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

        [ResponseType(typeof(TaskMasterDTO))]
        public async Task<IHttpActionResult> PostTaskMaster(TaskMaster model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TaskMasters.Add(model);
            await db.SaveChangesAsync();
            var ret = await db.TaskMasters.Select(TaskMasterDTO.SELECT).FirstOrDefaultAsync(x => x.TaskID == model.TaskID);
            return CreatedAtRoute("DefaultApi", new { id = model.TaskID }, model);
        }

        [ResponseType(typeof(TaskMasterDTO))]
        public async Task<IHttpActionResult> DeleteTaskMaster(int id)
        {
            TaskMaster model = await db.TaskMasters.FindAsync(id);
            if (model == null)
            {
                return NotFound();
            }

            db.TaskMasters.Remove(model);
            await db.SaveChangesAsync();
            var ret = await db.TaskMasters.Select(TaskMasterDTO.SELECT).FirstOrDefaultAsync(x => x.TaskID == model.TaskID);
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

        private bool TaskMasterExists(int id)
        {
            return db.TaskMasters.Count(e => e.TaskID == id) > 0;
        }
    }
}