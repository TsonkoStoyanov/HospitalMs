using Microsoft.AspNetCore.Identity;

namespace HospitalMS.Data.Models
{
    public class HospitalMSUser : IdentityUser
    {

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        
    }
}
