
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
    public class TeamContribDetailController : ApiController
    {
        private PMP.PMPEntities db = new PMP.PMPEntities();

        public IQueryable<TeamContribDetailDTO> GetTeamContribDetails(int pageSize = 10
                        ,System.Int32? TaskAssignmentID = null
                        ,System.Int32? EmployeeID = null
                        ,System.Int32? CreatedBy = null
                        ,System.Int32? ModifiedBy = null
                )
        {
            var model = db.TeamContribDetails.AsQueryable();
                                if(TaskAssignmentID != null){
                        model = model.Where(m=> m.TaskAssignmentID == TaskAssignmentID.Value);
                    }
                                if(EmployeeID != null){
                        model = model.Where(m=> m.EmployeeID == EmployeeID.Value);
                    }
                                if(CreatedBy != null){
                        model = model.Where(m=> m.CreatedBy == CreatedBy.Value);
                    }
                                if(ModifiedBy != null){
                        model = model.Where(m=> m.ModifiedBy == ModifiedBy.Value);
                    }
                        
            return model.Select(TeamContribDetailDTO.SELECT).Take(pageSize);
        }

        [ResponseType(typeof(TeamContribDetailDTO))]
        public async Task<IHttpActionResult> GetTeamContribDetail(int id)
        {
            var model = await db.TeamContribDetails.Select(TeamContribDetailDTO.SELECT).FirstOrDefaultAsync(x => x.TeamContribID == id);
            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        public async Task<IHttpActionResult> PutTeamContribDetail(int id, TeamContribDetail model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != model.TeamContribID)
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
                if (!TeamContribDetailExists(id))
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

        [ResponseType(typeof(TeamContribDetailDTO))]
        public async Task<IHttpActionResult> PostTeamContribDetail(TeamContribDetail model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TeamContribDetails.Add(model);
            await db.SaveChangesAsync();
            var ret = await db.TeamContribDetails.Select(TeamContribDetailDTO.SELECT).FirstOrDefaultAsync(x => x.TeamContribID == model.TeamContribID);
            return CreatedAtRoute("DefaultApi", new { id = model.TeamContribID }, model);
        }

        [ResponseType(typeof(TeamContribDetailDTO))]
        public async Task<IHttpActionResult> DeleteTeamContribDetail(int id)
        {
            TeamContribDetail model = await db.TeamContribDetails.FindAsync(id);
            if (model == null)
            {
                return NotFound();
            }

            db.TeamContribDetails.Remove(model);
            await db.SaveChangesAsync();
            var ret = await db.TeamContribDetails.Select(TeamContribDetailDTO.SELECT).FirstOrDefaultAsync(x => x.TeamContribID == model.TeamContribID);
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

        private bool TeamContribDetailExists(int id)
        {
            return db.TeamContribDetails.Count(e => e.TeamContribID == id) > 0;
        }
    }
}