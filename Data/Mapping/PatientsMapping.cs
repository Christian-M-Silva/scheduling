using Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Mapping
{
    public class PatientsMapping : IEntityTypeConfiguration<PatientsEntity>
    {
        public void Configure(EntityTypeBuilder<PatientsEntity> builder)
        {
            builder.ToTable("Patients");

            builder.HasKey(patient => patient.Id);

            builder.Property(patient => patient.Name).IsRequired().HasMaxLength(100);

            builder.Property(patient => patient.Cpf).IsRequired().HasMaxLength(11);

            builder.Property(patient => patient.MainNumber).IsRequired();

            builder.Property(patient => patient.Email).HasMaxLength(256).HasAnnotation("EmailAddress", true);

            builder.Property(patient => patient.Adress).IsRequired();

            builder.Property(patient => patient.ServiceType).IsRequired();

            builder.Property(patient => patient.ConsultationDate).IsRequired();
        }
    }
}
