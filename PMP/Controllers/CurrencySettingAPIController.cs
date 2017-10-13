
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
    public class CurrencySettingController : ApiController
    {
        private PMP.PMPEntities db = new PMP.PMPEntities();

        public IQueryable<CurrencySettingDTO> GetCurrencySettings(int pageSize = 10
                        ,System.Int32? BaseCurrencyID = null
                        ,System.Int32? CreatedBy = null
                        ,System.Int32? ModifiedBy = null
                )
        {
            var model = db.CurrencySettings.AsQueryable();
                                if(BaseCurrencyID != null){
                        model = model.Where(m=> m.BaseCurrencyID == BaseCurrencyID.Value);
                    }
                                if(CreatedBy != null){
                        model = model.Where(m=> m.CreatedBy == CreatedBy.Value);
                    }
                                if(ModifiedBy != null){
                        model = model.Where(m=> m.ModifiedBy == ModifiedBy.Value);
                    }
                        
            return model.Select(CurrencySettingDTO.SELECT).Take(pageSize);
        }

        [ResponseType(typeof(CurrencySettingDTO))]
        public async Task<IHttpActionResult> GetCurrencySetting(int id)
        {
            var model = await db.CurrencySettings.Select(CurrencySettingDTO.SELECT).FirstOrDefaultAsync(x => x.CurrencySettingID == id);
            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        public async Task<IHttpActionResult> PutCurrencySetting(int id, CurrencySetting model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != model.CurrencySettingID)
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
                if (!CurrencySettingExists(id))
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

        [ResponseType(typeof(CurrencySettingDTO))]
        public async Task<IHttpActionResult> PostCurrencySetting(CurrencySetting model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CurrencySettings.Add(model);
            await db.SaveChangesAsync();
            var ret = await db.CurrencySettings.Select(CurrencySettingDTO.SELECT).FirstOrDefaultAsync(x => x.CurrencySettingID == model.CurrencySettingID);
            return CreatedAtRoute("DefaultApi", new { id = model.CurrencySettingID }, model);
        }

        [ResponseType(typeof(CurrencySettingDTO))]
        public async Task<IHttpActionResult> DeleteCurrencySetting(int id)
        {
            CurrencySetting model = await db.CurrencySettings.FindAsync(id);
            if (model == null)
            {
                return NotFound();
            }

            db.CurrencySettings.Remove(model);
            await db.SaveChangesAsync();
            var ret = await db.CurrencySettings.Select(CurrencySettingDTO.SELECT).FirstOrDefaultAsync(x => x.CurrencySettingID == model.CurrencySettingID);
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

        private bool CurrencySettingExists(int id)
        {
            return db.CurrencySettings.Count(e => e.CurrencySettingID == id) > 0;
        }
    }
}