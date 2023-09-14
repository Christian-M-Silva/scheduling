using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entites
{
    public abstract class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }

        private DateTime? _createdAt;

        public DateTime? CreatedAT
        {
            get { return _createdAt; }
            set { _createdAt = value == null ? DateTime.Now : value; }
        }

        public DateTime? UpdateAt { get; set; }
    }
}
