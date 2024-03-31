using BaseSolution.Application.Interfaces.Repositories.ReadWrite;
using BaseSolution.Application.ViewModels.Excels;
using BaseSolution.Application.ViewModels.Excels.Mics;
using BaseSolution.Domain.Entities;
using BaseSolution.Domain.Enums;
using BaseSolution.Infrastructure.Database.AppDbContext;
using BaseSolution.Infrastructure.Implements.Services.Additional;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BaseSolution.Infrastructure.Implements.Repositories.ReadWrite
{
    public class FileHandlingReadWriteRepository : IFileHandlingReadWriteRepository
    {
        private readonly IRoomLayoutReadWriteRepository _roomLayoutReadWrite;
        private readonly AppReadOnlyDbContext _dbContext;
        private readonly string _pathFolder;
        private CancellationToken cancellationToken;

        public FileHandlingReadWriteRepository(IRoomLayoutReadWriteRepository roomLayoutReadWrite)
        {
            _roomLayoutReadWrite = roomLayoutReadWrite;
            _dbContext = new AppReadOnlyDbContext();
            _pathFolder = Path.Combine(Directory.GetCurrentDirectory(), "SavedFiles");
            _pathFolder = Path.Combine(Directory.GetCurrentDirectory(), "SavedFiles");
            MkdirFunc(_pathFolder);
        }

        private void MkdirFunc(string folderPath)
        {
            List<string> lstFolders = new List<string>()
            {
                "Excels/Handled",
                "Excels/Handling",
                "Images",
            };

            foreach (var i in lstFolders)
            {
                var path = Path.Combine(folderPath, i);
                if (!File.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
            }
        }

        public async Task<ExcelOutputVM> ExcelImport(ExcelImportInputVM obj)
        {
            //Đổ FileData vào MemoryStream
            MemoryStream memStream = new MemoryStream(obj.FileData);
            var fileSplit = obj.FileName.Split('.');
            var fileExtension = "." + fileSplit[fileSplit.Count() - 1];
            var fileName = await ImportRoomLayout(memStream, fileExtension, obj.Parameters);
            return new()
            {
                IsSuccess = true,
                FileName = fileName,
            };
        }
        private async Task<string> ImportRoomLayout(MemoryStream stream, string fileExtension, List<ExcelParameterVM> lstParams)
        {

            //Khởi tạo 1 ExcelServices với tên các cột trong file Excel
            ExcelServices<ExcelRoomLayoutVM> _svExcel = new();
            //CRUD + Validate với dữ liệu trong DB
            var validateResult = await _svExcel.Validate(stream, null, 1);
            stream = validateResult.MemoryStream!;
            List<ExcelRoomLayoutVM> lstExcelVM = await _svExcel.GetValueFromFileStream(stream);
            List<RoomLayoutEntity> lstObj = lstExcelVM.Select(c => c.ConvertToEntity()).ToList();
            List<RoomLayoutEntity> lstRoomLayout = new();
            List<ExcelErrorVM> lstMarkup = new();

            foreach(var i in lstObj)
            {
                try
                {
                    lstRoomLayout.Add(i);
                }
                catch
                {
                    lstMarkup.Add(new() { Message = "Thêm dữ liệu thất bại (Lỗi hệ thống hoặc dữ liệu)", IsSuccess = false });
                }
            }
            await _roomLayoutReadWrite.CreateRangeRoomLayoutAsync(lstRoomLayout, cancellationToken);
            return SaveFile(fileExtension, "Excels/Handled");
        }
        public string SaveFile(string fileExtension, string folder)
        {
            string fileName = Guid.NewGuid().ToString() + fileExtension;

            var filePath = Path.Combine(_pathFolder, folder, fileName);
            var stream = new FileStream(filePath, FileMode.Create);
            stream.Close();
            return fileName;
        }
    }
}
