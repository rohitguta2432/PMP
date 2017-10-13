
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
    public class InitialProjectController : ApiController
    {
        private PMP.PMPEntities db = new PMP.PMPEntities();

        public IQueryable<InitialProjectDTO> GetInitialProjects(int pageSize = 10
                        ,System.Int32? TokenID = null
                        ,System.Int32? DocumentID = null
                        ,System.Int32? CreatedBy = null
                        ,System.Int32? ModifiedBy = null
                )
        {
            var model = db.InitialProjects.AsQueryable();
                                if(TokenID != null){
                        model = model.Where(m=> m.TokenID == TokenID.Value);
                    }
                                if(DocumentID != null){
                        model = model.Where(m=> m.DocumentID == DocumentID.Value);
                    }
                                if(CreatedBy != null){
                        model = model.Where(m=> m.CreatedBy == CreatedBy.Value);
                    }
                                if(ModifiedBy != null){
                        model = model.Where(m=> m.ModifiedBy == ModifiedBy.Value);
                    }
                        
            return model.Select(InitialProjectDTO.SELECT).Take(pageSize);
        }

        [ResponseType(typeof(InitialProjectDTO))]
        public async Task<IHttpActionResult> GetInitialProject(int id)
        {
            var model = await db.InitialProjects.Select(InitialProjectDTO.SELECT).FirstOrDefaultAsync(x => x.IPUID == id);
            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        public async Task<IHttpActionResult> PutInitialProject(int id, InitialProject model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != model.IPUID)
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
                if (!InitialProjectExists(id))
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

        [ResponseType(typeof(InitialProjectDTO))]
        public async Task<IHttpActionResult> PostInitialProject(InitialProject model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.InitialProjects.Add(model);
            await db.SaveChangesAsync();
            var ret = await db.InitialProjects.Select(InitialProjectDTO.SELECT).FirstOrDefaultAsync(x => x.IPUID == model.IPUID);
            return CreatedAtRoute("DefaultApi", new { id = model.IPUID }, model);
        }

        [ResponseType(typeof(InitialProjectDTO))]
        public async Task<IHttpActionResult> DeleteInitialProject(int id)
        {
            InitialProject model = await db.InitialProjects.FindAsync(id);
            if (model == null)
            {
                return NotFound();
            }

            db.InitialProjects.Remove(model);
            await db.SaveChangesAsync();
            var ret = await db.InitialProjects.Select(InitialProjectDTO.SELECT).FirstOrDefaultAsync(x => x.IPUID == model.IPUID);
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

        private bool InitialProjectExists(int id)
        {
            return db.InitialProjects.Count(e => e.IPUID == id) > 0;
        }
    }
}