
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
    public class VendorMasterController : ApiController
    {
        private PMP.PMPEntities db = new PMP.PMPEntities();

        public IQueryable<VendorMasterDTO> GetVendorMasters(int pageSize = 10
                        ,System.Int32? ExpenseTypeID = null
                        ,System.Int32? CreatedBy = null
                        ,System.Int32? ModifiedBy = null
                )
        {
            var model = db.VendorMasters.AsQueryable();
                                if(ExpenseTypeID != null){
                        model = model.Where(m=> m.ExpenseTypeID == ExpenseTypeID.Value);
                    }
                                if(CreatedBy != null){
                        model = model.Where(m=> m.CreatedBy == CreatedBy.Value);
                    }
                                if(ModifiedBy != null){
                        model = model.Where(m=> m.ModifiedBy == ModifiedBy.Value);
                    }
                        
            return model.Select(VendorMasterDTO.SELECT).Take(pageSize);
        }

        [ResponseType(typeof(VendorMasterDTO))]
        public async Task<IHttpActionResult> GetVendorMaster(int id)
        {
            var model = await db.VendorMasters.Select(VendorMasterDTO.SELECT).FirstOrDefaultAsync(x => x.VendorID == id);
            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        public async Task<IHttpActionResult> PutVendorMaster(int id, VendorMaster model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != model.VendorID)
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
                if (!VendorMasterExists(id))
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

        [ResponseType(typeof(VendorMasterDTO))]
        public async Task<IHttpActionResult> PostVendorMaster(VendorMaster model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.VendorMasters.Add(model);
            await db.SaveChangesAsync();
            var ret = await db.VendorMasters.Select(VendorMasterDTO.SELECT).FirstOrDefaultAsync(x => x.VendorID == model.VendorID);
            return CreatedAtRoute("DefaultApi", new { id = model.VendorID }, model);
        }

        [ResponseType(typeof(VendorMasterDTO))]
        public async Task<IHttpActionResult> DeleteVendorMaster(int id)
        {
            VendorMaster model = await db.VendorMasters.FindAsync(id);
            if (model == null)
            {
                return NotFound();
            }

            db.VendorMasters.Remove(model);
            await db.SaveChangesAsync();
            var ret = await db.VendorMasters.Select(VendorMasterDTO.SELECT).FirstOrDefaultAsync(x => x.VendorID == model.VendorID);
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

        private bool VendorMasterExists(int id)
        {
            return db.VendorMasters.Count(e => e.VendorID == id) > 0;
        }
    }
}