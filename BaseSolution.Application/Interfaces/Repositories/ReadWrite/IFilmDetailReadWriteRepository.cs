using BaseSolution.Application.DataTransferObjects.FilmDetail.Request;
using BaseSolution.Application.DataTransferObjects.RoomLayout.Request;
using BaseSolution.Application.ValueObjects.Response;
using BaseSolution.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Application.Interfaces.Repositories.ReadWrite
{
    public interface IFilmDetailReadWriteRepository
    {
        Task<RequestResult<Guid>> AddFilmDetailAsync(FilmDetailEntity entity, CancellationToken cancellationToken);
        Task<RequestResult<int>> UpdateFilmDetailAsync(FilmDetailEntity entity, CancellationToken cancellationToken);
        Task<RequestResult<int>> DeleteFilmDetailAsync(FilmDetailDeleteRequest request, CancellationToken cancellationToken);


    }
}
