using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUDExam.Data.Models;
using CRUDExam.Repo.Core.Abstract;
using CRUDExam.Repo.Core.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUDExam.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionManagerController : BaseController<Permission>
    {
        public PermissionManagerController(IUnitOfWork unitOfWork, IRepository<Permission> genericRepository)
        :base(unitOfWork, genericRepository)
        {

        }

        [HttpGet]
        [Route("ListPermision")]
        public async Task<IActionResult> GetList() {

            try
            {
                List<PermissionDTO> results = new List<PermissionDTO>();
                foreach (var result in await _unitofwork.Permission.GetAsync()) {
                    results.Add(new PermissionDTO(_unitofwork) { 
                        ID = result.ID,
                        Date_Permission = result.Date_Permission,
                        Emp_LastName = result.Emp_LastName,
                        Emp_Name = result.Emp_Name,
                        PermissionTypeID = result.Permission_Type
                    });
                }

                return Ok(results);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ha ocurrido un error, Favor intentar nuevamente");
            }
        }

        [HttpGet]
        [Route("GetByID/{Id}")]
        public async Task<IActionResult> GetId(int Id)
        {

            try
            {
                return Ok(await _unitofwork.Permission.GetByIDAsync(x=>x.ID==Id));
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ha ocurrido un error, Favor intentar nuevamente");
            }

        }

    }
}
