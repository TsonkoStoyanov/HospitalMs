namespace HospitalMS.Data.Models
{
    using Microsoft.AspNetCore.Identity;

    public class HospitalMSUser : IdentityUser
    {


        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }


    }
}
