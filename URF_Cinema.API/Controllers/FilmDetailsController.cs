using AutoMapper;
using URF_Cinema.Application.DataTransferObjects.FilmDetail.Request;
using URF_Cinema.Application.Interfaces.Repositories.ReadOnly;
using URF_Cinema.Application.Interfaces.Repositories.ReadWrite;
using URF_Cinema.Application.Interfaces.Services;
using URF_Cinema.Infrastructure.ViewModels.FilmDetail;
using Microsoft.AspNetCore.Mvc;

namespace URF_Cinema.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmDetailsController : ControllerBase
    {
        private readonly IFilmDetailReadOnlyRepository _filmDetailReadOnlyRepository;
        private readonly IFilmDetailReadWriteRepository _filmDetailReadWriteRepository;
        private readonly ILocalizationService _localizationService;
        private readonly IMapper _mapper;

        public FilmDetailsController(IFilmDetailReadOnlyRepository filmDetailReadOnlyRepository, IFilmDetailReadWriteRepository filmDetailReadWriteRepository, ILocalizationService localizationService, IMapper mapper)
        {
            _filmDetailReadOnlyRepository = filmDetailReadOnlyRepository;
            _filmDetailReadWriteRepository = filmDetailReadWriteRepository;
            _localizationService = localizationService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetListFilmDetailByAdmin([FromQuery] ViewFilmDetailWithPaginationRequest request, CancellationToken cancellationToken)
        {
            FilmDetailListWithPaginationViewModel vm = new(_filmDetailReadOnlyRepository, _localizationService);

            await vm.HandleAsync(request, cancellationToken);

            return Ok(vm);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetFilmDetailById(Guid id, CancellationToken cancellationToken)
        {
            FilmDetailViewModel vm = new(_filmDetailReadOnlyRepository, _localizationService);

            await vm.HandleAsync(id, cancellationToken);

            return Ok(vm);
        }

        [HttpPost]
        public async Task<IActionResult> CreateFilmDetail(FilmDetailCreateRequest request, CancellationToken cancellationToken)
        {
            FilmDetailCreateViewModel vm = new(_filmDetailReadOnlyRepository, _filmDetailReadWriteRepository, _localizationService, _mapper);

            await vm.HandleAsync(request, cancellationToken);

            return Ok(vm);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateFilmDetail(FilmDetailUpdateRequest request, CancellationToken cancellationToken)
        {
            FilmDetailUpdateViewModel vm = new(_filmDetailReadWriteRepository, _localizationService, _mapper);

            await vm.HandleAsync(request, cancellationToken);

            return Ok(vm);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteFilmDetail(FilmDetailDeleteRequest request, CancellationToken cancellationToken)
        {
            FilmDetailDeleteViewModel vm = new(_filmDetailReadWriteRepository, _localizationService, _mapper);

            await vm.HandleAsync(request, cancellationToken);

            return Ok(vm);
        }
    }
}
