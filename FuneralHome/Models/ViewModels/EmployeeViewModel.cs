using FuneralHome.Common.Enums;

namespace FuneralHome.Models.ViewModels
{
    public class EmployeeViewModel
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public EmployeePositionEnum Position { get; set; }
    }
}
