using ContactList.Abstractions.Shared;
using ContactList.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

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
        var user = await _context.Users
            .FirstOrDefaultAsync(u => u.Username == request.Login);

        if (user == null || !user.Password.Equals(request.Password))
            return Result.Failure(Error.NullValue);

        return Result.Success();
    }
}
