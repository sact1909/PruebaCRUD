using CRUDExam.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CRUDExam.Repo.Core.Abstract
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Permision> Permission { get; }
        IRepository<PermissionType> PermissionType { get; }
        Task Save();

    }
}
