using FuneralHome.Common.Enums;
using System;
using System.Collections.Generic;

namespace FuneralHome.Models.PostModels
{
    public class FuneralPostModel
    {
        public DateTime DateUtc { get; set; }
        public FuneralTypeEnum Type { get; set; }

        public int ClientId { get; set; }
        public ClientPostModel Client { get; set; }

        public IEnumerable<int> EmployeeIds { get; set; }
    }
}
