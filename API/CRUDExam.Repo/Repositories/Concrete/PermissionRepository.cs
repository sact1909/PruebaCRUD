using CRUDExam.Data.Models;
using CRUDExam.Repo.Core.Concrete;
using CRUDExam.Repo.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDExam.Repo.Repositories.Concrete
{
    public class PermissionRepository : Repository<Permission>, IPermissionRepository
    {
        public PermissionRepository(AppDbContext context)
           : base(context)
        {

        }

        public async Task<List<Permission>> GetWithPermissionTypes()
        {
            return await _context.Permission
                .Include(p => p.PermissionType)
                .ToListAsync();
        }
    }
}
