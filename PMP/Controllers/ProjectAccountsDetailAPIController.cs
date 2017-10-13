
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
    public class ProjectAccountsDetailController : ApiController
    {
        private PMP.PMPEntities db = new PMP.PMPEntities();

        public IQueryable<ProjectAccountsDetailDTO> GetProjectAccountsDetails(int pageSize = 10
                        ,System.Int32? ProjectID = null
                        ,System.Int32? CurrencyID = null
                        ,System.Int32? CreatedBy = null
                        ,System.Int32? ModifiedBy = null
                )
        {
            var model = db.ProjectAccountsDetails.AsQueryable();
                                if(ProjectID != null){
                        model = model.Where(m=> m.ProjectID == ProjectID.Value);
                    }
                                if(CurrencyID != null){
                        model = model.Where(m=> m.CurrencyID == CurrencyID.Value);
                    }
                                if(CreatedBy != null){
                        model = model.Where(m=> m.CreatedBy == CreatedBy.Value);
                    }
                                if(ModifiedBy != null){
                        model = model.Where(m=> m.ModifiedBy == ModifiedBy.Value);
                    }
                        
            return model.Select(ProjectAccountsDetailDTO.SELECT).Take(pageSize);
        }

        [ResponseType(typeof(ProjectAccountsDetailDTO))]
        public async Task<IHttpActionResult> GetProjectAccountsDetail(int id)
        {
            var model = await db.ProjectAccountsDetails.Select(ProjectAccountsDetailDTO.SELECT).FirstOrDefaultAsync(x => x.ProjectAccountingID == id);
            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        public async Task<IHttpActionResult> PutProjectAccountsDetail(int id, ProjectAccountsDetail model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != model.ProjectAccountingID)
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
                if (!ProjectAccountsDetailExists(id))
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

        [ResponseType(typeof(ProjectAccountsDetailDTO))]
        public async Task<IHttpActionResult> PostProjectAccountsDetail(ProjectAccountsDetail model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ProjectAccountsDetails.Add(model);
            await db.SaveChangesAsync();
            var ret = await db.ProjectAccountsDetails.Select(ProjectAccountsDetailDTO.SELECT).FirstOrDefaultAsync(x => x.ProjectAccountingID == model.ProjectAccountingID);
            return CreatedAtRoute("DefaultApi", new { id = model.ProjectAccountingID }, model);
        }

        [ResponseType(typeof(ProjectAccountsDetailDTO))]
        public async Task<IHttpActionResult> DeleteProjectAccountsDetail(int id)
        {
            ProjectAccountsDetail model = await db.ProjectAccountsDetails.FindAsync(id);
            if (model == null)
            {
                return NotFound();
            }

            db.ProjectAccountsDetails.Remove(model);
            await db.SaveChangesAsync();
            var ret = await db.ProjectAccountsDetails.Select(ProjectAccountsDetailDTO.SELECT).FirstOrDefaultAsync(x => x.ProjectAccountingID == model.ProjectAccountingID);
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

        private bool ProjectAccountsDetailExists(int id)
        {
            return db.ProjectAccountsDetails.Count(e => e.ProjectAccountingID == id) > 0;
        }
    }
}