using System.ComponentModel.DataAnnotations;

namespace PoliziaMunicipaleAppWeb.Models
{
    public class TipoViolazione
    {
        [Key]
        public int Id { get; set; } 
        public string Descrizione { get; set; }
        public ICollection<Verbale> Verbali { get; set; }
    }
}
