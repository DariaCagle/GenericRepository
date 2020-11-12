using FuneralHome.Common.Enums;
using System;
using System.Collections.Generic;

namespace FuneralHome.Models.ViewModels
{
    public class FuneralViewModel
    {
        public int Id { get; set; }
        public DateTime DateUtc { get; set; }
        public FuneralTypeEnum Type { get; set; }

        public int ClientId { get; set; }
        public ClientViewModel Client { get; set; }

        public IEnumerable<EmployeeViewModel> Employees { get; set; }
    }
}
