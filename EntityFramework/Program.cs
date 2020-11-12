using FuneralHome.Common.Enums;
using FuneralHome.Controllers;
using FuneralHome.Models.PostModels;
using System;
using System.Collections.Generic;
using FuneralHome.Data;
using AutoMapper;
using FuneralHome.Models.ViewModels;

namespace EntityFramework
{
    class Program
    {
        
        static void Main(string[] args)
        {
            var _controller = new FuneralsController();
            //var funerals = _controller.GetAll();

            //List<Param> funeralUpdateParams = new List<Param>();
            //funeralUpdateParams.Add(new Param("DateUtc", DateTime.UtcNow.AddDays(54)));

            var model = _controller.GetById(1);
            var modelForUpdate = ViewToPost<FuneralViewModel, FuneralPostModel>(model);

            modelForUpdate.DateUtc = DateTime.UtcNow.AddDays(5);
                        
            _controller.Update(modelForUpdate, 1);
        }

        public static Destination ViewToPost<Source, Destination>(Source sourceModel)
        {

            IMapper _mapper;

            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<FuneralPostModel, FuneralViewModel>().ReverseMap();
                cfg.CreateMap<ClientPostModel, ClientViewModel>().ReverseMap();
                cfg.CreateMap<EmployeePostModel, EmployeeViewModel>().ReverseMap();
                cfg.CreateMap<FuneralPostModel, FuneralPostModel>().ReverseMap();

            });

            _mapper = new Mapper(mapperConfig);

            return _mapper.Map<Destination>(sourceModel);
        }

    }
}
