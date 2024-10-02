using URF_Cinema.Application.ViewModels.Excels.Mics;
using Newtonsoft.Json.Linq;
using OfficeOpenXml;
using System.ComponentModel.DataAnnotations;

namespace URF_Cinema.Infrastructure.Implements.Services.Additional
{
    public class ExcelServices<T>
    {
        private readonly List<string>? ListExcelHeaders;

        public ExcelServices(List<string>? listExcelHeaders = null)
        {
            ListExcelHeaders = listExcelHeaders;
        }
        public async Task<ExcelValidationResultVM> Validate(MemoryStream stream, List<ExcelAcceptedValueVM>? lstAcceptedValues = null, int startRow = 1)
        {
            ExcelValidationResultVM result = new();

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            var package = new ExcelPackage(stream);
            var workbook = package.Workbook;
            var worksheet = workbook.Worksheets.First();

            worksheet = TrimWorksheet(worksheet);

            var countRow = worksheet.Dimension.End.Row;
            var countCol = worksheet.Dimension.End.Column;

            var props = typeof(T).GetProperties();


            for (var row = startRow; row <= countRow; row++)
            {
                bool isValidRow = true;
                for (var col = 1; col <= props.Count(); col++)
                {
                    var prop = props[col - 1];
                    //Just to be clear and easily access the flow, so I don't merge all the validations into one line.
                    var val = worksheet.Cells[row, col].Value == null ? "" : worksheet.Cells[row, col].Value.ToString();

                    var isValidValidation = true;

                    var errorMessage = "";
                    //Then data annotation
                    if (ProcValidationDataAnnotation(typeof(T), prop.Name, val) != null)
                    {
                        var dataAnnotationMessage = ProcValidationDataAnnotation(typeof(T), prop.Name, val);
                        isValidValidation = false;
                        errorMessage = " (Lỗi: " + dataAnnotationMessage + ")";
                    }
                }
                if (isValidRow)
                {
                    result.ValidRows.Add(row);
                }
            }

            var fileBytes = package.GetAsByteArray();
            var memoryStream = new MemoryStream(fileBytes);

            result.MemoryStream = memoryStream;
            return result;
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
        private string? ProcValidationDataAnnotation(Type modelType, string propertyName, string propertyValue)
        {
            var propertyInfo = modelType.GetProperty(propertyName);
            if (propertyInfo == null)
                throw new ArgumentException($"The property '{propertyName}' does not exist on type '{modelType.Name}'.");

            var attributes = propertyInfo.GetCustomAttributes(typeof(ValidationAttribute), true);
            foreach (var attribute in attributes)
                if (attribute is ValidationAttribute validationAttribute)
                {
                    var parsedValue = Convert.ChangeType(propertyValue, propertyInfo.PropertyType);
                    if (!validationAttribute.IsValid(parsedValue))
                        return validationAttribute.ErrorMessage;
                }
            return null;
        }
        private ExcelWorksheet TrimWorksheet(ExcelWorksheet worksheet)
        {
            var lastRow = worksheet.Dimension.End.Row;
            var lastColumn = worksheet.Dimension.End.Column;

            // Remove blank rows
            for (var row = lastRow; row >= 1; row--)
            {
                var isRowEmpty = true;

                for (var col = worksheet.Dimension.Start.Column; col <= lastColumn; col++)
                {
                    var cellValue = worksheet.Cells[row, col]?.Value;
                    if (cellValue != null)
                    {
                        isRowEmpty = false;
                        break;
                    }
                }

                if (isRowEmpty) worksheet.DeleteRow(row);
            }

            // Remove blank columns
            for (var column = lastColumn; column >= 1; column--)
            {
                var isColumnEmpty = true;

                for (var row = worksheet.Dimension.Start.Row; row <= lastRow; row++)
                {
                    var cellValue = worksheet.Cells[row, column]?.Value;
                    if (cellValue != null)
                    {
                        isColumnEmpty = false;
                        break;
                    }
                }

                if (isColumnEmpty) worksheet.DeleteColumn(column);
            }

            return worksheet;
        }
    }
}
