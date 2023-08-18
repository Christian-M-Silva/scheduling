using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entites
{
    public class PatientsEntity : BaseEntity
    {
        public string Name { get; set; }

        public string Cpf { get; set; }

        public string MainNumber { get; set; }

        public string OtherNumber { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public string Adress { get; set; }

        public string ServiceType { get; set; }

        public DateTime ConsultationDate { get; set; }
    }
}
