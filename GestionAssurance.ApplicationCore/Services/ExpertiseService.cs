using GestionAssurance.ApplicationCore.Domain;
using GestionAssurance.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionAssurance.ApplicationCore.Services
{
    public class ExpertiseService : Service<Expertise>, IExpertiseService
    {
        public ExpertiseService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
        public int nombreExpertisesParExpert(int idExpert, Assurance assurance)
        {
            return GetMany(e => e.ExpertFK == idExpert && e.Sinistre.Assurance == assurance).Count();
        }
    }
}
