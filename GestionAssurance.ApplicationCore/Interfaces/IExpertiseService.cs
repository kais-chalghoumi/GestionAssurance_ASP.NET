using GestionAssurance.ApplicationCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionAssurance.ApplicationCore.Interfaces
{
    public interface IExpertiseService : IService<Expertise>
    {
        int nombreExpertisesParExpert(int idExpert, Assurance assurance);
    }
}
