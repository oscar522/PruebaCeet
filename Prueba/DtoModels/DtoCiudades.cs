using System.ComponentModel.DataAnnotations;

namespace DtoModels
{
    public class DtoCiudades
    {
        public int Id { get; set; }

        [Display(Name = "Ciudad")]
        [Required(ErrorMessage = "Debe ingresar una Ciudad ")]
        public string Nombre { get; set; }

        [Display(Name = "Estado")]
        public  bool  Estado { get; set; }

    }
}
