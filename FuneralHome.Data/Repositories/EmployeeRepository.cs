using FuneralHome.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace FuneralHome.Data.Repositories
{
    public class EmployeeRepository
    {
        private readonly FuneralHomeContext _ctx;
        public EmployeeRepository(FuneralHomeContext context)
        {
            _ctx = new FuneralHomeContext();
        }
        public IEnumerable<Employee> GetByIds(IEnumerable<int> employeeids)
        {
            return _ctx.Employees
                .Include(x => x.FuneralEmployees.Select(y=>y.Funeral))
                .Where(x => employeeids.Contains(x.ID))
                .AsNoTracking()
                .ToList();
        }
    }
}
