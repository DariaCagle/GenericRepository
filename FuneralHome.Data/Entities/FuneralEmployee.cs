using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuneralHome.Data.Entities
{
    public class FuneralEmployee
    {
        public int FuneralId { get; set; }
        public Funeral Funeral { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
