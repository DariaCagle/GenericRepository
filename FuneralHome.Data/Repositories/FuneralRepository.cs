using AutoMapper;
using FuneralHome.Data.Entities;

namespace FuneralHome.Data.Repositories
{
    public class FuneralRepository : FuneralHomeRepository<Funeral>
    {
        private readonly FuneralHomeContext _ctx;
        public FuneralRepository(FuneralHomeContext context) : base(context)
        {
            _ctx = context;

        }

    }
}
