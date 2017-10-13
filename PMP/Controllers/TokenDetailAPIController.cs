
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;

namespace PMP
{
    [Authorize]
    public class TokenDetailController : ApiController
    {
        private PMP.PMPEntities db = new PMP.PMPEntities();

        public IQueryable<TokenDetailDTO> GetTokenDetails(int PageSize = 10, int PageNum=1
                        ,System.Int32? ClientID = null
                        ,System.Int32? ContactPersonID = null
                        ,System.Int32? ChannelID = null
                        ,System.Int32? SourceID = null
                        ,System.Int32? InquiryTypeID = null
                        ,System.Int32? CreatedBy = null
                        ,System.Int32? Manager = null
                        ,System.Int32? CurrentStatusID = null
                        ,System.Int32? ModifiedBy = null
                        ,System.String SearchText=null
                )
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            //PMP.Utility u = new Utility();
            //EmployeeMaster emp = new EmployeeMaster();
            //emp=u.GetEmpByToken(principal);
            var model = db.TokenDetails.AsQueryable();
                                if(ClientID != null){
                        model = model.Where(m=> m.ClientID == ClientID.Value) ;
                    }
                                if(ContactPersonID != null){
                        model = model.Where(m=> m.ContactPersonID == ContactPersonID.Value);
                    }
                                if(ChannelID != null){
                        model = model.Where(m=> m.ChannelID == ChannelID.Value);
                    }
                                if(SourceID != null){
                        model = model.Where(m=> m.SourceID == SourceID.Value);
                    }
                                if(InquiryTypeID != null){
                        model = model.Where(m=> m.InquiryTypeID == InquiryTypeID.Value);
                    }
                                if(CreatedBy != null){
                        model = model.Where(m=> m.CreatedBy == CreatedBy.Value);
                    }
                                if(Manager != null){
                        model = model.Where(m=> m.Manager == Manager.Value);
                    }
                                if(CurrentStatusID != null){
                        model = model.Where(m=> m.CurrentStatusID == CurrentStatusID.Value);
                    }
                                if(ModifiedBy != null){
                        model = model.Where(m=> m.ModifiedBy == ModifiedBy.Value);
                    } 
            if(SearchText!=null)
            {
                model = model.Where(x => x.TokenKey.Contains(SearchText) || x.ClientMaster.ClientName.Contains(SearchText) ||
                  x.CurrentStatusMaster.CurrentStatusDesc.Contains(SearchText) || x.ContactPersonMaster.ContactPersonName.Contains(SearchText)
                  ||x.Objective.Contains(SearchText)||x.TargetAudience.Contains(SearchText));
            }
          
            //Preeti:05112017:Adding Paging in Token Page:Start
            var TotalPages = model.Count()/PageSize;
            int PageFetched = 0;
            if (PageNum!=1)
            {
                PageFetched = (PageNum - 1) * PageSize;
            } 
            //Preeti:05112017:Adding Paging in Token Page:End
            return model.Select(TokenDetailDTO.SELECT).Where(m=>m.CreatedBy==CreatedBy).OrderByDescending(m=>m.TokenID).Skip(PageFetched).Take(PageSize);
        }

        [ResponseType(typeof(TokenDetailDTO))]
        public async Task<IHttpActionResult> GetTokenDetail(int id)
        {
            var model = await db.TokenDetails.Select(TokenDetailDTO.SELECT).FirstOrDefaultAsync(x => x.TokenID == id);
            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        

        public async Task<IHttpActionResult> PutTokenDetail(int id, TokenDetail model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != model.TokenID)
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
                if (!TokenDetailExists(id))
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

        [ResponseType(typeof(TokenDetailDTO))]
        public async Task<IHttpActionResult> PostTokenDetail(TokenDetail model)
        {                  
            string tokenKey = Guid.NewGuid().ToString().Substring(0,6).ToUpper();
            model.TokenKey = tokenKey;
            //if(HttpContext.Current.Session["UserID"]!=null)
            //{
            //    model.CreatedBy= Convert.ToInt32(HttpContext.Current.Session["UserID"].ToString());
            //}
            model.CreatedDate = DateTime.Now;     
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TokenDetails.Add(model);
            await db.SaveChangesAsync();
            var ret = await db.TokenDetails.Select(TokenDetailDTO.SELECT).FirstOrDefaultAsync(x => x.TokenID == model.TokenID);
            return CreatedAtRoute("DefaultApi", new { id = model.TokenID }, model);
        }

        [ResponseType(typeof(TokenDetailDTO))]
        public async Task<IHttpActionResult> DeleteTokenDetail(int id)
        {
            TokenDetail model = await db.TokenDetails.FindAsync(id);
            if (model == null)
            {
                return NotFound();
            }

            db.TokenDetails.Remove(model);
            await db.SaveChangesAsync();
            var ret = await db.TokenDetails.Select(TokenDetailDTO.SELECT).FirstOrDefaultAsync(x => x.TokenID == model.TokenID);
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

        private bool TokenDetailExists(int id)
        {
            return db.TokenDetails.Count(e => e.TokenID == id) > 0;
        }
    }
}