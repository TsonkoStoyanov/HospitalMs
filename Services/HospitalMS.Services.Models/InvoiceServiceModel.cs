namespace HospitalMS.Services.Models
{
    using System;
    using HospitalMS.Data.Models;
    using HospitalMS.Services.Mapping;


    public class InvoiceServiceModel : IMapTo<Invoice>, IMapFrom<Invoice>
    {
        public string Id { get; set; }

        public int Number { get; set; }

        public DateTime IssuedOn { get; set; } = DateTime.UtcNow;

        public DateTime DateOfAcceptance { get; set; }

        public DateTime DateOfDischarge { get; set; }

        public decimal TotalPrice { get; set; }

        public PatientServiceModel Patient { get; set; }

        public ReceptionistServiceModel Receptionist { get; set; }
    }
}
