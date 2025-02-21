using System.ComponentModel.DataAnnotations;

namespace PROGETTO_U4_S2_L5.Models {
    public class ArticoloAdd {
        public string Nome {
            get; set;
        }

        [Display(Name = "Proposta di prezzo")]
        public decimal Prezzo {
            get; set;
        }

        public string Descrizione {
            get; set;
        }

        [Display(Name = "Immagine principale (URL)")]
        public string Immagine {
            get; set;
        }

        [Display(Name = "Immagine extra 1 (URL)")]
        public string ImmagineAggiuntiva1 {
            get; set;
        }

        [Display(Name = "Immagine extra 2 (URL)")]
        public string ImmagineAggiuntiva2 {
            get; set;
        }
    }
}
