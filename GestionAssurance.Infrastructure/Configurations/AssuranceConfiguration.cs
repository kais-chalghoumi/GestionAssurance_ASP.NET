using GestionAssurance.ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionAssurance.Infrastructure.Configurations
{
    public class AssuranceConfiguration : IEntityTypeConfiguration<Assurance>
    {
        public void Configure(EntityTypeBuilder<Assurance> builder)
        {
            builder.HasMany(a => a.Sinistres).WithOne(s => s.Assurance).HasForeignKey(s => s.AssuranceFK);
        }
    }
}
