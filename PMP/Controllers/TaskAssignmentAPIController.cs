
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
    public class TaskAssignmentController : ApiController
    {
        private PMP.PMPEntities db = new PMP.PMPEntities();

        public IQueryable<TaskAssignmentDTO> GetTaskAssignments(int pageSize = 10
                        ,System.Int32? TokenID = null
                        ,System.Int32? TaskID = null
                        ,System.Int32? TaskPriorityID = null
                        ,System.Int32? AssignedByID = null
                        ,System.Int32? OverallStatusID = null
                        ,System.Int32? CurrentStatusID = null
                        ,System.Int32? CreatedBy = null
                        ,System.Int32? ModifiedBy = null
                )
        {
            var model = db.TaskAssignments.AsQueryable();
                                if(TokenID != null){
                        model = model.Where(m=> m.TokenID == TokenID.Value);
                    }
                                if(TaskID != null){
                        model = model.Where(m=> m.TaskID == TaskID.Value);
                    }
                                if(TaskPriorityID != null){
                        model = model.Where(m=> m.TaskPriorityID == TaskPriorityID.Value);
                    }
                                if(AssignedByID != null){
                        model = model.Where(m=> m.AssignedByID == AssignedByID.Value);
                    }
                                if(OverallStatusID != null){
                        model = model.Where(m=> m.OverallStatusID == OverallStatusID.Value);
                    }
                                if(CurrentStatusID != null){
                        model = model.Where(m=> m.CurrentStatusID == CurrentStatusID.Value);
                    }
                                if(CreatedBy != null){
                        model = model.Where(m=> m.CreatedBy == CreatedBy.Value);
                    }
                                if(ModifiedBy != null){
                        model = model.Where(m=> m.ModifiedBy == ModifiedBy.Value);
                    }
                        
            return model.Select(TaskAssignmentDTO.SELECT).Take(pageSize);
        }

        [ResponseType(typeof(TaskAssignmentDTO))]
        public async Task<IHttpActionResult> GetTaskAssignment(int id)
        {
            var model = await db.TaskAssignments.Select(TaskAssignmentDTO.SELECT).FirstOrDefaultAsync(x => x.TaskAssignmentID == id);
            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        public async Task<IHttpActionResult> PutTaskAssignment(int id, TaskAssignment model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != model.TaskAssignmentID)
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
                if (!TaskAssignmentExists(id))
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

        [ResponseType(typeof(TaskAssignmentDTO))]
        public async Task<IHttpActionResult> PostTaskAssignment(TaskAssignment model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TaskAssignments.Add(model);
            await db.SaveChangesAsync();
            var ret = await db.TaskAssignments.Select(TaskAssignmentDTO.SELECT).FirstOrDefaultAsync(x => x.TaskAssignmentID == model.TaskAssignmentID);
            return CreatedAtRoute("DefaultApi", new { id = model.TaskAssignmentID }, model);
        }

        [ResponseType(typeof(TaskAssignmentDTO))]
        public async Task<IHttpActionResult> DeleteTaskAssignment(int id)
        {
            TaskAssignment model = await db.TaskAssignments.FindAsync(id);
            if (model == null)
            {
                return NotFound();
            }

            db.TaskAssignments.Remove(model);
            await db.SaveChangesAsync();
            var ret = await db.TaskAssignments.Select(TaskAssignmentDTO.SELECT).FirstOrDefaultAsync(x => x.TaskAssignmentID == model.TaskAssignmentID);
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

        private bool TaskAssignmentExists(int id)
        {
            return db.TaskAssignments.Count(e => e.TaskAssignmentID == id) > 0;
        }
    }
}