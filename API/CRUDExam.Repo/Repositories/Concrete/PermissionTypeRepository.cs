using CRUDExam.Data.Models;
using CRUDExam.Repo.Core.Concrete;
using CRUDExam.Repo.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRUDExam.Repo.Repositories.Concrete
{
    public class PermissionTypeRepository : Repository<PermissionType>, IPermissionType
    {
        public PermissionTypeRepository(AppDbContext context)
            :base(context)
        {

        }
    }
}
