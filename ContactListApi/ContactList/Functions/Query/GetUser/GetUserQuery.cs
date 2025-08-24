using ContactList.Abstractions.Shared;
using MediatR;

namespace ContactList.Functions.Query.GetUser;

public class GetUserQuery : IRequest<Result>
{
    public string Login { get; set; }
    public string Password { get; set; }
}
