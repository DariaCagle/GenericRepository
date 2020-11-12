using FuneralHome.Common.Enums;
using System.Collections.Generic;

namespace FuneralHome.Domain.Models
{
    public class EmployeeModel
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public EmployeePositionEnum Position { get; set; }

        public IEnumerable<FuneralModel> Funerals { get; set; }
    }

}
