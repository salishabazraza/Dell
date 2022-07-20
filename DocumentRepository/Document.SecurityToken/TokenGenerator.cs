using DocumentRepository.Models.Common;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Document.SecurityToken
{
    public class TokenGenerator
    {
        public string getToken(SecurityTokenModel model)
        {
            return generateJsonToken(model);
        }
        private string generateRandomKeyString(string userName)
        {
            byte[] guidByte = Guid.NewGuid().ToByteArray();
            byte[] user = Encoding.ASCII.GetBytes(userName);
            byte[] date = BitConverter.GetBytes(DateTime.UtcNow.ToBinary());
            byte[] concat = new byte[guidByte.Length + user.Length + date.Length];
            Buffer.BlockCopy(guidByte, 0, concat, 0, guidByte.Length);
            Buffer.BlockCopy(user, 0, concat, guidByte.Length - 1, user.Length);
            Buffer.BlockCopy(date, 0, concat, user.Length - 1, date.Length);
            return Convert.ToBase64String(concat);
        }
        private string generateJsonToken(SecurityTokenModel model)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(VariableConfiguration.key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[] {
                 new Claim(JwtRegisteredClaimNames.Sub,model.firstName+" "+model.lastName),
                 new Claim(JwtRegisteredClaimNames.Email,model.emailAddress),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                //new Claim("userRole",model.roleName),
                //new Claim("userRoleID",Convert.ToString(model.roleId)),
                new Claim("userId",model.UserId.ToString())
            };

            var token = new JwtSecurityToken(VariableConfiguration.issuer, VariableConfiguration.issuer, claims,
                expires: DateTime.Now.AddDays(1), signingCredentials: credentials); ;
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
