
namespace URF_Cinema.Infrastructure.Extensions
{
    public static class GenToken
    {
        //public static RefreshToken GenerateToken(ViewLoginInput loginInput)
        //{
        //    var tokenHandler = new JwtSecurityTokenHandler();
        //    var key = Encoding.ASCII.GetBytes(ConstsToken.SecretKey);
        //    var role = GetRoleById(loginInput.RoleId);
        //    var tokenDescription = new SecurityTokenDescriptor
        //    {
        //        Subject = new ClaimsIdentity(new[]
        //        {
        //            new Claim(ClaimTypes.Name, loginInput.Name),
        //            new Claim(ClaimTypes.Email,loginInput.Email),
        //            new Claim("UserName",loginInput.UserName),
        //            new Claim("Id",loginInput.Id.ToString()),
        //            new Claim(ClaimTypes.Role, role.ToString()),
        //        }),
        //        Expires = DateTime.UtcNow.AddDays(1),
        //        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
        //        Issuer = ConstsToken.Issuer,
        //        Audience = ConstsToken.Audience
        //    };
        //    var token = tokenHandler.CreateToken(tokenDescription);

        //    var accessToken = tokenHandler.WriteToken(token);

        //    return new RefreshToken
        //    {
        //        Token = accessToken
        //    };
        //}
        //public static string GetRoleById(Guid Id)
        //{
        //    //using (var _dbcontext = new AppReadOnlyDbContext())
        //    //{
        //    //    var role = _dbcontext.RoleEntities.FirstOrDefault(x => x.Id == Id);
        //    //    if (role != null)
        //    //    {
        //    //        return role.Code!;
        //    //    }
        //    //    throw new Exception("Quyền không tồn tại!");
        //    //}
        //}
    }
}
