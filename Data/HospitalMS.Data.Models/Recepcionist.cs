﻿namespace HospitalMS.Data.Models
{
    public class Recepcionist : BaseModel<string>
    {
        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }


        public string HospitalMSUserId { get; set; }
        public virtual HospitalMSUser UserRecepcionist { get; set; }
    }
}
