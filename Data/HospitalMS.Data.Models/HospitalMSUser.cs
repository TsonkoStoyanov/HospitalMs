namespace HospitalMS.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using System;


    public class HospitalMSUser : IdentityUser
    {
        public int Age { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

    }
}
