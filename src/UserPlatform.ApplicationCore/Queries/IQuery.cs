using MediatR;

namespace UserPlatform.ApplicationCore.Queries
{
    public interface IQuery : IRequest
    {
    }

    public interface IQuery<out TResponse> : IRequest<TResponse>
    {
    }
}