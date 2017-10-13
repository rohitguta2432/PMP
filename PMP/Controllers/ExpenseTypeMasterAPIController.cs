
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
    public class ExpenseTypeMasterController : ApiController
    {
        private PMP.PMPEntities db = new PMP.PMPEntities();

        public IQueryable<ExpenseTypeMasterDTO> GetExpenseTypeMasters(int pageSize = 10
                        ,System.Int32? ExpenseHeadID = null
                        ,System.Int32? CreatedBy = null
                        ,System.Int32? ModifiedBy = null
                )
        {
            var model = db.ExpenseTypeMasters.AsQueryable();
                                if(ExpenseHeadID != null){
                        model = model.Where(m=> m.ExpenseHeadID == ExpenseHeadID.Value);
                    }
                                if(CreatedBy != null){
                        model = model.Where(m=> m.CreatedBy == CreatedBy.Value);
                    }
                                if(ModifiedBy != null){
                        model = model.Where(m=> m.ModifiedBy == ModifiedBy.Value);
                    }
                        
            return model.Select(ExpenseTypeMasterDTO.SELECT).Take(pageSize);
        }

        [ResponseType(typeof(ExpenseTypeMasterDTO))]
        public async Task<IHttpActionResult> GetExpenseTypeMaster(int id)
        {
            var model = await db.ExpenseTypeMasters.Select(ExpenseTypeMasterDTO.SELECT).FirstOrDefaultAsync(x => x.ExpenseTypeID == id);
            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        public async Task<IHttpActionResult> PutExpenseTypeMaster(int id, ExpenseTypeMaster model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != model.ExpenseTypeID)
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
                if (!ExpenseTypeMasterExists(id))
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

        [ResponseType(typeof(ExpenseTypeMasterDTO))]
        public async Task<IHttpActionResult> PostExpenseTypeMaster(ExpenseTypeMaster model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ExpenseTypeMasters.Add(model);
            await db.SaveChangesAsync();
            var ret = await db.ExpenseTypeMasters.Select(ExpenseTypeMasterDTO.SELECT).FirstOrDefaultAsync(x => x.ExpenseTypeID == model.ExpenseTypeID);
            return CreatedAtRoute("DefaultApi", new { id = model.ExpenseTypeID }, model);
        }

        [ResponseType(typeof(ExpenseTypeMasterDTO))]
        public async Task<IHttpActionResult> DeleteExpenseTypeMaster(int id)
        {
            ExpenseTypeMaster model = await db.ExpenseTypeMasters.FindAsync(id);
            if (model == null)
            {
                return NotFound();
            }

            db.ExpenseTypeMasters.Remove(model);
            await db.SaveChangesAsync();
            var ret = await db.ExpenseTypeMasters.Select(ExpenseTypeMasterDTO.SELECT).FirstOrDefaultAsync(x => x.ExpenseTypeID == model.ExpenseTypeID);
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

        private bool ExpenseTypeMasterExists(int id)
        {
            return db.ExpenseTypeMasters.Count(e => e.ExpenseTypeID == id) > 0;
        }
    }
}