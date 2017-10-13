
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
    public class DepartmentController : ApiController
    {
        private PMP.PMPEntities db = new PMP.PMPEntities();

        public IQueryable<DepartmentDTO> GetDepartments(int pageSize = 10
                        ,System.Int32? CreatedBy = null
                        ,System.Int32? ModifiedBy = null
                )
        {
            var model = db.Departments.AsQueryable();
                                if(CreatedBy != null){
                        model = model.Where(m=> m.CreatedBy == CreatedBy.Value);
                    }
                                if(ModifiedBy != null){
                        model = model.Where(m=> m.ModifiedBy == ModifiedBy.Value);
                    }
                        
            return model.Select(DepartmentDTO.SELECT).Take(pageSize);
        }

        [ResponseType(typeof(DepartmentDTO))]
        public async Task<IHttpActionResult> GetDepartment(int id)
        {
            var model = await db.Departments.Select(DepartmentDTO.SELECT).FirstOrDefaultAsync(x => x.DepartmentID == id);
            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        public async Task<IHttpActionResult> PutDepartment(int id, Department model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != model.DepartmentID)
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
                if (!DepartmentExists(id))
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

        [ResponseType(typeof(DepartmentDTO))]
        public async Task<IHttpActionResult> PostDepartment(Department model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Departments.Add(model);
            await db.SaveChangesAsync();
            var ret = await db.Departments.Select(DepartmentDTO.SELECT).FirstOrDefaultAsync(x => x.DepartmentID == model.DepartmentID);
            return CreatedAtRoute("DefaultApi", new { id = model.DepartmentID }, model);
        }

        [ResponseType(typeof(DepartmentDTO))]
        public async Task<IHttpActionResult> DeleteDepartment(int id)
        {
            Department model = await db.Departments.FindAsync(id);
            if (model == null)
            {
                return NotFound();
            }

            db.Departments.Remove(model);
            await db.SaveChangesAsync();
            var ret = await db.Departments.Select(DepartmentDTO.SELECT).FirstOrDefaultAsync(x => x.DepartmentID == model.DepartmentID);
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

        private bool DepartmentExists(int id)
        {
            return db.Departments.Count(e => e.DepartmentID == id) > 0;
        }
    }
}