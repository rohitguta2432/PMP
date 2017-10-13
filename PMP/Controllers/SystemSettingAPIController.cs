
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
    public class SystemSettingController : ApiController
    {
        private PMP.PMPEntities db = new PMP.PMPEntities();

        public IQueryable<SystemSettingDTO> GetSystemSettings(int pageSize = 10
                        ,System.Int32? CurrencySettingID = null
                        ,System.Int32? CreatedBy = null
                        ,System.Int32? ModifiedBy = null
                )
        {
            var model = db.SystemSettings.AsQueryable();
                                if(CurrencySettingID != null){
                        model = model.Where(m=> m.CurrencySettingID == CurrencySettingID.Value);
                    }
                                if(CreatedBy != null){
                        model = model.Where(m=> m.CreatedBy == CreatedBy.Value);
                    }
                                if(ModifiedBy != null){
                        model = model.Where(m=> m.ModifiedBy == ModifiedBy.Value);
                    }
                        
            return model.Select(SystemSettingDTO.SELECT).Take(pageSize);
        }

        [ResponseType(typeof(SystemSettingDTO))]
        public async Task<IHttpActionResult> GetSystemSetting(int id)
        {
            var model = await db.SystemSettings.Select(SystemSettingDTO.SELECT).FirstOrDefaultAsync(x => x.CurrencySettingID == id);
            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        public async Task<IHttpActionResult> PutSystemSetting(int id, SystemSetting model)
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
                if (!SystemSettingExists(id))
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

        [ResponseType(typeof(SystemSettingDTO))]
        public async Task<IHttpActionResult> PostSystemSetting(SystemSetting model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SystemSettings.Add(model);
            await db.SaveChangesAsync();
            var ret = await db.SystemSettings.Select(SystemSettingDTO.SELECT).FirstOrDefaultAsync(x => x.CurrencySettingID == model.CurrencySettingID);
            return CreatedAtRoute("DefaultApi", new { id = model.CurrencySettingID }, model);
        }

        [ResponseType(typeof(SystemSettingDTO))]
        public async Task<IHttpActionResult> DeleteSystemSetting(int id)
        {
            SystemSetting model = await db.SystemSettings.FindAsync(id);
            if (model == null)
            {
                return NotFound();
            }

            db.SystemSettings.Remove(model);
            await db.SaveChangesAsync();
            var ret = await db.SystemSettings.Select(SystemSettingDTO.SELECT).FirstOrDefaultAsync(x => x.CurrencySettingID == model.CurrencySettingID);
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

        private bool SystemSettingExists(int id)
        {
            return db.SystemSettings.Count(e => e.CurrencySettingID == id) > 0;
        }
    }
}