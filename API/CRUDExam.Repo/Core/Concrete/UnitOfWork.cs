using CRUDExam.Data.Models;
using CRUDExam.Repo.Core.Abstract;
using CRUDExam.Repo.Repositories.Abstract;
using CRUDExam.Repo.Repositories.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CRUDExam.Repo.Core.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        protected readonly AppDbContext _context;
        public UnitOfWork(AppDbContext context)
        {
            this._context = context;
        }

        public IPermissionRepository Permission => new PermissionRepository(_context);
        public IPermissionTypeRepository PermissionType => new PermissionTypeRepository(_context);

        public async void Dispose()
        {
            await _context.DisposeAsync();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
