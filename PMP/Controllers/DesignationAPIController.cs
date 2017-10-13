
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
    public class DesignationController : ApiController
    {
        private PMP.PMPEntities db = new PMP.PMPEntities();

        public IQueryable<DesignationDTO> GetDesignations(int pageSize = 10
                        ,System.Int32? CreatedBy = null
                        ,System.Int32? ModifiedBy = null
                )
        {
            var model = db.Designations.AsQueryable();
                                if(CreatedBy != null){
                        model = model.Where(m=> m.CreatedBy == CreatedBy.Value);
                    }
                                if(ModifiedBy != null){
                        model = model.Where(m=> m.ModifiedBy == ModifiedBy.Value);
                    }
                        
            return model.Select(DesignationDTO.SELECT).Take(pageSize);
        }

        [ResponseType(typeof(DesignationDTO))]
        public async Task<IHttpActionResult> GetDesignation(int id)
        {
            var model = await db.Designations.Select(DesignationDTO.SELECT).FirstOrDefaultAsync(x => x.DesignationID == id);
            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        public async Task<IHttpActionResult> PutDesignation(int id, Designation model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != model.DesignationID)
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
                if (!DesignationExists(id))
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

        [ResponseType(typeof(DesignationDTO))]
        public async Task<IHttpActionResult> PostDesignation(Designation model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Designations.Add(model);
            await db.SaveChangesAsync();
            var ret = await db.Designations.Select(DesignationDTO.SELECT).FirstOrDefaultAsync(x => x.DesignationID == model.DesignationID);
            return CreatedAtRoute("DefaultApi", new { id = model.DesignationID }, model);
        }

        [ResponseType(typeof(DesignationDTO))]
        public async Task<IHttpActionResult> DeleteDesignation(int id)
        {
            Designation model = await db.Designations.FindAsync(id);
            if (model == null)
            {
                return NotFound();
            }

            db.Designations.Remove(model);
            await db.SaveChangesAsync();
            var ret = await db.Designations.Select(DesignationDTO.SELECT).FirstOrDefaultAsync(x => x.DesignationID == model.DesignationID);
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

        private bool DesignationExists(int id)
        {
            return db.Designations.Count(e => e.DesignationID == id) > 0;
        }
    }
}