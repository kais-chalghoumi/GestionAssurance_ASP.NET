using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionAssurance.ApplicationCore.Domain
{
    public class Assurance
    {
        public int AssuranceId { get; set; }

        [DisplayName("Date Debut")]
        public DateTime DateEffet { get; set; }

        [DisplayName("Date Fin")]
        public DateTime DateEcheance { get; set; }

        public TypeAssurance Type { get; set; }

        public virtual IList<Sinistre> Sinistres { get; set; }


    }
}
