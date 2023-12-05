using GestionAssurance.ApplicationCore.Domain;
using GestionAssurance.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionAssurance.ApplicationCore.Services
{
    public class AssuranceService : Service<Assurance>, IAssuranceService
    {
        public AssuranceService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
        public float pourcentage(TypeAssurance typeAssurance)
        {
            var nbre = GetAll().Count();

            return GetMany(a => a.Type == typeAssurance).Count()*100/nbre;
        }
    }
}
