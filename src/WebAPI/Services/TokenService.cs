using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WebAPI.Services
{
    public class TokenService
    {
        public List<Claim> CreateJwtClaims(String UserId, List<String> Roles) //use name like mule for anonymous/JWT users
        {

            // create a list of claims and add userId 
            var claims = new List<Claim>
            {
              new Claim(ClaimsIdentity.DefaultNameClaimType, UserId),
              new Claim(JwtRegisteredClaimNames.Sub, UserId),

            };
            // add roles to the claims list
            // for every role add a new claim type role
            foreach (var role in Roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
           
            return claims;
        }


        public string CreateToken(List<Claim> claims)
        {
            // JWT Key we can use app.settings
            //TODO get key from Appsetting for dev
            //TODO for live we must use and environment variable
            // Don't forget update the startup if you change it here or we will get a key mismatch
            string JwtSigningKey = "fjboJU3s7rw2Oafzum5fBxZoZ5jihQRbpBZcxZFd/gY=";

            // create a security key
            var Key = new SymmetricSecurityKey(System.Text.Encoding.ASCII.GetBytes(JwtSigningKey));


            // sign the key using specified algorithm
            var Creds = new SigningCredentials(Key, SecurityAlgorithms.HmacSha256);

            // create the token from the signed credentials
            var Token = new JwtSecurityToken
            (
              issuer: "localhost",
              claims: claims,
              expires: DateTime.Now.AddMinutes(10),
              signingCredentials: Creds
           );

            return new JwtSecurityTokenHandler().WriteToken(Token);
        }


    }
}
