using System.ComponentModel.DataAnnotations;

namespace PoliziaMunicipaleAppWeb.Models
{
    public class Verbale
    {
        [Key]
        public int IdVerbale { get; set; }
        public DateTime DataViolazione { get; set; }
        public string IndirizzoViolazione { get; set; }
        public string Nominativo_Agente { get; set; }
        public DateTime DataTrascrizioneVerbale { get; set; }
        public decimal Importo { get; set; }
        public int DecurtamentoPunti { get; set; }

        // Chiavi esterne
        public int IdAnagrafica { get; set; }
        public int IdViolazione { get; set; }


        public virtual Anagrafica Anagrafica { get; set; }
        public virtual TipoViolazione TipoViolazione { get; set; }
    }
}
