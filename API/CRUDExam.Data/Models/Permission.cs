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
        [Required(ErrorMessage = "El nombre del empleado no puede estar vacio")]
        public string Emp_Name { get; set; }
        [MaxLength(100)]
        [Required(ErrorMessage = "El apellido del empleado no puede estar vacio")]
        public string Emp_LastName { get; set; }
        [Required(ErrorMessage = "Debe ingresar una fecha")]
        public DateTime Date_Permission { get; set; }
        [ForeignKey("PermissionType")]
        [Required(ErrorMessage = "Debe elegir un permiso")]
        public int Permission_Type { get; set; }
        public PermissionType PermissionType { get; set; }
    }
}
