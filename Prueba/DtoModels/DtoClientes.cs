using System;
using System.ComponentModel.DataAnnotations;

namespace DtoModels
{
    public class DtoClientes
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Debe ingresar un Nombre ")]
        [Display(Name = "NOMBRE")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Debe ingresar un Apellido ")]
        [Display(Name = "APELLIDOS")]
        public string Apellidos { get; set; }

        [Required(ErrorMessage = "Debe ingresar una Identificacion ")]
        [Display(Name = "IDENTIFICACION")]
        public int Identificacion { get; set; }

        [Required(ErrorMessage = "Debe ingresar una Direccion ")]
        [Display(Name = "DIRECCION")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "Debe ingresar un Email")]
        [Display(Name = "EAMIL")]
        public string Email { get; set; }

        [Display(Name = "Estado")]
        public bool Estado { get; set; }
    }
}
