
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
    
    public class ActualExpenseDetailController : ApiController
    {
        private PMP.PMPEntities db = new PMP.PMPEntities();

        public IQueryable<ActualExpenseDetailDTO> GetActualExpenseDetails(int pageSize = 10
                        ,System.Int32? PhaseExpenseID = null
                        ,System.Int32? CreatedBy = null
                        ,System.Int32? ModifiedBy = null
                )
        {
            var model = db.ActualExpenseDetails.AsQueryable();
                                if(PhaseExpenseID != null){
                        model = model.Where(m=> m.PhaseExpenseID == PhaseExpenseID.Value);
                    }
                                if(CreatedBy != null){
                        model = model.Where(m=> m.CreatedBy == CreatedBy.Value);
                    }
                                if(ModifiedBy != null){
                        model = model.Where(m=> m.ModifiedBy == ModifiedBy.Value);
                    }
                        
            return model.Select(ActualExpenseDetailDTO.SELECT).Take(pageSize);
        }

        [Route("Manage/GetActualExpenseDetail/{id}")]
        [ResponseType(typeof(ActualExpenseDetailDTO))]
        public async Task<IHttpActionResult> GetActualExpenseDetail(int id)
        {
            var model = await db.ActualExpenseDetails.Select(ActualExpenseDetailDTO.SELECT).FirstOrDefaultAsync(x => x.ActualExpenseID == id);
            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        public async Task<IHttpActionResult> PutActualExpenseDetail(int id, ActualExpenseDetail model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != model.ActualExpenseID)
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
                if (!ActualExpenseDetailExists(id))
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

        [ResponseType(typeof(ActualExpenseDetailDTO))]
        public async Task<IHttpActionResult> PostActualExpenseDetail(ActualExpenseDetail model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ActualExpenseDetails.Add(model);
            await db.SaveChangesAsync();
            var ret = await db.ActualExpenseDetails.Select(ActualExpenseDetailDTO.SELECT).FirstOrDefaultAsync(x => x.ActualExpenseID == model.ActualExpenseID);
            return CreatedAtRoute("DefaultApi", new { id = model.ActualExpenseID }, model);
        }


        [ResponseType(typeof(ActualExpenseDetailDTO))]
        public async Task<IHttpActionResult> DeleteActualExpenseDetail(int id)
        {
            ActualExpenseDetail model = await db.ActualExpenseDetails.FindAsync(id);
            if (model == null)
            {
                return NotFound();
            }

            db.ActualExpenseDetails.Remove(model);
            await db.SaveChangesAsync();
            var ret = await db.ActualExpenseDetails.Select(ActualExpenseDetailDTO.SELECT).FirstOrDefaultAsync(x => x.ActualExpenseID == model.ActualExpenseID);
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

        private bool ActualExpenseDetailExists(int id)
        {
            return db.ActualExpenseDetails.Count(e => e.ActualExpenseID == id) > 0;
        }
    }
}