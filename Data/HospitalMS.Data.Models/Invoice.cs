namespace HospitalMS.Data.Models
{
    using System;


    public class Invoice : BaseModel<string>
    {
        public int Number { get; set; }

        public DateTime IssuedOn { get; set; } = DateTime.UtcNow;

        public DateTime DateOfAcceptance { get; set; }

        public DateTime DateOfDischarge { get; set; }

        public decimal TotalPrice { get; set; }

        public string PatientId { get; set; }

        public virtual Patient Patient { get; set; }

    }
}
