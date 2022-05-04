using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SharedClassModels.DataModels;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace SharedClassModels.ViewModels
{
    public class JWTManagerRepository : IJWTManagerRepository
    {
        private readonly IConfiguration configuartion;

        private readonly AirlineDBContext _dbcontext;

        public JWTManagerRepository(IConfiguration iconfiguration, AirlineDBContext Dbcontext)
        {
            configuartion = iconfiguration;
            _dbcontext = Dbcontext;
        }

        public TokenDetails AdminAuthenticate(TblAdminDetail users)
        {
            var myUser = _dbcontext.TblAdminDetails.FirstOrDefault(u => u.AdminName.Equals(users.AdminName) && u.AdminPwd.Equals(users.AdminPwd));
            if (myUser != null)
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenKey = Encoding.UTF8.GetBytes(configuartion["JWT:Key"]);

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                    new Claim(ClaimTypes.Name,users.AdminName)
                    }),
                    Expires = DateTime.UtcNow.AddMinutes(10),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                return new TokenDetails { Token = tokenHandler.WriteToken(token) };
            }
            else
                return null;
        }

        public TokenDetails Authenticate(TblUserName users)
        {
            var myUser= _dbcontext.TblUserNames.FirstOrDefault(u=> u.UserName.Equals(users.UserName) && u.PassWord.Equals(users.PassWord));
            if (myUser!=null)
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenKey = Encoding.UTF8.GetBytes(configuartion["JWT:Key"]);

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                    new Claim(ClaimTypes.Name,users.UserName)
                    }),
                    Expires = DateTime.UtcNow.AddMinutes(10),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                return new TokenDetails { Token = tokenHandler.WriteToken(token) };
            }
            else
                return null;
        }
  
    }    

}
