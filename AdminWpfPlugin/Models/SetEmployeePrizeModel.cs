namespace AdminWpfPlugin.Models
{
    public class SetEmployeePrizeModel
    {
        public int EmployeeId { get; set; }
        public string EmployeeFirstName { get; set; }
        public string EmployeeSecondName { get; set; }
        public double? CurrentPrize { get; set; }
        public double EditPrize { get; set; }
    }
}
