using System;
using System.ComponentModel.DataAnnotations;

namespace DtoModels
{
    public class DtoVendedor
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Debe ingresar un Nombre ")]
        [Display(Name = "NOMBRE")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Debe ingresar un Apellido ")]
        [Display(Name = "APELLIDOS")]
        public string Apellidos { get; set; }

        [Required(ErrorMessage = "Debe ingresar una Identificacion ")]
        [Display(Name = "IDENTIFICACION")]
        public long Identificacion { get; set; }

        [Required(ErrorMessage = "Debe ingresar una Ciudad ")]
        [Display(Name = "Ciudad")]
        public int IdCiudad { get; set; }

        [Required(ErrorMessage = "Debe ingresar una Ciudad ")]
        [Display(Name = "Nombre Ciudad")]
        public string NombreCiudad { get; set; }

        [Display(Name = "Estado")]
        public bool Estado { get; set; }
    }
}
