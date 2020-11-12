using AutoMapper;
using FuneralHome.Data;
using FuneralHome.Data.Entities;
using FuneralHome.Data.Interfaces;
using FuneralHome.Data.Repositories;
using FuneralHome.Domain.Interfaces;
using FuneralHome.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;

namespace FuneralHome.Domain.Services
{
    public class FuneralService : IFuneralService
    {
        private readonly IFuneralRepository<Funeral> _funeralRepository;
        private readonly EmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;
        public FuneralService()
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<FuneralModel, Funeral>()
                .ForMember(x => x.FuneralEmployees, opts => opts.MapFrom(src => src.Employees.Select(x => new FuneralEmployee
                {
                    EmployeeId = x.ID
                })));

                cfg.CreateMap<Funeral, FuneralModel>().ForMember(x => x.Employees, opts => opts.MapFrom(src => src.FuneralEmployees.Select(x => x.Employee)));

                cfg.CreateMap<ClientModel, Client>().ReverseMap();
                cfg.CreateMap<EmployeeModel, Employee>().ReverseMap();
            });

            _mapper = new Mapper(mapperConfig);

            _funeralRepository = new FuneralRepository(new FuneralHomeContext());
            _employeeRepository = new EmployeeRepository(new FuneralHomeContext());
        }
        public IEnumerable<FuneralModel> GetAll()
        {
            var funerals = _funeralRepository.GetAll();
            return _mapper.Map<IEnumerable<FuneralModel>>(funerals);
        }

        public FuneralModel Create(FuneralModel model)
        {
            var startTime = DateTime.UtcNow.AddHours(1);
            var endTime = DateTime.UtcNow.AddHours(7);

            // var periodStart = DateTime.UtcNow.Date;
            //var periodEnd = startTime.AddHours(24).AddMilliseconds(-1);

            var employeeIds = model.Employees.Select(x => x.ID);
            var employees = _employeeRepository.GetByIds(employeeIds);
            var funerals = employees
                .SelectMany(x => x.FuneralEmployees.Select(y=>y.Funeral))
                .Where(x => model.DateUtc.Date == x.DateUtc.Date)
                .ToList();

            foreach (var employee in employees)
            {
                if (employee.FuneralEmployees.Select(x => x.Funeral).Any(x => x.DateUtc.Date == model.DateUtc.Date))
                    throw new System.Exception($"Employee {employee.FirstName} {employee.LastName} is busy at this date");
            }

            //employees.ToList().ForEach(employee =>
            //{
            //    throw new System.Exception($"Employee {employee.FirstName} {employee.LastName} is busy at this date");
            //});

            var funeral = _mapper.Map<Funeral>(model);
            //funeral.Employees = employees.ToList(); - если нет таблицы

            var newFuneral = _funeralRepository.Create(funeral);

            return _mapper.Map<FuneralModel>(newFuneral);
        }

        public void Update(FuneralModel model, int id)
        {
            var funeral = _mapper.Map<Funeral>(model);

            _funeralRepository.Update(funeral, id);
        }

        public FuneralModel GetById(int id)
        {
            var funeral = _funeralRepository.GetById(id);
            return _mapper.Map<FuneralModel>(funeral);
        }

    }
}
