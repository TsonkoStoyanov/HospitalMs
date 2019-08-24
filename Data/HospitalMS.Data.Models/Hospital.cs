namespace HospitalMS.Data.Models
{
    using System.Collections.Generic;
    public class Hospital : BaseModel<string>
    {
        public Hospital()
        {
            this.Departments = new List<Department>();
        }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public List<Department> Departments { get; set; }

    }
}
