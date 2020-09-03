using CRUDExam.Repo.Core.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CRUDExam.Repo.Core.DTO
{
    public class PermissionDTO
    {
        public int ID { get; set; }
        public string Emp_Name { get; set; }
        public string Emp_LastName { get; set; }
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date_Permission { get; set; }
        public int PermissionTypeID { get; set; }
        public string PermissionType { 
            get {

                return _unitofwork.PermissionType.GetByID(x => x.ID == PermissionTypeID).Description;
            } 
        }

        IUnitOfWork _unitofwork;
        public PermissionDTO(IUnitOfWork unitofwork)
        {
            _unitofwork = unitofwork;
        }
    }
}
