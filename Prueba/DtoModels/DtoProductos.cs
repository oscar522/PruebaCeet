using System;
using System.ComponentModel.DataAnnotations;

namespace DtoModels
{
    public class DtoProductos
    {
        public int id { get; set; }

        [Display(Name = "PRODUCTO")]
        [Required(ErrorMessage = "Debe ingresar un Producto")]
        public string Producto { get; set; }

        [Display(Name = "VALOR")]
        [Required(ErrorMessage = "Debe ingresar un valor")]
        public  int  valor { get; set; }

        [Display(Name = "DESCRIPCION")]
        [Required(ErrorMessage = "Debe ingresar una descripcion")]
        public string descripcion { get; set; }

        public int idAliado { get; set; }

        [Display(Name = "NOMBRE ALIADO")]
        [Required(ErrorMessage = "Debe ingresar un Aliado")]
        public string NombreAliado { get; set; }

        [Display(Name = "Estado")]
        public  bool  Estado { get; set; }

    }
}
