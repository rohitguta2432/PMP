
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
    public class PhaseExpenseDetailController : ApiController
    {
        private PMP.PMPEntities db = new PMP.PMPEntities();

        public IQueryable<PhaseExpenseDetailDTO> GetPhaseExpenseDetails(int pageSize = 10
                        ,System.Int32? ExpenseHeadID = null
                        ,System.Int32? ExpenseTypeID = null
                        ,System.Int32? VendorID = null
                        ,System.Int32? ExpenseID = null
                        ,System.Int32? CreatedBy = null
                        ,System.Int32? ModifiedBy = null
                )
        {
            var model = db.PhaseExpenseDetails.AsQueryable();
                                if(ExpenseHeadID != null){
                        model = model.Where(m=> m.ExpenseHeadID == ExpenseHeadID.Value);
                    }
                                if(ExpenseTypeID != null){
                        model = model.Where(m=> m.ExpenseTypeID == ExpenseTypeID.Value);
                    }
                                if(VendorID != null){
                        model = model.Where(m=> m.VendorID == VendorID.Value);
                    }
                                if(ExpenseID != null){
                        model = model.Where(m=> m.ExpenseID == ExpenseID.Value);
                    }
                                if(CreatedBy != null){
                        model = model.Where(m=> m.CreatedBy == CreatedBy.Value);
                    }
                                if(ModifiedBy != null){
                        model = model.Where(m=> m.ModifiedBy == ModifiedBy.Value);
                    }
                        
            return model.Select(PhaseExpenseDetailDTO.SELECT).Take(pageSize);
        }

        [ResponseType(typeof(PhaseExpenseDetailDTO))]
        public async Task<IHttpActionResult> GetPhaseExpenseDetail(int id)
        {
            var model = await db.PhaseExpenseDetails.Select(PhaseExpenseDetailDTO.SELECT).FirstOrDefaultAsync(x => x.PhaseExpenseID == id);
            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        public async Task<IHttpActionResult> PutPhaseExpenseDetail(int id, PhaseExpenseDetail model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != model.PhaseExpenseID)
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
                if (!PhaseExpenseDetailExists(id))
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

        [ResponseType(typeof(PhaseExpenseDetailDTO))]
        public async Task<IHttpActionResult> PostPhaseExpenseDetail(PhaseExpenseDetail model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PhaseExpenseDetails.Add(model);
            await db.SaveChangesAsync();
            var ret = await db.PhaseExpenseDetails.Select(PhaseExpenseDetailDTO.SELECT).FirstOrDefaultAsync(x => x.PhaseExpenseID == model.PhaseExpenseID);
            return CreatedAtRoute("DefaultApi", new { id = model.PhaseExpenseID }, model);
        }

        [ResponseType(typeof(PhaseExpenseDetailDTO))]
        public async Task<IHttpActionResult> DeletePhaseExpenseDetail(int id)
        {
            PhaseExpenseDetail model = await db.PhaseExpenseDetails.FindAsync(id);
            if (model == null)
            {
                return NotFound();
            }

            db.PhaseExpenseDetails.Remove(model);
            await db.SaveChangesAsync();
            var ret = await db.PhaseExpenseDetails.Select(PhaseExpenseDetailDTO.SELECT).FirstOrDefaultAsync(x => x.PhaseExpenseID == model.PhaseExpenseID);
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

        private bool PhaseExpenseDetailExists(int id)
        {
            return db.PhaseExpenseDetails.Count(e => e.PhaseExpenseID == id) > 0;
        }
    }
}