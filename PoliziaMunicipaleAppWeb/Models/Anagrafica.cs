using System.ComponentModel.DataAnnotations;

namespace PoliziaMunicipaleAppWeb.Models
{
    public class Anagrafica
    {
        [Key]
        public int IdAnagrafica { get; set; }
        public string Cognome { get; set; }
        public string Nome { get; set; }
        public string Indirizzo { get; set; }
        public string Citta { get; set; }
        public string CAP { get; set; }
        public string Cod_Fisc { get; set; }
        public virtual ICollection<Verbale> Verbali { get; set; }
    }
}
