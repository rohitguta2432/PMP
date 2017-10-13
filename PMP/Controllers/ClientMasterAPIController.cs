
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;

namespace PMP
{
    [Authorize]
    public class ClientMasterController : ApiController
    {
        private PMP.PMPEntities db = new PMP.PMPEntities();

        public IQueryable<ClientMasterDTO> GetClientMasters(int PageSize = 10, int PageNum = 1
                        , System.Int32? CreatedBy = null
                        ,System.Int32? ModifiedBy = null 
                        ,System.String SearchText = null
                )
        {
            var model = db.ClientMasters.AsQueryable();
                                if(CreatedBy != null){
                        model = model.Where(m=> m.CreatedBy == CreatedBy.Value);
                    }
                                if(ModifiedBy != null){
                        model = model.Where(m=> m.ModifiedBy == ModifiedBy.Value);
                    }
            if (SearchText != null)
            {
                model = model.Where(x => x.ClientName.Contains(SearchText) || x.ClientCode.Contains(SearchText) ||
                  x.Address.Contains(SearchText) || x.PhoneNumber.Contains(SearchText)
                  || x.Fax.Contains(SearchText));
            }

            //Preeti:05112017:Adding Paging in Token Page:Start
            var TotalPages = model.Count() / PageSize;
            int PageFetched = 0;
            if (PageNum != 1)
            {
                PageFetched = (PageNum - 1) * PageSize;
            }
            //Preeti:05112017:Adding Paging in Token Page:End
            return model.Select(ClientMasterDTO.SELECT).Where(m=>m.StatusID!=3).OrderBy(m => m.ClientName).Skip(PageFetched).Take(PageSize);
           }

        [ResponseType(typeof(ClientMasterDTO))]
        public async Task<IHttpActionResult> GetClientMaster(int id)
        {
            var model = await db.ClientMasters.Select(ClientMasterDTO.SELECT).FirstOrDefaultAsync(x => x.ClientID == id);
            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        public async Task<IHttpActionResult> PutClientMaster(int id, ClientMaster model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != model.ClientID)
            {
                return BadRequest();
            }

            db.Entry(model).State = EntityState.Modified;

            try
            {
                //if (HttpContext.Current.Session["UserID"] != null)
                //{
                //    model.ModifiedBy = Convert.ToInt32(HttpContext.Current.Session["UserID"].ToString());
                //}
                model.ModifiedDate = DateTime.Now;
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientMasterExists(id))
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

        [ResponseType(typeof(ClientMasterDTO))]
        public async Task<IHttpActionResult> PostClientMaster(ClientMaster model)
        {
            string clientCode = Guid.NewGuid().ToString().Substring(0, 6).ToUpper();
            model.ClientCode = clientCode;           
            model.CreatedDate = DateTime.Now;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var clientName = (from client in db.ClientMasters where
                             client.ClientName==model.ClientName
                             select client).FirstOrDefault();
            if (clientName != null)
            {
                if (clientName.ClientName.ToUpper() == model.ClientName.ToUpper())
                {
                    return BadRequest("Client Name already Exist");
                }
            }
            db.ClientMasters.Add(model);
            await db.SaveChangesAsync();
            var ret = await db.ClientMasters.Select(ClientMasterDTO.SELECT).FirstOrDefaultAsync(x => x.ClientID == model.ClientID);
            return CreatedAtRoute("DefaultApi", new { id = model.ClientID }, model);
        }

        [ResponseType(typeof(ClientMasterDTO))]
        public async Task<IHttpActionResult> DeleteClientMaster(int id)
        {
            ClientMaster model = await db.ClientMasters.FindAsync(id);
            if (model == null)
            {
                return NotFound();
            }

            db.ClientMasters.Remove(model);
            await db.SaveChangesAsync();
            var ret = await db.ClientMasters.Select(ClientMasterDTO.SELECT).FirstOrDefaultAsync(x => x.ClientID == model.ClientID);
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

        private bool ClientMasterExists(int id)
        {
            return db.ClientMasters.Count(e => e.ClientID == id) > 0;
        }
    }
}