namespace URF_Cinema.Application.ViewModels.Excels.Mics
{
    public class ExcelValidationResultVM
    {
        public List<int> ValidRows { get; set; } = new();
        public MemoryStream? MemoryStream { get; set; }
    }
}
