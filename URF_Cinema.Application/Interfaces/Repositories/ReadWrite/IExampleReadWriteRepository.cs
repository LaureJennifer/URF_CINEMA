using URF_Cinema.Application.DataTransferObjects.Example.Request;
using URF_Cinema.Application.ValueObjects.Response;
using URF_Cinema.Domain.Entities;

namespace URF_Cinema.Application.Interfaces.Repositories.ReadWrite
{
    public interface IExampleReadWriteRepository
    {
        Task<RequestResult<Guid>> AddExampleAsync(ExampleEntity entity, CancellationToken cancellationToken);
        Task<RequestResult<int>> UpdateExampleAsync(ExampleEntity entity, CancellationToken cancellationToken);
        Task<RequestResult<int>> DeleteExampleAsync(ExampleDeleteRequest request, CancellationToken cancellationToken);
    }
}