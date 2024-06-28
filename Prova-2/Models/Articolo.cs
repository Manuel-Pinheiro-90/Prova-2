using System.ComponentModel.DataAnnotations;

namespace Prova_2.Models
{
    public class Articolo
    {
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        
        public decimal Prezzo {  get; set; } 
         [Required]
        public string Descrizione { get; set; }
        public string ImmagineCopertina { get; set; }
        public string ImmagineAggiuntiva1 { get; set; }
        public string ImmagineAggiuntiva2 { get; set; }








    }
}
