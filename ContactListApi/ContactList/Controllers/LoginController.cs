using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
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

    private string GetJwtSecurityToken(string username)
    {
        var issuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("JWT_SECRET")));
        var creds = new SigningCredentials(issuerSigningKey, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(ClaimTypes.Name, username)
        };

        var token = new JwtSecurityToken(
            issuer: "MyApp",
            audience: "MyAppClient",
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(60),
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

}
