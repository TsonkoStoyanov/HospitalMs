namespace HospitalMS.Data.Models
{
    using System.Collections.Generic;
    public class Hospital : BaseModel<string>
    {
        public Hospital()
        {
            this.Departaments = new HashSet<Departament>();
            this.Users = new HashSet<HospitalMSUser>();
        }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public ICollection<Departament> Departaments { get; set; }
        public ICollection<HospitalMSUser> Users { get; set; }

    }
}
