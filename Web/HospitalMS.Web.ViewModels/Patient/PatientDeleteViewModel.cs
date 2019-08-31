namespace HospitalMS.Web.ViewModels.Patient
{
    using System;
    using HospitalMS.Services.Mapping;
    using HospitalMS.Services.Models;

    public class PatientDeleteViewModel : IMapFrom<PatientServiceModel>
    {
        public string Id { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        public DateTime BirthDate { get; set; }

        public bool IsHospitalized { get; set; }

        public string DepartmentName { get; set; }

    }
}
