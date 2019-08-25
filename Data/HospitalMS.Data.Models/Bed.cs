﻿namespace HospitalMS.Data.Models
{
    public class Bed : BaseModel<int>
    {
        public int Number { get; set; }
        public bool IsOcupied { get; set; } = false;

        public string RoomId { get; set; }
        public virtual Room Room { get; set; }

        public string HospitalMSUserId { get; set; }

        public virtual HospitalMSUser Patient { get; set; }

    }
}