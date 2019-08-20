using System.Collections.Generic;

namespace HospitalMS.Data.Models
{
    public class Room : BaseModel<string>
    {
        public Room()
        {
            this.Beds = new HashSet<Bed>();
        }
        public string Name { get; set; }

        public ICollection<Bed> Beds { get; set; }
    }
}