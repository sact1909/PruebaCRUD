using CRUDExam.Data.Models;
using CRUDExam.Repo.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CRUDExam.Repo.Core.Abstract
{
    public interface IUnitOfWork : IDisposable
    {
        IPermissionRepository Permission { get; }
        IPermissionTypeRepository PermissionType { get; }
        Task SaveAsync();

    }
}
