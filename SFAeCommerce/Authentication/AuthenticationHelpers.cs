using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SFAeCommerce.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace SFAeCommerce.Authentication
{
    public class AuthenticationHelpers : IAuthenticationHelpers
    {
        private readonly IConfiguration _configuration;
        private readonly SFADB_ECOMMERCEContext _dbContext;

        public AuthenticationHelpers(IConfiguration configuration, SFADB_ECOMMERCEContext dbContext)
        {
            _configuration = configuration;
            _dbContext = dbContext;
        }
        public void CreateHashedPassword(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        public bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }

        public string createToken(Client client, int clientSessionId)
        {
            var authClaims = new List<Claim>
                {

                    new Claim(ClaimTypes.Name, client.ClientCode),
                    new Claim("clientSessionId", clientSessionId.ToString())
                };

            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                  issuer: _configuration["JWT:ValidIssuer"],
                  audience: _configuration["JWT:ValidAudience"],
                  expires: DateTime.Now.AddDays(1),
                  claims: authClaims,
                  signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
             );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

        public async Task<bool> checkClientSession(int clientSessionId)
        {
            try
            {
                var clientSession = await _dbContext.ClientSessions.Where(cs => cs.ClientSessionId == clientSessionId).FirstOrDefaultAsync();
                if (clientSession.IsLoggedIn == false)
                {
                    var resp = new HttpResponseMessage(HttpStatusCode.Forbidden)
                    {
                        Content = new StringContent("You Were Forced To Logout "),
                        ReasonPhrase = "Someone Logged in from another machine"
                    };
                    throw new HttpResponseException(resp);

                }
                else
                {
                    return true;
                }
            }
            catch (Exception e)
            {

                throw e;
            }
           
            

        }

 
    }
}
