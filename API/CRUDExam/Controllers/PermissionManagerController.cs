using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CRUDExam.Data.Models;
using CRUDExam.Repo.Core.Abstract;
using CRUDExam.Repo.Core.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUDExam.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionManagerController : BaseController<Permission, PermissionDTO>
    {
        public PermissionManagerController(IUnitOfWork unitOfWork, IRepository<Permission> genericRepository, IMapper mapper)
        :base(unitOfWork, genericRepository, mapper)
        {

        }

        [HttpGet]
        [Route("ListPermision")]
        public async Task<IActionResult> GetList() {

            try
            {
                var resmodel = await _unitofwork.Permission.GetWithPermissionTypes();
                var dtoList = _mapper.Map<List<PermissionDTO>>(resmodel);
                return Ok(dtoList);
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
