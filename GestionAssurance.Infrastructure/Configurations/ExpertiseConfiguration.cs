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
    public class ExpertiseConfiguration : IEntityTypeConfiguration<Expertise>
    {
        public void Configure(EntityTypeBuilder<Expertise> builder)
        {
            builder.HasKey(e => new { e.ExpertFK, e.SinistreFK, e.DateExpertise });
            builder.HasOne(e => e.Expert).WithMany(a => a.Expertises).HasForeignKey(e => e.ExpertFK);
            builder.HasOne(e => e.Sinistre).WithMany(a => a.Expertises).HasForeignKey(e => e.SinistreFK);
        }
    }
}
