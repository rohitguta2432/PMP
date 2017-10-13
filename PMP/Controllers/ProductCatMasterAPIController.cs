
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
    public class ProductCatMasterController : ApiController
    {
        private PMP.PMPEntities db = new PMP.PMPEntities();

        public IQueryable<ProductCatMasterDTO> GetProductCatMasters(int pageSize = 10
                        ,System.Int32? CreatedBy = null
                        ,System.Int32? ModifiedBy = null
                )
        {
            var model = db.ProductCatMasters.AsQueryable();
                                if(CreatedBy != null){
                        model = model.Where(m=> m.CreatedBy == CreatedBy.Value);
                    }
                                if(ModifiedBy != null){
                        model = model.Where(m=> m.ModifiedBy == ModifiedBy.Value);
                    }
                        
            return model.Select(ProductCatMasterDTO.SELECT).Take(pageSize);
        }

        [ResponseType(typeof(ProductCatMasterDTO))]
        public async Task<IHttpActionResult> GetProductCatMaster(int id)
        {
            var model = await db.ProductCatMasters.Select(ProductCatMasterDTO.SELECT).FirstOrDefaultAsync(x => x.ProductCatID == id);
            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        public async Task<IHttpActionResult> PutProductCatMaster(int id, ProductCatMaster model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != model.ProductCatID)
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
                if (!ProductCatMasterExists(id))
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

        [ResponseType(typeof(ProductCatMasterDTO))]
        public async Task<IHttpActionResult> PostProductCatMaster(ProductCatMaster model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ProductCatMasters.Add(model);
            await db.SaveChangesAsync();
            var ret = await db.ProductCatMasters.Select(ProductCatMasterDTO.SELECT).FirstOrDefaultAsync(x => x.ProductCatID == model.ProductCatID);
            return CreatedAtRoute("DefaultApi", new { id = model.ProductCatID }, model);
        }

        [ResponseType(typeof(ProductCatMasterDTO))]
        public async Task<IHttpActionResult> DeleteProductCatMaster(int id)
        {
            ProductCatMaster model = await db.ProductCatMasters.FindAsync(id);
            if (model == null)
            {
                return NotFound();
            }

            db.ProductCatMasters.Remove(model);
            await db.SaveChangesAsync();
            var ret = await db.ProductCatMasters.Select(ProductCatMasterDTO.SELECT).FirstOrDefaultAsync(x => x.ProductCatID == model.ProductCatID);
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

        private bool ProductCatMasterExists(int id)
        {
            return db.ProductCatMasters.Count(e => e.ProductCatID == id) > 0;
        }
    }
}