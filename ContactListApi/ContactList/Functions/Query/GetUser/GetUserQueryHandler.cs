using ContactList.Abstractions.Shared;
using ContactList.Models;
using MediatR;

namespace ContactList.Functions.Query.GetUser;

public class GetUserQueryHandler : IRequestHandler<GetUserQuery, Result>
{
    private ContactContext _context;
    public GetUserQueryHandler(ContactContext context)
    {
        _context = context;
    }

    public async Task<Result> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
        var user = _context.Users.FirstOrDefault(u => u.Username.Equals(request.Login) && u.Password.Equals(request.Password));

        if (user == null)
            return Result.Failure(Error.NullValue);

        return Result.Success();
    }
}
