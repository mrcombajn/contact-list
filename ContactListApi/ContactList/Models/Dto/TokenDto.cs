using System.IdentityModel.Tokens.Jwt;

namespace ContactList.Models.Dto;

public class TokenDto
{
    public JwtSecurityToken Token { get; set; }
}
