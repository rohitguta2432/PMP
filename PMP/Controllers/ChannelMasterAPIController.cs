
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
    public class ChannelMasterController : ApiController
    {
        private PMP.PMPEntities db = new PMP.PMPEntities();

        public IQueryable<ChannelMasterDTO> GetChannelMasters(int pageSize = 10
                        ,System.Int32? CreatedBy = null
                        ,System.Int32? ModifiedBy = null
                )
        {
            var model = db.ChannelMasters.AsQueryable();
                                if(CreatedBy != null){
                        model = model.Where(m=> m.CreatedBy == CreatedBy.Value);
                    }
                                if(ModifiedBy != null){
                        model = model.Where(m=> m.ModifiedBy == ModifiedBy.Value);
                    }
                        
            return model.Select(ChannelMasterDTO.SELECT).OrderBy(x=>x.ChannelName).Take(pageSize);
        }

        [ResponseType(typeof(ChannelMasterDTO))]
        public async Task<IHttpActionResult> GetChannelMaster(int id)
        {
            var model = await db.ChannelMasters.Select(ChannelMasterDTO.SELECT).FirstOrDefaultAsync(x => x.ChannelID == id);
            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        public async Task<IHttpActionResult> PutChannelMaster(int id, ChannelMaster model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != model.ChannelID)
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
                if (!ChannelMasterExists(id))
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

        [ResponseType(typeof(ChannelMasterDTO))]
        public async Task<IHttpActionResult> PostChannelMaster(ChannelMaster model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ChannelMasters.Add(model);
            await db.SaveChangesAsync();
            var ret = await db.ChannelMasters.Select(ChannelMasterDTO.SELECT).FirstOrDefaultAsync(x => x.ChannelID == model.ChannelID);
            return CreatedAtRoute("DefaultApi", new { id = model.ChannelID }, model);
        }

        [ResponseType(typeof(ChannelMasterDTO))]
        public async Task<IHttpActionResult> DeleteChannelMaster(int id)
        {
            ChannelMaster model = await db.ChannelMasters.FindAsync(id);
            if (model == null)
            {
                return NotFound();
            }

            db.ChannelMasters.Remove(model);
            await db.SaveChangesAsync();
            var ret = await db.ChannelMasters.Select(ChannelMasterDTO.SELECT).FirstOrDefaultAsync(x => x.ChannelID == model.ChannelID);
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

        private bool ChannelMasterExists(int id)
        {
            return db.ChannelMasters.Count(e => e.ChannelID == id) > 0;
        }
    }
}