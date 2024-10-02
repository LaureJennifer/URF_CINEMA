using URF_Cinema.Application.ValueObjects.Response;

namespace URF_Cinema.Application.ViewModels
{
    /// <summary>
    ///     Provide all common field in view model
    /// </summary>
    public abstract class ViewModelBase<TDataType> : APIResponse
    {
        public abstract Task HandleAsync(TDataType data, CancellationToken cancellationToken);
    }
}
