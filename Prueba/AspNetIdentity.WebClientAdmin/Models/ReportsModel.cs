using System;
using System.ComponentModel.DataAnnotations;

namespace AspNetIdentity.WebClientAdmin.Models
{
    public class ReportsModel
    {
        public int Id_UserTest { get; set; }

        [Display(Name = "Fecha")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime LastUpdate { get; set; }

        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Display(Name = "A. Paterno")]
        public string FirstName { get; set; }

        [Display(Name = "A. Materno")]
        public string LastName { get; set; }

        public string Email { get; set; }

        [Display(Name = "Evaluación")]
        public string Test { get; set; }

        public int Id_StatusTest { get; set; }

        [Display(Name = "Estatus")]
        public string StatusTest { get; set; }
    }
}