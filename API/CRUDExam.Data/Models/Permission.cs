using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CRUDExam.Data.Models
{
    public class Permission
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [MaxLength(100)]
        public string Emp_Name { get; set; }
        [MaxLength(100)]
        public string Emp_LastName { get; set; }
        public int Permission_Type { get; set; }
        public DateTime Date_Permission { get; set; }
        [ForeignKey("PermissionType")]
        public int FPermissionType { get; set; }
        public PermissionType PermissionType { get; set; }
    }
}
