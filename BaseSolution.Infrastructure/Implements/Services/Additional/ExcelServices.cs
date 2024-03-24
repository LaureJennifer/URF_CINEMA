using BaseSolution.Application.ViewModels.Excels.Mics;
using Newtonsoft.Json.Linq;
using OfficeOpenXml;

namespace BaseSolution.Infrastructure.Implements.Services.Additional
{
    public class ExcelServices<T>
    {
        private readonly List<string>? ListExcelHeaders;

        public ExcelServices(List<string>? listExcelHeaders = null)
        {
            ListExcelHeaders = listExcelHeaders;
        }

        public async Task<List<T>> GetValueFromFileStream(MemoryStream stream, int startRow = 2, string? sheetName = null)
        {
            ExcelValidationResultVM result = new();
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            var package = new ExcelPackage(stream);
            var workbook = package.Workbook;
            var findWorkSheet = sheetName == null ? workbook.Worksheets.FirstOrDefault(c => c.Name == sheetName) : workbook.Worksheets.First();
            var worksheet = findWorkSheet == null ? workbook.Worksheets.First() : findWorkSheet;

            //worksheet = TrimWorksheet(worksheet);

            var countRow = worksheet.Dimension.End.Row;
            var countCol = worksheet.Dimension.End.Column;

            var props = typeof(T).GetProperties();


            var listObjHeaders = typeof(T).GetProperties().Select(c => c.Name).ToList();
            var listExcelHeaders = ListExcelHeaders ?? listObjHeaders;

            JArray jArrResult = new();

            for (var i = 1; i <= countRow; i++)
            {
                JObject jObj = new();
                foreach (var header in listObjHeaders)
                {
                    var curCol = listObjHeaders.IndexOf(header) + 1;
                    var valCol = worksheet.Cells[i, curCol].Value;
                    jObj[header] = valCol == null ? "" : valCol.ToString();
                }

                jArrResult.Add(jObj);
            }

            List<T> listResult = new();

            foreach (var jToken in jArrResult)
            {
                var obj = jToken.ToObject<T>();
                listResult.Add(obj);
            }

            return listResult;
        }
    }
}
