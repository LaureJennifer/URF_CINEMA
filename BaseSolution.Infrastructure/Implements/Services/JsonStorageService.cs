using AutoMapper;
using BaseSolution.Application.Interfaces.Services;
using BaseSolution.Domain.Entities;
using BaseSolution.Infrastructure.Database.AppDbContext;
using BaseSolution.Infrastructure.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Infrastructure.Implements.Services
{
    public class JsonStorageService<T> : IJsonStorageService<T> where T : class
    {
        private AppReadOnlyDbContext _dbContext;
        public IMapper _mapper { get; }
        public JsonStorageService(IMapper mapper)
        {
            _dbContext = new AppReadOnlyDbContext();
            _mapper = mapper;
        }
        public async Task<Guid> CreateAsync(CreateJsonStorage<T> jsonImportDto)
        {
            try
            {
                var jsonList = System.Text.Json.JsonSerializer.Serialize(jsonImportDto);
                JsonStorage jsonImport = new JsonStorage()
                {
                    JsonList = jsonList,
                    CreateTime = DateTime.Now,
                };
                var reslut = await _dbContext.JsonStorages.AddAsync(jsonImport);
                await _dbContext.SaveChangesAsync();
                return reslut.Entity.Id;
            }
            catch (Exception)
            {
                return default;
            }
        }

        public async Task<JsonStorageVM<T>> GetByIdEntityJsonAsync(Guid Id)
        {
            var jsonStorageVM = await _dbContext.JsonStorages.FindAsync(Id);
            if (jsonStorageVM == null) return default;
            var entitys = JsonConvert.DeserializeObject<JsonStorageVM<T>>(jsonStorageVM.JsonList);
            return entitys;
        }

        public async Task<bool> DeleteAsync(Guid Id)
        {
            try
            {
                var jsonStorageVM = await _dbContext.JsonStorages.FindAsync(Id);
                _dbContext.JsonStorages.Remove(jsonStorageVM);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
    }
}
