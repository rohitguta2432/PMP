
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
    public class TaskStatusLogController : ApiController
    {
        private PMP.PMPEntities db = new PMP.PMPEntities();

        public IQueryable<TaskStatusLogDTO> GetTaskStatusLogs(int pageSize = 10
                        ,System.Int32? CurrentStatusID = null
                        ,System.Int32? TaskAssignmentID = null
                        ,System.Int32? CreatedBy = null
                        ,System.Int32? ModifiedBy = null
                )
        {
            var model = db.TaskStatusLogs.AsQueryable();
                                if(CurrentStatusID != null){
                        model = model.Where(m=> m.CurrentStatusID == CurrentStatusID.Value);
                    }
                                if(TaskAssignmentID != null){
                        model = model.Where(m=> m.TaskAssignmentID == TaskAssignmentID.Value);
                    }
                                if(CreatedBy != null){
                        model = model.Where(m=> m.CreatedBy == CreatedBy.Value);
                    }
                                if(ModifiedBy != null){
                        model = model.Where(m=> m.ModifiedBy == ModifiedBy.Value);
                    }
                        
            return model.Select(TaskStatusLogDTO.SELECT).Take(pageSize);
        }

        [ResponseType(typeof(TaskStatusLogDTO))]
        public async Task<IHttpActionResult> GetTaskStatusLog(int id)
        {
            var model = await db.TaskStatusLogs.Select(TaskStatusLogDTO.SELECT).FirstOrDefaultAsync(x => x.TaskStatusLogID == id);
            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        public async Task<IHttpActionResult> PutTaskStatusLog(int id, TaskStatusLog model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != model.TaskStatusLogID)
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
                if (!TaskStatusLogExists(id))
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

        [ResponseType(typeof(TaskStatusLogDTO))]
        public async Task<IHttpActionResult> PostTaskStatusLog(TaskStatusLog model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TaskStatusLogs.Add(model);
            await db.SaveChangesAsync();
            var ret = await db.TaskStatusLogs.Select(TaskStatusLogDTO.SELECT).FirstOrDefaultAsync(x => x.TaskStatusLogID == model.TaskStatusLogID);
            return CreatedAtRoute("DefaultApi", new { id = model.TaskStatusLogID }, model);
        }

        [ResponseType(typeof(TaskStatusLogDTO))]
        public async Task<IHttpActionResult> DeleteTaskStatusLog(int id)
        {
            TaskStatusLog model = await db.TaskStatusLogs.FindAsync(id);
            if (model == null)
            {
                return NotFound();
            }

            db.TaskStatusLogs.Remove(model);
            await db.SaveChangesAsync();
            var ret = await db.TaskStatusLogs.Select(TaskStatusLogDTO.SELECT).FirstOrDefaultAsync(x => x.TaskStatusLogID == model.TaskStatusLogID);
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

        private bool TaskStatusLogExists(int id)
        {
            return db.TaskStatusLogs.Count(e => e.TaskStatusLogID == id) > 0;
        }
    }
}