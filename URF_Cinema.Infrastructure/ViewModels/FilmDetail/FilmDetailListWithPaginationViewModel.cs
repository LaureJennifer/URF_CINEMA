﻿using URF_Cinema.Application.DataTransferObjects.FilmDetail.Request;
using URF_Cinema.Application.Interfaces.Repositories.ReadOnly;
using URF_Cinema.Application.Interfaces.Services;
using URF_Cinema.Application.ValueObjects.Common;
using URF_Cinema.Application.ViewModels;

namespace URF_Cinema.Infrastructure.ViewModels.FilmDetail
{
    public class FilmDetailListWithPaginationViewModel:ViewModelBase<ViewFilmDetailWithPaginationRequest>
    {
        private readonly IFilmDetailReadOnlyRepository _filmDetailReadOnlyRepository;
        private readonly ILocalizationService _localizationService;

        public FilmDetailListWithPaginationViewModel(IFilmDetailReadOnlyRepository filmDetailReadOnlyRepository, ILocalizationService localizationService)
        {
            _filmDetailReadOnlyRepository = filmDetailReadOnlyRepository;
            _localizationService = localizationService;
        }

        public async override Task HandleAsync(ViewFilmDetailWithPaginationRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _filmDetailReadOnlyRepository.GetFilmDetailWithPaginationByAdminAsync(request, cancellationToken);

                Data = result.Data!;
                Success = result.Success;
                ErrorItems = result.Errors;
                Message = result.Message;
                return;
            }
            catch
            {

                Success = false;
                ErrorItems = new[]
                {
                    new ErrorItem
                    {
                        Error = _localizationService["Error occurred while getting the list of film detail"],
                        FieldName = string.Concat(LocalizationString.Common.FailedToGet, "list of film detail")
                    }
                };
            }
        }
    }
}
