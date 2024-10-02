namespace URF_Cinema.Application.DataTransferObjects.Bill
{
    public class BillStatisticForMonthDto
    {
        public int Month {  get; set; }
        public int Year { get; set; }
        public double Revenue { get; set; }
        
        public string DepartmentName { get; set; }
    }
}
