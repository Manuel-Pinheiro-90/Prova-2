using System.ComponentModel.DataAnnotations;

namespace Prova_2.Models
{
    public class ArticoloInputModel
    {

        [Required(ErrorMessage = "Il campo {0} è obbligatorio.")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Il campo {0} è obbligatorio.")]
        
        public int Prezzo { get; set; }
        [Required(ErrorMessage = "Il campo {0} è obbligatorio.")]
        public string Descrizione { get; set; }
        [Required(ErrorMessage = "Il campo {0} è obbligatorio.")]
        public IFormFile ImmagineCopertina { get; set; }
        [Required(ErrorMessage = "Il campo {0} è obbligatorio.")]
        public IFormFile ImmagineAggiuntiva1 { get; set; }
        [Required(ErrorMessage = "Il campo {0} è obbligatorio.")]
        public IFormFile ImmagineAggiuntiva2 { get; set; }


    }
}
