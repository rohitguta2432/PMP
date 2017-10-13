
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
    public class PageRulesMasterController : ApiController
    {
        private PMP.PMPEntities db = new PMP.PMPEntities();

        public IQueryable<PageRulesMasterDTO> GetPageRulesMasters(int pageSize = 10
                        ,System.Int32? CreatedBy = null
                        ,System.Int32? ModifiedBy = null
                )
        {
            var model = db.PageRulesMasters.AsQueryable();
                                if(CreatedBy != null){
                        model = model.Where(m=> m.CreatedBy == CreatedBy.Value);
                    }
                                if(ModifiedBy != null){
                        model = model.Where(m=> m.ModifiedBy == ModifiedBy.Value);
                    }
                        
            return model.Select(PageRulesMasterDTO.SELECT).Take(pageSize);
        }

        [ResponseType(typeof(PageRulesMasterDTO))]
        public async Task<IHttpActionResult> GetPageRulesMaster(int id)
        {
            var model = await db.PageRulesMasters.Select(PageRulesMasterDTO.SELECT).FirstOrDefaultAsync(x => x.PageID == id);
            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        public async Task<IHttpActionResult> PutPageRulesMaster(int id, PageRulesMaster model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != model.PageID)
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
                if (!PageRulesMasterExists(id))
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

        [ResponseType(typeof(PageRulesMasterDTO))]
        public async Task<IHttpActionResult> PostPageRulesMaster(PageRulesMaster model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PageRulesMasters.Add(model);
            await db.SaveChangesAsync();
            var ret = await db.PageRulesMasters.Select(PageRulesMasterDTO.SELECT).FirstOrDefaultAsync(x => x.PageID == model.PageID);
            return CreatedAtRoute("DefaultApi", new { id = model.PageID }, model);
        }

        [ResponseType(typeof(PageRulesMasterDTO))]
        public async Task<IHttpActionResult> DeletePageRulesMaster(int id)
        {
            PageRulesMaster model = await db.PageRulesMasters.FindAsync(id);
            if (model == null)
            {
                return NotFound();
            }

            db.PageRulesMasters.Remove(model);
            await db.SaveChangesAsync();
            var ret = await db.PageRulesMasters.Select(PageRulesMasterDTO.SELECT).FirstOrDefaultAsync(x => x.PageID == model.PageID);
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

        private bool PageRulesMasterExists(int id)
        {
            return db.PageRulesMasters.Count(e => e.PageID == id) > 0;
        }
    }
}