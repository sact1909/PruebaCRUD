using CRUDExam.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CRUDExam.Repo.Core.Abstract
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Permission> Permission { get; }
        IRepository<PermissionType> PermissionType { get; }
        Task SaveAsync();

    }
}
