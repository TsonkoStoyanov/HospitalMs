namespace HospitalMS.Services.Models
{
    using System;


    public class InvoiceServiceModel
    {
        public int Number { get; set; }

        public DateTime IssuedOn { get; set; }

        public DateTime DateOfAcceptance { get; set; }

        public DateTime DateOfDischarge { get; set; }

        public decimal TotalPrice { get; set; }

        public virtual PatientServiceModel Patient { get; set; }
    }
}
