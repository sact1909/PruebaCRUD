using CRUDExam.Data.Models;
using CRUDExam.Repo.Core.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CRUDExam.Repo.Repositories.Abstract
{
    public interface IPermissionRepository : IRepository<Permission>
    {
        Task<List<Permission>> GetWithPermissionTypes();
    }
}
