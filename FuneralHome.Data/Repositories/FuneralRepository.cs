using AutoMapper;
using FuneralHome.Data.Entities;
using FuneralHome.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuneralHome.Data.Repositories
{
    public class FuneralRepository : FuneralHomeRepository<Funeral>
    {
        private readonly FuneralHomeContext _ctx;
        private readonly IMapper _mapper;
        public FuneralRepository(FuneralHomeContext context) : base(context)
        {
            _ctx = context;

        }

    }
}
