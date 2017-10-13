
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
    public class CurrencyDetailController : ApiController
    {
        private PMP.PMPEntities db = new PMP.PMPEntities();

        public IQueryable<CurrencyDetailDTO> GetCurrencyDetails(int pageSize = 10
                        ,System.Int32? CreatedBy = null
                        ,System.Int32? ModifiedBy = null
                )
        {
            var model = db.CurrencyDetails.AsQueryable();
                                if(CreatedBy != null){
                        model = model.Where(m=> m.CreatedBy == CreatedBy.Value);
                    }
                                if(ModifiedBy != null){
                        model = model.Where(m=> m.ModifiedBy == ModifiedBy.Value);
                    }
                        
            return model.Select(CurrencyDetailDTO.SELECT).Take(pageSize);
        }

        [ResponseType(typeof(CurrencyDetailDTO))]
        public async Task<IHttpActionResult> GetCurrencyDetail(int id)
        {
            var model = await db.CurrencyDetails.Select(CurrencyDetailDTO.SELECT).FirstOrDefaultAsync(x => x.CurrencyID == id);
            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        public async Task<IHttpActionResult> PutCurrencyDetail(int id, CurrencyDetail model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != model.CurrencyID)
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
                if (!CurrencyDetailExists(id))
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

        [ResponseType(typeof(CurrencyDetailDTO))]
        public async Task<IHttpActionResult> PostCurrencyDetail(CurrencyDetail model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CurrencyDetails.Add(model);
            await db.SaveChangesAsync();
            var ret = await db.CurrencyDetails.Select(CurrencyDetailDTO.SELECT).FirstOrDefaultAsync(x => x.CurrencyID == model.CurrencyID);
            return CreatedAtRoute("DefaultApi", new { id = model.CurrencyID }, model);
        }

        [ResponseType(typeof(CurrencyDetailDTO))]
        public async Task<IHttpActionResult> DeleteCurrencyDetail(int id)
        {
            CurrencyDetail model = await db.CurrencyDetails.FindAsync(id);
            if (model == null)
            {
                return NotFound();
            }

            db.CurrencyDetails.Remove(model);
            await db.SaveChangesAsync();
            var ret = await db.CurrencyDetails.Select(CurrencyDetailDTO.SELECT).FirstOrDefaultAsync(x => x.CurrencyID == model.CurrencyID);
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

        private bool CurrencyDetailExists(int id)
        {
            return db.CurrencyDetails.Count(e => e.CurrencyID == id) > 0;
        }
    }
}