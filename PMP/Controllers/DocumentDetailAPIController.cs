
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;

namespace PMP
{
    public class DocumentDetailController : ApiController
    {
        private PMP.PMPEntities db = new PMP.PMPEntities();

        public IQueryable<DocumentDetailDTO> GetDocumentDetails(int pageSize = 10
                        ,System.Int32? CreatedBy = null
                        ,System.Int32? ModifiedBy = null
                )
        {
            var model = db.DocumentDetails.AsQueryable();
                                if(CreatedBy != null){
                        model = model.Where(m=> m.CreatedBy == CreatedBy.Value);
                    }
                                if(ModifiedBy != null){
                        model = model.Where(m=> m.ModifiedBy == ModifiedBy.Value);
                    }
                        
            return model.Select(DocumentDetailDTO.SELECT).Take(pageSize);
        }

        [ResponseType(typeof(DocumentDetailDTO))]
        public async Task<IHttpActionResult> GetDocumentDetail(int id)
        {
            var model = await db.DocumentDetails.Select(DocumentDetailDTO.SELECT).FirstOrDefaultAsync(x => x.DocumentID == id);
            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        public async Task<IHttpActionResult> PutDocumentDetail(int id, DocumentDetail model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != model.DocumentID)
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
                if (!DocumentDetailExists(id))
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

        [ResponseType(typeof(DocumentDetailDTO))]
        public async Task<IHttpActionResult> PostDocumentDetail(DocumentDetail model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DocumentDetails.Add(model);
            await db.SaveChangesAsync();
            var ret = await db.DocumentDetails.Select(DocumentDetailDTO.SELECT).FirstOrDefaultAsync(x => x.DocumentID == model.DocumentID);
            return CreatedAtRoute("DefaultApi", new { id = model.DocumentID }, model);
        }

        [ResponseType(typeof(DocumentDetailDTO))]
        public async Task<IHttpActionResult> DeleteDocumentDetail(int id)
        {
            DocumentDetail model = await db.DocumentDetails.FindAsync(id);
            if (model == null)
            {
                return NotFound();
            }

            db.DocumentDetails.Remove(model);
            await db.SaveChangesAsync();
            var ret = await db.DocumentDetails.Select(DocumentDetailDTO.SELECT).FirstOrDefaultAsync(x => x.DocumentID == model.DocumentID);
            return Ok(ret);
        }
        [HttpPost]
        [Route("UploadFile")]
        public async Task<IHttpActionResult> UploadFile(HttpPostedFileBase postedFile)
        {
            DocumentDetail fileDetail = new DocumentDetail();
            byte[] bytes;
            using (BinaryReader br = new BinaryReader(postedFile.InputStream))
            {
                bytes = br.ReadBytes(postedFile.ContentLength);
            }

            fileDetail.Data = bytes;
            fileDetail.DocumentName = Path.GetFileName(postedFile.FileName);
            fileDetail.DocumentExtension = postedFile.ContentType;
            db.DocumentDetails.Add(fileDetail);
            await db.SaveChangesAsync();
            return Ok("You are successfully registered");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DocumentDetailExists(int id)
        {
            return db.DocumentDetails.Count(e => e.DocumentID == id) > 0;
        }
    }
}