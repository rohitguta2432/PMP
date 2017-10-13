
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
    public class ExpenseDetailController : ApiController
    {
        private PMP.PMPEntities db = new PMP.PMPEntities();

        public IQueryable<ExpenseDetailDTO> GetExpenseDetails(int pageSize = 10
                        ,System.Int32? PhaseID = null
                        ,System.Int32? ResearchTypeID = null
                        ,System.Int32? MethodID = null
                        ,System.Int32? CurrencyID = null
                        ,System.Int32? ProjectID = null
                        ,System.Int32? CreatedBy = null
                        ,System.Int32? ModifiedBy = null
                )
        {
            var model = db.ExpenseDetails.AsQueryable();
                                if(PhaseID != null){
                        model = model.Where(m=> m.PhaseID == PhaseID.Value);
                    }
                                if(ResearchTypeID != null){
                        model = model.Where(m=> m.ResearchTypeID == ResearchTypeID.Value);
                    }
                                if(MethodID != null){
                        model = model.Where(m=> m.MethodID == MethodID.Value);
                    }
                                if(CurrencyID != null){
                        model = model.Where(m=> m.CurrencyID == CurrencyID.Value);
                    }
                                if(ProjectID != null){
                        model = model.Where(m=> m.ProjectID == ProjectID.Value);
                    }
                                if(CreatedBy != null){
                        model = model.Where(m=> m.CreatedBy == CreatedBy.Value);
                    }
                                if(ModifiedBy != null){
                        model = model.Where(m=> m.ModifiedBy == ModifiedBy.Value);
                    }
                        
            return model.Select(ExpenseDetailDTO.SELECT).Take(pageSize);
        }

        [ResponseType(typeof(ExpenseDetailDTO))]
        public async Task<IHttpActionResult> GetExpenseDetail(int id)
        {
            var model = await db.ExpenseDetails.Select(ExpenseDetailDTO.SELECT).FirstOrDefaultAsync(x => x.ExpenseID == id);
            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        public async Task<IHttpActionResult> PutExpenseDetail(int id, ExpenseDetail model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != model.ExpenseID)
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
                if (!ExpenseDetailExists(id))
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

        [ResponseType(typeof(ExpenseDetailDTO))]
        public async Task<IHttpActionResult> PostExpenseDetail(ExpenseDetail model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ExpenseDetails.Add(model);
            await db.SaveChangesAsync();
            var ret = await db.ExpenseDetails.Select(ExpenseDetailDTO.SELECT).FirstOrDefaultAsync(x => x.ExpenseID == model.ExpenseID);
            return CreatedAtRoute("DefaultApi", new { id = model.ExpenseID }, model);
        }

        [ResponseType(typeof(ExpenseDetailDTO))]
        public async Task<IHttpActionResult> DeleteExpenseDetail(int id)
        {
            ExpenseDetail model = await db.ExpenseDetails.FindAsync(id);
            if (model == null)
            {
                return NotFound();
            }

            db.ExpenseDetails.Remove(model);
            await db.SaveChangesAsync();
            var ret = await db.ExpenseDetails.Select(ExpenseDetailDTO.SELECT).FirstOrDefaultAsync(x => x.ExpenseID == model.ExpenseID);
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

        private bool ExpenseDetailExists(int id)
        {
            return db.ExpenseDetails.Count(e => e.ExpenseID == id) > 0;
        }
    }
}