using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalMS.Data.Models
{
    public class Hospital
    {
        public Hospital()
        {
            this.Departaments = new HashSet<Departament>();
            this.Users = new HashSet<HospitalMSUser>();
        }

        public string Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public ICollection<Departament> Departaments { get; set; }
        public ICollection<HospitalMSUser> Users { get; set; }

    }
}
