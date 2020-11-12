﻿using System.Collections.Generic;

namespace FuneralHome.Domain.Models
{
    public class ClientModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public int? DeathCertificateNumber { get; set; }

        public IEnumerable<FuneralModel> Funerals { get; set; }
    }
}
