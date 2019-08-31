namespace HospitalMS.Services.Models
{
    using HospitalMS.Data.Models;
    using HospitalMS.Services.Mapping;
    using System.Collections.Generic;



    public class ReceptionistServiceModel : IMapTo<Receptionist>, IMapFrom<Receptionist>
    {
        public string Id { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }


        public string HospitalMSUserId { get; set; }

        public string HospitalName { get; set; }

        public List<InvoiceServiceModel> Invoices { get; set; }
    }
}
