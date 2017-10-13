
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
    public class InquiryTypeMasterController : ApiController
    {
        private PMP.PMPEntities db = new PMP.PMPEntities();

        public IQueryable<InquiryTypeMasterDTO> GetInquiryTypeMasters(int pageSize = 10
                        ,System.Int32? CreatedBy = null
                        ,System.Int32? ModifiedBy = null
                )
        {
            var model = db.InquiryTypeMasters.AsQueryable();
                                if(CreatedBy != null){
                        model = model.Where(m=> m.CreatedBy == CreatedBy.Value);
                    }
                                if(ModifiedBy != null){
                        model = model.Where(m=> m.ModifiedBy == ModifiedBy.Value);
                    }
                        
            return model.Select(InquiryTypeMasterDTO.SELECT).OrderBy(x=>x.InquiryTypeDesc).Take(pageSize);
        }

        [ResponseType(typeof(InquiryTypeMasterDTO))]
        public async Task<IHttpActionResult> GetInquiryTypeMaster(int id)
        {
            var model = await db.InquiryTypeMasters.Select(InquiryTypeMasterDTO.SELECT).FirstOrDefaultAsync(x => x.InquiryTypeID == id);
            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        public async Task<IHttpActionResult> PutInquiryTypeMaster(int id, InquiryTypeMaster model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != model.InquiryTypeID)
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
                if (!InquiryTypeMasterExists(id))
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

        [ResponseType(typeof(InquiryTypeMasterDTO))]
        public async Task<IHttpActionResult> PostInquiryTypeMaster(InquiryTypeMaster model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.InquiryTypeMasters.Add(model);
            await db.SaveChangesAsync();
            var ret = await db.InquiryTypeMasters.Select(InquiryTypeMasterDTO.SELECT).FirstOrDefaultAsync(x => x.InquiryTypeID == model.InquiryTypeID);
            return CreatedAtRoute("DefaultApi", new { id = model.InquiryTypeID }, model);
        }

        [ResponseType(typeof(InquiryTypeMasterDTO))]
        public async Task<IHttpActionResult> DeleteInquiryTypeMaster(int id)
        {
            InquiryTypeMaster model = await db.InquiryTypeMasters.FindAsync(id);
            if (model == null)
            {
                return NotFound();
            }

            db.InquiryTypeMasters.Remove(model);
            await db.SaveChangesAsync();
            var ret = await db.InquiryTypeMasters.Select(InquiryTypeMasterDTO.SELECT).FirstOrDefaultAsync(x => x.InquiryTypeID == model.InquiryTypeID);
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

        private bool InquiryTypeMasterExists(int id)
        {
            return db.InquiryTypeMasters.Count(e => e.InquiryTypeID == id) > 0;
        }
    }
}