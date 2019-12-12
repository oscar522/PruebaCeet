using System;
using System.ComponentModel.DataAnnotations;

namespace DtoModels
{
    public class DtoCompraProducto
    {


        public int id { get; set; }

        [Display(Name = "PRODUCTO")]
        [Required(ErrorMessage = "Debe ingresar un Producto")]
        public  int IdProducto { get; set; }

        [Display(Name = "NOMBRE PRODUCTO")]
        [Required(ErrorMessage = "Debe ingresar un Producto")]
        public string NombreProducto { get; set; }

        [Display(Name = "ALIADO")]
        [Required(ErrorMessage = "Debe ingresar un Aliado")]
        public int IdAliado { get; set; }

        [Display(Name = "NOMBRE ALIADO")]
        [Required(ErrorMessage = "Debe ingresar un Aliado")]
        public string NombreAliado { get; set; }


        [Display(Name = "CLIENTE")]
        [Required(ErrorMessage = "Debe ingresar un Cliente")]
        public int IdCliente { get; set; }

        [Display(Name = "NOMBRE CLIENTE")]
        [Required(ErrorMessage = "Debe ingresar un Cliente")]
        public string NombreCliente { get; set; }

        [Display(Name = "FECHA")]
        [Required(ErrorMessage = "Debe ingresar una Fecha")]
        public DateTime Fecha { get; set; }

        [Display(Name = "Estado")]
        public bool Estado { get; set; }

    }
}
