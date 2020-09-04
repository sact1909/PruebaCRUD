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
        public DateTime Date_Permission { get; set; }
        public int Permission_Type { get; set; }
        public string perDescription { get; set; }
    }
}
