
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
    public class ProjectDetailController : ApiController
    {
        private PMP.PMPEntities db = new PMP.PMPEntities();

        public IQueryable<ProjectDetailDTO> GetProjectDetails(int pageSize = 10
                        ,System.Int32? TokenID = null
                        ,System.Int32? IndustryID = null
                        ,System.Int32? ClientID = null
                        ,System.Int32? ProductCatID = null
                        ,System.Int32? BrandID = null
                        ,System.Int32? ManagerID = null
                        ,System.Int32? CreatedBy = null
                        ,System.Int32? ModifiedBy = null
                )
        {
            var model = db.ProjectDetails.AsQueryable();
                                if(TokenID != null){
                        model = model.Where(m=> m.TokenID == TokenID.Value);
                    }
                                if(IndustryID != null){
                        model = model.Where(m=> m.IndustryID == IndustryID.Value);
                    }
                                if(ClientID != null){
                        model = model.Where(m=> m.ClientID == ClientID.Value);
                    }
                                if(ProductCatID != null){
                        model = model.Where(m=> m.ProductCatID == ProductCatID.Value);
                    }
                                if(BrandID != null){
                        model = model.Where(m=> m.BrandID == BrandID.Value);
                    }
                                if(ManagerID != null){
                        model = model.Where(m=> m.ManagerID == ManagerID.Value);
                    }
                                if(CreatedBy != null){
                        model = model.Where(m=> m.CreatedBy == CreatedBy.Value);
                    }
                                if(ModifiedBy != null){
                        model = model.Where(m=> m.ModifiedBy == ModifiedBy.Value);
                    }
                        
            return model.Select(ProjectDetailDTO.SELECT).Take(pageSize);
        }

        [ResponseType(typeof(ProjectDetailDTO))]
        public async Task<IHttpActionResult> GetProjectDetail(int id)
        {
            var model = await db.ProjectDetails.Select(ProjectDetailDTO.SELECT).FirstOrDefaultAsync(x => x.ProjectID == id);
            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        public async Task<IHttpActionResult> PutProjectDetail(int id, ProjectDetail model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != model.ProjectID)
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
                if (!ProjectDetailExists(id))
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

        [ResponseType(typeof(ProjectDetailDTO))]
        public async Task<IHttpActionResult> PostProjectDetail(ProjectDetail model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ProjectDetails.Add(model);
            await db.SaveChangesAsync();
            var ret = await db.ProjectDetails.Select(ProjectDetailDTO.SELECT).FirstOrDefaultAsync(x => x.ProjectID == model.ProjectID);
            return CreatedAtRoute("DefaultApi", new { id = model.ProjectID }, model);
        }

        [ResponseType(typeof(ProjectDetailDTO))]
        public async Task<IHttpActionResult> DeleteProjectDetail(int id)
        {
            ProjectDetail model = await db.ProjectDetails.FindAsync(id);
            if (model == null)
            {
                return NotFound();
            }

            db.ProjectDetails.Remove(model);
            await db.SaveChangesAsync();
            var ret = await db.ProjectDetails.Select(ProjectDetailDTO.SELECT).FirstOrDefaultAsync(x => x.ProjectID == model.ProjectID);
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

        private bool ProjectDetailExists(int id)
        {
            return db.ProjectDetails.Count(e => e.ProjectID == id) > 0;
        }
    }
}