using GestionAssurance.ApplicationCore.Domain;
using GestionAssurance.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionAssurance.ApplicationCore.Services
{
    public class SinistreService : Service<Sinistre>, ISinistreService
    {
        public SinistreService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
