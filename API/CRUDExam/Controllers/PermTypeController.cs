using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUDExam.Data.Models;
using CRUDExam.Repo.Core.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUDExam.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermTypeController : BaseController<PermissionType>
    {
        public PermTypeController(IUnitOfWork unitOfWork, IRepository<PermissionType> genericRepository)
            : base(unitOfWork, genericRepository)
        {

        }
    }
}
