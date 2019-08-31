namespace HospitalMS.Data.Models
{
    using Microsoft.AspNetCore.Identity;


    public class HospitalMSUser : IdentityUser
    {
        public bool IsFirstLogin { get; set; } = true;
    }
}
