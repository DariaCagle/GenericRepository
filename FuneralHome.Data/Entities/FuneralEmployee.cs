namespace FuneralHome.Data.Entities
{
    public class FuneralEmployee
    {
        public int FuneralId { get; set; }
        public Funeral Funeral { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
