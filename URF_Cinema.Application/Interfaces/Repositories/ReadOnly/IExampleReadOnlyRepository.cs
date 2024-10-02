using URF_Cinema.Application.DataTransferObjects.Example;
using URF_Cinema.Application.DataTransferObjects.Example.Request;
using URF_Cinema.Application.ValueObjects.Pagination;
using URF_Cinema.Application.ValueObjects.Response;

namespace URF_Cinema.Application.Interfaces.Repositories.ReadOnly
{
    public interface IExampleReadOnlyRepository
    {
        Task<RequestResult<ExampleDto?>> GetExampleByIdAsync(Guid idExample, CancellationToken cancellationToken);
        Task<RequestResult<PaginationResponse<ExampleDto>>> GetExampleWithPaginationByAdminAsync(
            ViewExampleWithPaginationRequest request, CancellationToken cancellationToken);
    }
}
