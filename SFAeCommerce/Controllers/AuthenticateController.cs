using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SFAeCommerce.Authentication;
using SFAeCommerce.Entitties;
using SFAeCommerce.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SFAeCommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {

        private readonly IConfiguration _configuration;
        private readonly SFADB_ECOMMERCEContext _dbContext;
        private readonly IAuthenticationHelpers _authHelp;

        public AuthenticateController(IConfiguration configuration, SFADB_ECOMMERCEContext dbContext , IAuthenticationHelpers authHelp )
        {
            _dbContext = dbContext;
            _configuration = configuration;
            _authHelp = authHelp;
        }


        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> registerClient([FromBody]LoginModel model)
        {
            try
            {
                var isClient = await _dbContext.Clients.Where(c => c.ClientCode == model.ClientCode).FirstOrDefaultAsync();

                if (isClient == null)
                {
                    return NotFound();
                }

                _authHelp.CreateHashedPassword(model.Password, out byte[] passwordHash, out byte[] passwordSalt);

                isClient.PasswordHash = passwordHash;
                isClient.PasswordSalt = passwordSalt;

                _dbContext.Entry(isClient).State = EntityState.Modified;

                await _dbContext.SaveChangesAsync();

                return Ok(isClient);

          
            }
            catch (Exception e)
            {

                return StatusCode(500, e.Message);
            }
        }


        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> login([FromBody] LoginModel model)
        {
            try
            {
                var isClient = await _dbContext.Clients.Where(c => c.ClientCode == model.ClientCode).FirstOrDefaultAsync();
                if (isClient == null)
                {
                  return StatusCode(404, "Client Not Found!");
                }

                if (!_authHelp.VerifyPasswordHash(model.Password, isClient.PasswordHash, isClient.PasswordSalt))
                {
                    return StatusCode(402, "Incorrect Password");
                }

                var isClientLoggedIn = await _dbContext.ClientSessions.Where(cs => cs.ClientCode == model.ClientCode && cs.IsLoggedIn == true ).FirstOrDefaultAsync();
                if(isClientLoggedIn != null)
                {
                    return StatusCode(1001, "Client Already Logged In On Another Machine");
                }

                var newClientSession = new ClientSession()
                {
                    ClientCode = model.ClientCode,
                    IsLoggedIn = true
                };

                var addedClientSession = await _dbContext.ClientSessions.AddAsync(newClientSession);
                await _dbContext.SaveChangesAsync();

                var token =  _authHelp.createToken(isClient, newClientSession.ClientSessionId);

                LoginClientDto response = new LoginClientDto()
                {
                    client = isClient,
                    token = token
                };
                return Ok(response);
       

            }
            catch (Exception e)
            {

                return StatusCode(500, e.Message);
            }
        }


        [HttpPost]
        [Route("logout")]
        public async Task<IActionResult> logout()
        {
            try
            {

                var isClient = await _dbContext.ClientSessions.Where(cs => cs.ClientSessionId == Int32.Parse(User.FindFirstValue("clientSessionId"))).FirstOrDefaultAsync();

                if (isClient == null)
                {
                    return NotFound();
                }

                isClient.IsLoggedIn = false;

                _dbContext.Entry(isClient).State = EntityState.Modified;

                await _dbContext.SaveChangesAsync();

                return Ok(isClient);

            }
            catch (Exception e)
            {

                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        [Route("force-logout")]
        public async Task<IActionResult> forceLogout([FromBody]LoginModel client)
        {
            try
            {

                var isClient = await _dbContext.ClientSessions.Where(c => c.ClientCode == client.ClientCode && c.IsLoggedIn == true).FirstOrDefaultAsync();

                if (isClient == null)
                {
                    return NotFound();
                }

                isClient.IsLoggedIn = false;

                _dbContext.Entry(isClient).State = EntityState.Modified;

                await _dbContext.SaveChangesAsync();



                return Ok(isClient);

            }
            catch (Exception e)
            {

                return StatusCode(500, e.Message);
            }
        }
    }
}
