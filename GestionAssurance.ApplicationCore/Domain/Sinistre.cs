﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionAssurance.ApplicationCore.Domain
{
    public class Sinistre
    {
        public int SinistreId { get; set; }

        public DateTime DateDeclaration { get; set; }

        public string Lieu { get; set; }

        public string Description { get; set; }

        public virtual Assurance Assurance { get; set; }

        public int AssuranceFK { get; set; }

        public virtual IList<Expertise> Expertises { get; set; }
    }
}
