using System.Collections.Generic;

namespace HospitalMS.Data.Models
{
    public class Room
    {
        public Room()
        {
            this.Beds = new HashSet<Bed>();
        }
        public string Id { get; set; }

        public string Name { get; set; }

        public ICollection<Bed> Beds { get; set; }
    }
}