using GestionAssurance.ApplicationCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionAssurance.ApplicationCore.Interfaces
{
    public interface IAssuranceService : IService<Assurance>
    {
        float pourcentage(TypeAssurance typeAssurance);
    }
}
