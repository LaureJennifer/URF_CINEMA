using AutoMapper;
using BaseSolution.Application.DataTransferObjects.Film.Request;
using BaseSolution.Application.DataTransferObjects.Seat.Request;
using BaseSolution.Application.Interfaces.Repositories.ReadOnly;
using BaseSolution.Application.Interfaces.Repositories.ReadWrite;
using BaseSolution.Application.Interfaces.Services;
using BaseSolution.Infrastructure.Implements.Repositories.ReadWrite;
using BaseSolution.Infrastructure.Implements.Services;
using BaseSolution.Infrastructure.ViewModels.Film;
using BaseSolution.Infrastructure.ViewModels.Seat;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BaseSolution.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmsController : ControllerBase
    {
        private readonly IFilmReadOnlyRepository _filmReadOnlyRepository;
        private readonly IFilmReadWriteRepository _filmReadWriteRepository;
        private readonly ILocalizationService _localizationService;
        private readonly IMapper _mapper;

        public FilmsController(IFilmReadOnlyRepository filmReadOnlyRepository, IFilmReadWriteRepository filmReadWriteRepository, ILocalizationService localizationService, IMapper mapper)
        {
            _filmReadOnlyRepository = filmReadOnlyRepository;
            _filmReadWriteRepository = filmReadWriteRepository;
            _localizationService = localizationService;
            _mapper = mapper;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetListFilmByAdmin([FromQuery]ViewFilmWithPaginationRequest request, CancellationToken cancellationToken)
        {
            FilmListWithPaginationViewModel vm = new(_filmReadOnlyRepository, _localizationService);

            await vm.HandleAsync(request, cancellationToken);

            return Ok(vm);
        }

        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFilmById(Guid id, CancellationToken cancellationToken)
        {
            FilmViewModel vm = new(_filmReadOnlyRepository, _localizationService);

            await vm.HandleAsync(id, cancellationToken);

            return Ok(vm);
        }

        [HttpPost]
        public async Task<IActionResult> CreateFilm(FilmCreateRequest request, CancellationToken cancellationToken)
        {
            FilmCreateViewModel vm = new(_filmReadOnlyRepository, _filmReadWriteRepository, _localizationService, _mapper);

            await vm.HandleAsync(request, cancellationToken);

            return Ok(vm);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateFilm(FilmUpdateRequest request, CancellationToken cancellationToken)
        {
            FilmUpdateViewModel vm = new(_filmReadWriteRepository, _localizationService, _mapper);

            await vm.HandleAsync(request, cancellationToken);

            return Ok(vm);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteFilm([FromQuery]FilmDeleteRequest request, CancellationToken cancellationToken)
        {
            FilmDeleteViewModel vm = new(_filmReadWriteRepository, _localizationService, _mapper);

            await vm.HandleAsync(request, cancellationToken);

            return Ok(vm);
        }
    }
}
