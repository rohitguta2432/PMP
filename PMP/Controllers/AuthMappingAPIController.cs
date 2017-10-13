
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
    public class AuthMappingController : ApiController
    {
        private PMP.PMPEntities db = new PMP.PMPEntities();

        public IQueryable<AuthMappingDTO> GetAuthMappings(int pageSize = 10
                        ,System.Int32? DesignationID = null
                        ,System.Int32? PageID = null
                        ,System.Int32? CreatedBy = null
                        ,System.Int32? ModifiedBy = null
                )
        {
            var model = db.AuthMappings.AsQueryable();
                                if(DesignationID != null){
                        model = model.Where(m=> m.DesignationID == DesignationID.Value);
                    }
                                if(PageID != null){
                        model = model.Where(m=> m.PageID == PageID.Value);
                    }
                                if(CreatedBy != null){
                        model = model.Where(m=> m.CreatedBy == CreatedBy.Value);
                    }
                                if(ModifiedBy != null){
                        model = model.Where(m=> m.ModifiedBy == ModifiedBy.Value);
                    }
                        
            return model.Select(AuthMappingDTO.SELECT).Take(pageSize);
        }

        [ResponseType(typeof(AuthMappingDTO))]
        public async Task<IHttpActionResult> GetAuthMapping(int id)
        {
            var model = await db.AuthMappings.Select(AuthMappingDTO.SELECT).FirstOrDefaultAsync(x => x.AuthID == id);
            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        public async Task<IHttpActionResult> PutAuthMapping(int id, AuthMapping model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != model.AuthID)
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
                if (!AuthMappingExists(id))
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

        [ResponseType(typeof(AuthMappingDTO))]
        public async Task<IHttpActionResult> PostAuthMapping(AuthMapping model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AuthMappings.Add(model);
            await db.SaveChangesAsync();
            var ret = await db.AuthMappings.Select(AuthMappingDTO.SELECT).FirstOrDefaultAsync(x => x.AuthID == model.AuthID);
            return CreatedAtRoute("DefaultApi", new { id = model.AuthID }, model);
        }

        [ResponseType(typeof(AuthMappingDTO))]
        public async Task<IHttpActionResult> DeleteAuthMapping(int id)
        {
            AuthMapping model = await db.AuthMappings.FindAsync(id);
            if (model == null)
            {
                return NotFound();
            }

            db.AuthMappings.Remove(model);
            await db.SaveChangesAsync();
            var ret = await db.AuthMappings.Select(AuthMappingDTO.SELECT).FirstOrDefaultAsync(x => x.AuthID == model.AuthID);
            return Ok(ret);
        }

        
        [Route("GetAuthMappingByDesignationID/{DesignationID}")]
        public IQueryable<AuthMappingDTO> GetAuthMappingByDesignationID(System.Int32? DesignationID = null)
        {
            var model = db.AuthMappings.AsQueryable();
            if (DesignationID != null)
            {
                model = model.Where(m => m.DesignationID == DesignationID.Value);
            }
            return model.Select(AuthMappingDTO.SELECT);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AuthMappingExists(int id)
        {
            return db.AuthMappings.Count(e => e.AuthID == id) > 0;
        }
    }
}