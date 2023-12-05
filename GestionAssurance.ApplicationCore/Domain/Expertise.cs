using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionAssurance.ApplicationCore.Domain
{
    public class Expertise
    {
        [DataType(DataType.Date,ErrorMessage ="fff")]
        public DateTime DateExpertise { get; set; }

        [DataType(DataType.MultilineText)]
        [MinLength(3)]
        [MaxLength(100)] 
        public string AvisTechnique { get; set; }

        public double MontantEstime { get; set; }

        public double Duree { get; set; }

        public virtual Expert Expert { get; set; }

        public virtual Sinistre Sinistre { get; set; }

        public int ExpertFK { get; set; }

        public int SinistreFK { get; set; }
    }
}
