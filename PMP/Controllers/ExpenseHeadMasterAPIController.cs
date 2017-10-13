
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
    public class ExpenseHeadMasterController : ApiController
    {
        private PMP.PMPEntities db = new PMP.PMPEntities();

        public IQueryable<ExpenseHeadMasterDTO> GetExpenseHeadMasters(int pageSize = 10
                        ,System.Int32? CreatedBy = null
                        ,System.Int32? ModifiedBy = null
                )
        {
            var model = db.ExpenseHeadMasters.AsQueryable();
                                if(CreatedBy != null){
                        model = model.Where(m=> m.CreatedBy == CreatedBy.Value);
                    }
                                if(ModifiedBy != null){
                        model = model.Where(m=> m.ModifiedBy == ModifiedBy.Value);
                    }
                        
            return model.Select(ExpenseHeadMasterDTO.SELECT).Take(pageSize);
        }

        [ResponseType(typeof(ExpenseHeadMasterDTO))]
        public async Task<IHttpActionResult> GetExpenseHeadMaster(int id)
        {
            var model = await db.ExpenseHeadMasters.Select(ExpenseHeadMasterDTO.SELECT).FirstOrDefaultAsync(x => x.ExpenseHeadID == id);
            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        public async Task<IHttpActionResult> PutExpenseHeadMaster(int id, ExpenseHeadMaster model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != model.ExpenseHeadID)
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
                if (!ExpenseHeadMasterExists(id))
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

        [ResponseType(typeof(ExpenseHeadMasterDTO))]
        public async Task<IHttpActionResult> PostExpenseHeadMaster(ExpenseHeadMaster model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ExpenseHeadMasters.Add(model);
            await db.SaveChangesAsync();
            var ret = await db.ExpenseHeadMasters.Select(ExpenseHeadMasterDTO.SELECT).FirstOrDefaultAsync(x => x.ExpenseHeadID == model.ExpenseHeadID);
            return CreatedAtRoute("DefaultApi", new { id = model.ExpenseHeadID }, model);
        }

        [ResponseType(typeof(ExpenseHeadMasterDTO))]
        public async Task<IHttpActionResult> DeleteExpenseHeadMaster(int id)
        {
            ExpenseHeadMaster model = await db.ExpenseHeadMasters.FindAsync(id);
            if (model == null)
            {
                return NotFound();
            }

            db.ExpenseHeadMasters.Remove(model);
            await db.SaveChangesAsync();
            var ret = await db.ExpenseHeadMasters.Select(ExpenseHeadMasterDTO.SELECT).FirstOrDefaultAsync(x => x.ExpenseHeadID == model.ExpenseHeadID);
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

        private bool ExpenseHeadMasterExists(int id)
        {
            return db.ExpenseHeadMasters.Count(e => e.ExpenseHeadID == id) > 0;
        }
    }
}