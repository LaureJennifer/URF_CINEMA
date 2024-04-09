using AutoMapper;
using AutoMapper.QueryableExtensions;
using BaseSolution.Application.DataTransferObjects.Account;
using BaseSolution.Application.DataTransferObjects.Account.Request;
using BaseSolution.Application.Interfaces.Login;
using BaseSolution.Application.Interfaces.Services;
using BaseSolution.Application.ValueObjects.Common;
using BaseSolution.Application.ValueObjects.Response;
using BaseSolution.Infrastructure.Database.AppDbContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Infrastructure.Implements.Repositories.Login
{
    public class LoginService : ILoginService
    {
        private readonly AppReadOnlyDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ILocalizationService _localizationService;
        public LoginService(AppReadOnlyDbContext dbContext, IMapper mapper, ILocalizationService localizationService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _localizationService = localizationService;
        }
        public async Task<RequestResult<ViewLoginInput>> Login(LoginInputRequest request)
        {
            try
            {
                var result = _dbContext.UserEntities.AsNoTracking().Where(x => x.UserName == request.UserName && x.PassWord == request.Password)
                 .ProjectTo<ViewLoginInput>(_mapper.ConfigurationProvider).FirstOrDefault();
                return RequestResult<ViewLoginInput>.Succeed(result);

            }
            catch (Exception e)
            {
                return RequestResult<ViewLoginInput>.Fail(_localizationService["Login fail"], new[]
               {
                    new ErrorItem
                    {
                        Error = e.Message,
                    }
});
            }
        }
    }
}
