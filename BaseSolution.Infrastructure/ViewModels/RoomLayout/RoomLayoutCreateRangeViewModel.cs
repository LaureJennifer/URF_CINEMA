//using AutoMapper;
//using BaseSolution.Application.DataTransferObjects.RoomLayout.Request;
//using BaseSolution.Application.Interfaces.Repositories.ReadOnly;
//using BaseSolution.Application.Interfaces.Repositories.ReadWrite;
//using BaseSolution.Application.Interfaces.Services;
//using BaseSolution.Application.ValueObjects.Common;
//using BaseSolution.Application.ViewModels;
//using BaseSolution.Domain.Entities;
//using BaseSolution.Infrastructure.Implements.Repositories.ReadOnly;
//using BaseSolution.Infrastructure.Implements.Repositories.ReadWrite;
//using BaseSolution.Infrastructure.Implements.Services;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace BaseSolution.Infrastructure.ViewModels.RoomLayout
//{
//    public class RoomLayoutCreateRangeViewModel : ViewModelBase<List<RoomLayoutCreateRequest>>
//    {
//        private readonly IRoomLayoutReadOnlyRepository _roomLayoutReadOnlyRepository;
//        private readonly IRoomLayoutReadWriteRepository _roomLayoutReadWriteRepository;
//        private readonly ILocalizationService _localizationService;
//        private readonly IMapper _mapper;

//        public RoomLayoutCreateRangeViewModel(IRoomLayoutReadOnlyRepository RoomLayoutReadOnlyRepository, IRoomLayoutReadWriteRepository RoomLayoutReadWriteRepository, ILocalizationService localizationService, IMapper mapper)
//        {
//            _roomLayoutReadOnlyRepository = RoomLayoutReadOnlyRepository;
//            _roomLayoutReadWriteRepository = RoomLayoutReadWriteRepository;
//            _localizationService = localizationService;
//            _mapper = mapper;
//        }

//        public override async Task HandleAsync(List<RoomLayoutCreateRequest> listData, CancellationToken cancellationToken)
//        {
//            try
//            {
//                var createResult = await _roomLayoutReadWriteRepository.CreateRangeRoomLayoutAsync(_mapper.Map<List<RoomLayoutEntity>>(listData), cancellationToken);

//                if (createResult.Success)
//                {
//                    var result = await _roomLayoutReadOnlyRepository.GetListRoomLayoutByIdAsync(createResult.Data, cancellationToken);
//                    Data = result.Data!;
//                    Success = result.Success;
//                    ErrorItems = result.Errors;
//                    Message = result.Message;
//                    return;
//                }
//                Success = createResult.Success;
//                ErrorItems = createResult.Errors;
//                Message = createResult.Message;
//            }
//            catch (Exception)
//            {

//                Success = false;
//                ErrorItems = new[]
//                    {
//                    new ErrorItem
//                    {
//                        Error = _localizationService["Error occurred while getting the roomlayout"],
//                        FieldName = string.Concat(LocalizationString.Common.FailedToGet, "roomlayout")
//                    }
//                };
//            }
//        }
//    }
//}
