
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
    public class EstimatedExpenseDetailController : ApiController
    {
        private PMP.PMPEntities db = new PMP.PMPEntities();

        public IQueryable<EstimatedExpenseDetailDTO> GetEstimatedExpenseDetails(int pageSize = 10
                        ,System.Int32? PhaseExpenseID = null
                        ,System.Int32? CreatedBy = null
                        ,System.Int32? ModifiedBy = null
                )
        {
            var model = db.EstimatedExpenseDetails.AsQueryable();
                                if(PhaseExpenseID != null){
                        model = model.Where(m=> m.PhaseExpenseID == PhaseExpenseID.Value);
                    }
                                if(CreatedBy != null){
                        model = model.Where(m=> m.CreatedBy == CreatedBy.Value);
                    }
                                if(ModifiedBy != null){
                        model = model.Where(m=> m.ModifiedBy == ModifiedBy.Value);
                    }
                        
            return model.Select(EstimatedExpenseDetailDTO.SELECT).Take(pageSize);
        }

        [ResponseType(typeof(EstimatedExpenseDetailDTO))]
        public async Task<IHttpActionResult> GetEstimatedExpenseDetail(int id)
        {
            var model = await db.EstimatedExpenseDetails.Select(EstimatedExpenseDetailDTO.SELECT).FirstOrDefaultAsync(x => x.EstimatedExpenseID == id);
            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        public async Task<IHttpActionResult> PutEstimatedExpenseDetail(int id, EstimatedExpenseDetail model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != model.EstimatedExpenseID)
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
                if (!EstimatedExpenseDetailExists(id))
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

        [ResponseType(typeof(EstimatedExpenseDetailDTO))]
        public async Task<IHttpActionResult> PostEstimatedExpenseDetail(EstimatedExpenseDetail model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.EstimatedExpenseDetails.Add(model);
            await db.SaveChangesAsync();
            var ret = await db.EstimatedExpenseDetails.Select(EstimatedExpenseDetailDTO.SELECT).FirstOrDefaultAsync(x => x.EstimatedExpenseID == model.EstimatedExpenseID);
            return CreatedAtRoute("DefaultApi", new { id = model.EstimatedExpenseID }, model);
        }

        [ResponseType(typeof(EstimatedExpenseDetailDTO))]
        public async Task<IHttpActionResult> DeleteEstimatedExpenseDetail(int id)
        {
            EstimatedExpenseDetail model = await db.EstimatedExpenseDetails.FindAsync(id);
            if (model == null)
            {
                return NotFound();
            }

            db.EstimatedExpenseDetails.Remove(model);
            await db.SaveChangesAsync();
            var ret = await db.EstimatedExpenseDetails.Select(EstimatedExpenseDetailDTO.SELECT).FirstOrDefaultAsync(x => x.EstimatedExpenseID == model.EstimatedExpenseID);
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

        private bool EstimatedExpenseDetailExists(int id)
        {
            return db.EstimatedExpenseDetails.Count(e => e.EstimatedExpenseID == id) > 0;
        }
    }
}