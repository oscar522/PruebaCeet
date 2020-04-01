using System.ComponentModel.DataAnnotations;

namespace AspNetIdentity.WebClientAdmin.Models
{
    public class Perfil_Model
    {
        public int ID_PERFIL { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The {0} debe tener al menos {2} caracteres de longitud.", MinimumLength = 6)]
        [Display(Name = "NOMBRE")]
        public string NOMBRE { get; set; }
        public int AREA { get; set; }
        public int SUB_AREA { get; set; }
        public int REPORTA { get; set; }
        public int SUPERVISA { get; set; }
        public string OBJETIVO { get; set; }
    }
}