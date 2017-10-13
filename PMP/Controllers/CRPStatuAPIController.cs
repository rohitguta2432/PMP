
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
    public class CRPStatuController : ApiController
    {
        private PMP.PMPEntities db = new PMP.PMPEntities();

        public IQueryable<CRPStatuDTO> GetCRPStatus(int pageSize = 10
                        ,System.Int32? CreatedBy = null
                        ,System.Int32? ModifiedBy = null
                )
        {
            var model = db.CRPStatus.AsQueryable();
                                if(CreatedBy != null){
                        model = model.Where(m=> m.CreatedBy == CreatedBy.Value);
                    }
                                if(ModifiedBy != null){
                        model = model.Where(m=> m.ModifiedBy == ModifiedBy.Value);
                    }
                        
            return model.Select(CRPStatuDTO.SELECT).Take(pageSize);
        }

        [ResponseType(typeof(CRPStatuDTO))]
        public async Task<IHttpActionResult> GetCRPStatu(int id)
        {
            var model = await db.CRPStatus.Select(CRPStatuDTO.SELECT).FirstOrDefaultAsync(x => x.CRPStatusID == id);
            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        public async Task<IHttpActionResult> PutCRPStatu(int id, CRPStatu model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != model.CRPStatusID)
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
                if (!CRPStatuExists(id))
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

        [ResponseType(typeof(CRPStatuDTO))]
        public async Task<IHttpActionResult> PostCRPStatu(CRPStatu model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CRPStatus.Add(model);
            await db.SaveChangesAsync();
            var ret = await db.CRPStatus.Select(CRPStatuDTO.SELECT).FirstOrDefaultAsync(x => x.CRPStatusID == model.CRPStatusID);
            return CreatedAtRoute("DefaultApi", new { id = model.CRPStatusID }, model);
        }

        [ResponseType(typeof(CRPStatuDTO))]
        public async Task<IHttpActionResult> DeleteCRPStatu(int id)
        {
            CRPStatu model = await db.CRPStatus.FindAsync(id);
            if (model == null)
            {
                return NotFound();
            }

            db.CRPStatus.Remove(model);
            await db.SaveChangesAsync();
            var ret = await db.CRPStatus.Select(CRPStatuDTO.SELECT).FirstOrDefaultAsync(x => x.CRPStatusID == model.CRPStatusID);
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

        private bool CRPStatuExists(int id)
        {
            return db.CRPStatus.Count(e => e.CRPStatusID == id) > 0;
        }
    }
}