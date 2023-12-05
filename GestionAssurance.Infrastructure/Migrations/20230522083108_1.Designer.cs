﻿// <auto-generated />
using System;
using GestionAssurance.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GestionAssurance.Infrastructure.Migrations
{
    [DbContext(typeof(GestionAssuranceContext))]
    [Migration("20230522083108_1")]
    partial class _1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Examen.ApplicationCore.Domain.Assurance", b =>
                {
                    b.Property<int>("AssuranceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AssuranceId"));

                    b.Property<DateTime>("DateEcheance")
                        .HasColumnType("date");

                    b.Property<DateTime>("DateEffet")
                        .HasColumnType("date");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("AssuranceId");

                    b.ToTable("Assurances");
                });

            modelBuilder.Entity("Examen.ApplicationCore.Domain.Expert", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("DomaineExpertise")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prenom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("TarifHoraire")
                        .HasColumnType("float");

                    b.Property<string>("Tel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Experts");
                });

            modelBuilder.Entity("Examen.ApplicationCore.Domain.Expertise", b =>
                {
                    b.Property<int>("ExpertFK")
                        .HasColumnType("int");

                    b.Property<int>("SinistreFK")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateExpertise")
                        .HasColumnType("date");

                    b.Property<string>("AvisTechnique")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<double>("Duree")
                        .HasColumnType("float");

                    b.Property<double>("MontantEstime")
                        .HasColumnType("float");

                    b.HasKey("ExpertFK", "SinistreFK", "DateExpertise");

                    b.HasIndex("SinistreFK");

                    b.ToTable("Expertises");
                });

            modelBuilder.Entity("Examen.ApplicationCore.Domain.Sinistre", b =>
                {
                    b.Property<int>("SinistreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SinistreId"));

                    b.Property<int>("AssuranceFK")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateDeclaration")
                        .HasColumnType("date");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lieu")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SinistreId");

                    b.HasIndex("AssuranceFK");

                    b.ToTable("Sinistres");
                });

            modelBuilder.Entity("Examen.ApplicationCore.Domain.Expertise", b =>
                {
                    b.HasOne("Examen.ApplicationCore.Domain.Expert", "Expert")
                        .WithMany("Expertises")
                        .HasForeignKey("ExpertFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Examen.ApplicationCore.Domain.Sinistre", "Sinistre")
                        .WithMany("Expertises")
                        .HasForeignKey("SinistreFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Expert");

                    b.Navigation("Sinistre");
                });

            modelBuilder.Entity("Examen.ApplicationCore.Domain.Sinistre", b =>
                {
                    b.HasOne("Examen.ApplicationCore.Domain.Assurance", "Assurance")
                        .WithMany("Sinistres")
                        .HasForeignKey("AssuranceFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Assurance");
                });

            modelBuilder.Entity("Examen.ApplicationCore.Domain.Assurance", b =>
                {
                    b.Navigation("Sinistres");
                });

            modelBuilder.Entity("Examen.ApplicationCore.Domain.Expert", b =>
                {
                    b.Navigation("Expertises");
                });

            modelBuilder.Entity("Examen.ApplicationCore.Domain.Sinistre", b =>
                {
                    b.Navigation("Expertises");
                });
#pragma warning restore 612, 618
        }
    }
}