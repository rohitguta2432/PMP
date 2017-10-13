
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
    [Authorize]
    public class EmployeeMasterController : ApiController
    {
        private PMP.PMPEntities db = new PMP.PMPEntities();

        public IQueryable<EmployeeMasterDTO> GetEmployeeMasters(int pageSize = 10
                        , System.Int32? DesignationID = null
                        , System.Int32? DepartmentID = null
                        , System.Int32? CreatedBy = null
                        , System.Int32? ModifiedBy = null
                )
        {
            var model = db.EmployeeMasters.AsQueryable();
            if (DesignationID != null)
            {
                model = model.Where(m => m.DesignationID == DesignationID.Value);
            }
            if (DepartmentID != null)
            {
                model = model.Where(m => m.DepartmentID == DepartmentID.Value);
            }
            if (CreatedBy != null)
            {
                model = model.Where(m => m.CreatedBy == CreatedBy.Value);
            }
            if (ModifiedBy != null)
            {
                model = model.Where(m => m.ModifiedBy == ModifiedBy.Value);
            }

            return model.Select(EmployeeMasterDTO.SELECT).Take(pageSize);
        }

        [ResponseType(typeof(EmployeeMasterDTO))]
        public async Task<IHttpActionResult> GetEmployeeMaster(int id)
        {
            var model = await db.EmployeeMasters.Select(EmployeeMasterDTO.SELECT).FirstOrDefaultAsync(x => x.EmployeeID == id);
            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        public async Task<IHttpActionResult> PutEmployeeMaster(int id, EmployeeMaster model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != model.EmployeeID)
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
                if (!EmployeeMasterExists(id))
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

        [ResponseType(typeof(EmployeeMasterDTO))]
        public async Task<IHttpActionResult> PostEmployeeMaster(EmployeeMaster model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.EmployeeMasters.Add(model);
            await db.SaveChangesAsync();
            var ret = await db.EmployeeMasters.Select(EmployeeMasterDTO.SELECT).FirstOrDefaultAsync(x => x.EmployeeID == model.EmployeeID);
            return CreatedAtRoute("DefaultApi", new { id = model.EmployeeID }, model);
        }

        [ResponseType(typeof(EmployeeMasterDTO))]
        public async Task<IHttpActionResult> DeleteEmployeeMaster(int id)
        {
            EmployeeMaster model = await db.EmployeeMasters.FindAsync(id);
            if (model == null)
            {
                return NotFound();
            }

            db.EmployeeMasters.Remove(model);
            await db.SaveChangesAsync();
            var ret = await db.EmployeeMasters.Select(EmployeeMasterDTO.SELECT).FirstOrDefaultAsync(x => x.EmployeeID == model.EmployeeID);
            return Ok(ret);
        }

        [HttpGet]
        [Route("GetEmployeeDetails/{DepartmentID}")]
        public async Task<IHttpActionResult> GetEmployeeDetails(int DepartmentID)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var empModel = await (from emp in db.EmployeeMasters
                                  where emp.DepartmentID == DepartmentID
                                  select new
                                  {
                                      FirstName = emp.FirstName,
                                      LastName = emp.LastName
                                  }).ToListAsync();
            if (empModel == null)
            {
                return NotFound();
            }
            return Ok(empModel);

        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EmployeeMasterExists(int id)
        {
            return db.EmployeeMasters.Count(e => e.EmployeeID == id) > 0;
        }
    }
}