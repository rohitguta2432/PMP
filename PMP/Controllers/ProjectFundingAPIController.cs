
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
    public class ProjectFundingController : ApiController
    {
        private PMP.PMPEntities db = new PMP.PMPEntities();

        public IQueryable<ProjectFundingDTO> GetProjectFundings(int pageSize = 10
                        ,System.Int32? ProjectAccountID = null
                        ,System.Int32? CreatedBy = null
                        ,System.Int32? ModifiedBy = null
                )
        {
            var model = db.ProjectFundings.AsQueryable();
                                if(ProjectAccountID != null){
                        model = model.Where(m=> m.ProjectAccountID == ProjectAccountID.Value);
                    }
                                if(CreatedBy != null){
                        model = model.Where(m=> m.CreatedBy == CreatedBy.Value);
                    }
                                if(ModifiedBy != null){
                        model = model.Where(m=> m.ModifiedBy == ModifiedBy.Value);
                    }
                        
            return model.Select(ProjectFundingDTO.SELECT).Take(pageSize);
        }

        [ResponseType(typeof(ProjectFundingDTO))]
        public async Task<IHttpActionResult> GetProjectFunding(int id)
        {
            var model = await db.ProjectFundings.Select(ProjectFundingDTO.SELECT).FirstOrDefaultAsync(x => x.FundID == id);
            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        public async Task<IHttpActionResult> PutProjectFunding(int id, ProjectFunding model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != model.FundID)
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
                if (!ProjectFundingExists(id))
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

        [ResponseType(typeof(ProjectFundingDTO))]
        public async Task<IHttpActionResult> PostProjectFunding(ProjectFunding model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ProjectFundings.Add(model);
            await db.SaveChangesAsync();
            var ret = await db.ProjectFundings.Select(ProjectFundingDTO.SELECT).FirstOrDefaultAsync(x => x.FundID == model.FundID);
            return CreatedAtRoute("DefaultApi", new { id = model.FundID }, model);
        }

        [ResponseType(typeof(ProjectFundingDTO))]
        public async Task<IHttpActionResult> DeleteProjectFunding(int id)
        {
            ProjectFunding model = await db.ProjectFundings.FindAsync(id);
            if (model == null)
            {
                return NotFound();
            }

            db.ProjectFundings.Remove(model);
            await db.SaveChangesAsync();
            var ret = await db.ProjectFundings.Select(ProjectFundingDTO.SELECT).FirstOrDefaultAsync(x => x.FundID == model.FundID);
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

        private bool ProjectFundingExists(int id)
        {
            return db.ProjectFundings.Count(e => e.FundID == id) > 0;
        }
    }
}