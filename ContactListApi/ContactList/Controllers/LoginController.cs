using System.IdentityModel.Tokens.Jwt;
using System.Text;
using ContactList.Functions.Query.GetUser;
using ContactList.Models.Dto;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace ContactList.Controllers;


[Route("api/login")]
[ApiController]
public class LoginController : ControllerBase
{
    private ISender _sender;

    public LoginController(ISender sender)
    {
        this._sender = sender;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Login([FromBody] UserLoginDto userLoginDto, CancellationToken cancellationToken)
    {
        var request = new GetUserQuery()
        {
            Login = userLoginDto.Login,
            Password = userLoginDto.Password
        };

        var result = await _sender.Send(request, cancellationToken);

        return result.IsSuccess ? Ok(new TokenDto { Token = GetJwtSecurityToken(userLoginDto.Login) }) : BadRequest();
    }

    private JwtSecurityToken GetJwtSecurityToken(string userName)
    {
        var issuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("JWT_SECRET")));

        return new JwtSecurityToken(
            expires: DateTime.Now.Add(TimeSpan.FromMinutes(60)),
            signingCredentials: new SigningCredentials(issuerSigningKey, algorithm: SecurityAlgorithms.HmacSha256)
            );
    }

}
