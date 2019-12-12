using System;
using System.ComponentModel.DataAnnotations;

namespace DtoModels
{
    public class DtoAliados
    {
        public int id { get; set; }

        [Display(Name = "Aliado")]
        [Required(ErrorMessage = "Debe ingresar una Nombre de Aliado ")]
        public string Aliado { get; set; }

        [Display(Name = "Estado")]
        public  bool  Estado { get; set; }

    }
}
