using FuneralHome.Data;
using FuneralHome.Domain.Models;
using System.Collections.Generic;

namespace FuneralHome.Domain.Interfaces
{
    public interface IFuneralService
    {
        IEnumerable<FuneralModel> GetAll();
        FuneralModel Create(FuneralModel model);
        void Update(FuneralModel model, int id);
        FuneralModel GetById(int id);
        void Remove(FuneralModel model);
    }
}
