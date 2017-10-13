
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
    public class ProjectClosureDetailController : ApiController
    {
        private PMP.PMPEntities db = new PMP.PMPEntities();

        public IQueryable<ProjectClosureDetailDTO> GetProjectClosureDetails(int pageSize = 10
                        ,System.Int32? TokenID = null
                        ,System.Int32? DocumentID = null
                        ,System.Int32? CRPStatus = null
                        ,System.Int32? CreatedBy = null
                        ,System.Int32? ModifiedBy = null
                )
        {
            var model = db.ProjectClosureDetails.AsQueryable();
                                if(TokenID != null){
                        model = model.Where(m=> m.TokenID == TokenID.Value);
                    }
                                if(DocumentID != null){
                        model = model.Where(m=> m.DocumentID == DocumentID.Value);
                    }
                                if(CRPStatus != null){
                        model = model.Where(m=> m.CRPStatus == CRPStatus.Value);
                    }
                                if(CreatedBy != null){
                        model = model.Where(m=> m.CreatedBy == CreatedBy.Value);
                    }
                                if(ModifiedBy != null){
                        model = model.Where(m=> m.ModifiedBy == ModifiedBy.Value);
                    }
                        
            return model.Select(ProjectClosureDetailDTO.SELECT).Take(pageSize);
        }

        [ResponseType(typeof(ProjectClosureDetailDTO))]
        public async Task<IHttpActionResult> GetProjectClosureDetail(int id)
        {
            var model = await db.ProjectClosureDetails.Select(ProjectClosureDetailDTO.SELECT).FirstOrDefaultAsync(x => x.ProjectClosureID == id);
            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        public async Task<IHttpActionResult> PutProjectClosureDetail(int id, ProjectClosureDetail model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != model.ProjectClosureID)
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
                if (!ProjectClosureDetailExists(id))
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

        [ResponseType(typeof(ProjectClosureDetailDTO))]
        public async Task<IHttpActionResult> PostProjectClosureDetail(ProjectClosureDetail model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ProjectClosureDetails.Add(model);
            await db.SaveChangesAsync();
            var ret = await db.ProjectClosureDetails.Select(ProjectClosureDetailDTO.SELECT).FirstOrDefaultAsync(x => x.ProjectClosureID == model.ProjectClosureID);
            return CreatedAtRoute("DefaultApi", new { id = model.ProjectClosureID }, model);
        }

        [ResponseType(typeof(ProjectClosureDetailDTO))]
        public async Task<IHttpActionResult> DeleteProjectClosureDetail(int id)
        {
            ProjectClosureDetail model = await db.ProjectClosureDetails.FindAsync(id);
            if (model == null)
            {
                return NotFound();
            }

            db.ProjectClosureDetails.Remove(model);
            await db.SaveChangesAsync();
            var ret = await db.ProjectClosureDetails.Select(ProjectClosureDetailDTO.SELECT).FirstOrDefaultAsync(x => x.ProjectClosureID == model.ProjectClosureID);
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

        private bool ProjectClosureDetailExists(int id)
        {
            return db.ProjectClosureDetails.Count(e => e.ProjectClosureID == id) > 0;
        }
    }
}