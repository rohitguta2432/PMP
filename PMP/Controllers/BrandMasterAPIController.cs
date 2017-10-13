
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
    public class BrandMasterController : ApiController
    {
        private PMP.PMPEntities db = new PMP.PMPEntities();

        public IQueryable<BrandMasterDTO> GetBrandMasters(int pageSize = 10
                        ,System.Int32? CreatedBy = null
                        ,System.Int32? ModifiedBy = null
                )
        {
            var model = db.BrandMasters.AsQueryable();
                                if(CreatedBy != null){
                        model = model.Where(m=> m.CreatedBy == CreatedBy.Value);
                    }
                                if(ModifiedBy != null){
                        model = model.Where(m=> m.ModifiedBy == ModifiedBy.Value);
                    }
                        
            return model.Select(BrandMasterDTO.SELECT).Take(pageSize);
        }

        [ResponseType(typeof(BrandMasterDTO))]
        public async Task<IHttpActionResult> GetBrandMaster(int id)
        {
            var model = await db.BrandMasters.Select(BrandMasterDTO.SELECT).FirstOrDefaultAsync(x => x.BrandID == id);
            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        public async Task<IHttpActionResult> PutBrandMaster(int id, BrandMaster model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != model.BrandID)
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
                if (!BrandMasterExists(id))
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

        [ResponseType(typeof(BrandMasterDTO))]
        public async Task<IHttpActionResult> PostBrandMaster(BrandMaster model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.BrandMasters.Add(model);
            await db.SaveChangesAsync();
            var ret = await db.BrandMasters.Select(BrandMasterDTO.SELECT).FirstOrDefaultAsync(x => x.BrandID == model.BrandID);
            return CreatedAtRoute("DefaultApi", new { id = model.BrandID }, model);
        }

        [ResponseType(typeof(BrandMasterDTO))]
        public async Task<IHttpActionResult> DeleteBrandMaster(int id)
        {
            BrandMaster model = await db.BrandMasters.FindAsync(id);
            if (model == null)
            {
                return NotFound();
            }

            db.BrandMasters.Remove(model);
            await db.SaveChangesAsync();
            var ret = await db.BrandMasters.Select(BrandMasterDTO.SELECT).FirstOrDefaultAsync(x => x.BrandID == model.BrandID);
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

        private bool BrandMasterExists(int id)
        {
            return db.BrandMasters.Count(e => e.BrandID == id) > 0;
        }
    }
}