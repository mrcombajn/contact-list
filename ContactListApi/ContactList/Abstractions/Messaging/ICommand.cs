using ContactList.Abstractions.Shared;
using MediatR;

namespace ContactList.Abstractions.Messaging;

public interface ICommand : IRequest<Result>
{
}

public interface ICommand<TResponse> : IRequest<Result<TResponse>>
{

}

