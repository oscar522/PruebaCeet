using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspNetIdentity.WebClientAdmin.Models
{
    public class UsersModel
    {
        public int Id_User { get; set; }

        [Display(Name = "Fecha")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime CreationDate { get; set; }

        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Display(Name = "A. Paterno")]
        public string FirstName { get; set; }

        [Display(Name = "A. Materno")]
        public string LastName { get; set; }

        [Display(Name = "Correo")]
        public string Email { get; set; }

        [Display(Name = "Activo")]
        public bool Active { get; set; }

        [Display(Name = "Rol")]
        public string NameRole { get; set; }
    }
}