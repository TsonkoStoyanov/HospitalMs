using System.Collections.Generic;

namespace HospitalMS.Data.Models
{
    public class Receptionist : BaseModel<string>
    {
        public Receptionist()
        {
            Invoices = new HashSet<Invoice>();
        }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }


        public string HospitalMSUserId { get; set; }
        public virtual HospitalMSUser UserReceptionist { get; set; }

        public string HospitalId { get; set; }
        public virtual Hospital Hospital { get; set; }

        public virtual ICollection<Invoice> Invoices { get; set; }
    }
}
