using System.Collections.Generic;

namespace FuneralHome.Data.Entities
{
    public class Employee
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public int Position { get; set; }

        public virtual ICollection<FuneralEmployee> FuneralEmployees { get; set; }
    }
}
