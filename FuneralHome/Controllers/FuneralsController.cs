using AutoMapper;
using FuneralHome.Domain.Interfaces;
using FuneralHome.Domain.Models;
using FuneralHome.Domain.Services;
using FuneralHome.Models.PostModels;
using FuneralHome.Models.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace FuneralHome.Controllers
{
    public class FuneralsController
    {
        private readonly IFuneralService _funeralService;
        private readonly IMapper _mapper;


        public FuneralsController()
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<FuneralModel, FuneralViewModel>().ReverseMap();
                cfg.CreateMap<ClientModel, ClientViewModel>().ReverseMap();
                cfg.CreateMap<EmployeeModel, EmployeeViewModel>().ReverseMap();
                cfg.CreateMap<FuneralPostModel, FuneralModel>()
                .ForMember(x => x.Employees, opts => opts.MapFrom(src => src.EmployeeIds.Select(y => new EmployeeModel { ID = y })));

            });

            _mapper = new Mapper(mapperConfig);
            _funeralService = new FuneralService();

        }
        public IEnumerable<FuneralViewModel> GetAll()
        {
            var funerals = _funeralService.GetAll();
            return _mapper.Map<IEnumerable<FuneralViewModel>>(funerals);
        }

        public FuneralViewModel Create(FuneralPostModel model)
        {
            var funeralModel = _mapper.Map<FuneralModel>(model);

            var createdModel = _funeralService.Create(funeralModel);

            return _mapper.Map<FuneralViewModel>(createdModel);
        }
        public void Update(FuneralPostModel model, int id)
        {
            var funeral = _mapper.Map<FuneralModel>(model);
            funeral.Id = id;
            _funeralService.Update(funeral, id);
        }

        public FuneralViewModel GetById(int id)
        {
            var funeral = _funeralService.GetById(id);
            return _mapper.Map<FuneralViewModel>(funeral);
        }

        public void Remove(FuneralPostModel model)
        {

            var funeral = _mapper.Map<FuneralModel>(model);
            _funeralService.Remove(funeral);
        }
    }
}
