namespace HospitalMS.Services.Models
{
    using System;
    using System.Collections.Generic;
    using HospitalMS.Data.Models;
    using HospitalMS.Services.Mapping;

    public class PatientServiceModel : IMapTo<Patient>, IMapFrom<Patient>
    {
        public string Id { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime BirthDate { get; set; }

        public int YearOfBirth { get; set; }

        public string Address { get; set; }

        public bool IsHospitalized { get; set; }

        public DateTime? DateOfAcceptance { get; set; }

        public DateTime? DateOfDischarge { get; set; }

        public string HospitalMSUserId { get; set; }

        public BedServiceModel Bed { get; set; }

        public virtual DepartmentServiceModel Department { get; set; }

        public List<AppointmentServiceModel> Appointments { get; set; }

        public List<DiagnoseServiceModel> Diagnoses { get; set; }

        public List<InvoiceServiceModel> Invoices { get; set; }
    }
}
