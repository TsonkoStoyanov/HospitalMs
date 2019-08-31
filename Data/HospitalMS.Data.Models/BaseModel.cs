namespace HospitalMS.Data.Models
{
    using HospitalMS.Data.Common.Models;
    using System;
    using System.ComponentModel.DataAnnotations;


    public abstract class BaseModel<TKey> : IDeletableEntity
    {
        [Key]
        public TKey Id { get; set; }

        public bool IsDeleted { get ; set ; }
        public DateTime? DeletedOn { get; set; }
    }
}