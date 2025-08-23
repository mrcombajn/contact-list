using MediatR;

namespace ContactList.Functions.Command.UpdateContact;

public sealed class UpdateContactCommandHandler : IRequestHandler<UpdateContactCommand>
{
    public Task Handle(UpdateContactCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
