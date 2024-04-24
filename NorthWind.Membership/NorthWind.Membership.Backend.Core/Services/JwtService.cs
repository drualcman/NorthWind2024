namespace NorthWind.Membership.Backend.Core.Services;
internal class JwtService(IOptions<JwtOptions> options)
{
    SigningCredentials GetSigningCredentials()
    {
        byte[] key = Encoding.UTF8.GetBytes(options.Value.SecurityKey);
        SymmetricSecurityKey secret = new SymmetricSecurityKey(key);
        return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
    }

    List<Claim> GetClaims(UserDto userDto) =>
        [
            new Claim(ClaimTypes.Name, userDto.Email),
            new Claim("FullName", $"{userDto.FirstName} {userDto.LastName}".Trim())
        ];

    SecurityTokenDescriptor GetTokenDescriptor(SigningCredentials signingCredentials, List<Claim> claims) =>
        new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Issuer = options.Value.ValidIssuer,
            Audience = options.Value.ValidAudience,
            Expires = DateTime.UtcNow.AddMinutes(options.Value.ExpireInMinutes),
            SigningCredentials = signingCredentials
        };

    public string GetToken(UserDto userDto)
    {
        SigningCredentials signingCredentials = GetSigningCredentials();
        List<Claim> claims = GetClaims(userDto);
        SecurityTokenDescriptor securityTokenDescriptor = GetTokenDescriptor(signingCredentials, claims);
        JsonWebTokenHandler tokenHandler = new JsonWebTokenHandler();
        return tokenHandler.CreateToken(securityTokenDescriptor);
    }
}
