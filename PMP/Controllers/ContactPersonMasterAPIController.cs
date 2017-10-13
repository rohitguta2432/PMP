
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
    public class ContactPersonMasterController : ApiController
    {
        private PMP.PMPEntities db = new PMP.PMPEntities();

        public IQueryable<ContactPersonMasterDTO> GetContactPersonMasters(int pageSize = 10
                        ,System.Int32? ClientID = null
                        ,System.Int32? CreatedBy = null
                        ,System.Int32? ModifiedBy = null
                )
        {
            var model = db.ContactPersonMasters.AsQueryable();
                                if(ClientID != null){
                        model = model.Where(m=> m.ClientID == ClientID.Value);
                    }
                                if(CreatedBy != null){
                        model = model.Where(m=> m.CreatedBy == CreatedBy.Value);
                    }
                                if(ModifiedBy != null){
                        model = model.Where(m=> m.ModifiedBy == ModifiedBy.Value);
                    }
                        
            return model.Select(ContactPersonMasterDTO.SELECT).Take(pageSize);
        }

        [ResponseType(typeof(ContactPersonMasterDTO))]
        public async Task<IHttpActionResult> GetContactPersonMaster(int id)
        {
            var model = await db.ContactPersonMasters.Select(ContactPersonMasterDTO.SELECT).FirstOrDefaultAsync(x => x.ContactPersonID == id);
            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        public async Task<IHttpActionResult> PutContactPersonMaster(int id, ContactPersonMaster model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != model.ContactPersonID)
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
                if (!ContactPersonMasterExists(id))
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

        [ResponseType(typeof(ContactPersonMasterDTO))]
        public async Task<IHttpActionResult> PostContactPersonMaster(ContactPersonMaster model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ContactPersonMasters.Add(model);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ContactPersonMasterExists(model.ContactPersonID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }
            var ret = await db.ContactPersonMasters.Select(ContactPersonMasterDTO.SELECT).FirstOrDefaultAsync(x => x.ContactPersonID == model.ContactPersonID);
            return CreatedAtRoute("DefaultApi", new { id = model.ContactPersonID }, model);
        }

        [ResponseType(typeof(ContactPersonMasterDTO))]
        public async Task<IHttpActionResult> DeleteContactPersonMaster(int id)
        {
            ContactPersonMaster model = await db.ContactPersonMasters.FindAsync(id);
            if (model == null)
            {
                return NotFound();
            }

            db.ContactPersonMasters.Remove(model);
            await db.SaveChangesAsync();
            var ret = await db.ContactPersonMasters.Select(ContactPersonMasterDTO.SELECT).FirstOrDefaultAsync(x => x.ContactPersonID == model.ContactPersonID);
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

        private bool ContactPersonMasterExists(int id)
        {
            return db.ContactPersonMasters.Count(e => e.ContactPersonID == id) > 0;
        }
    }
}