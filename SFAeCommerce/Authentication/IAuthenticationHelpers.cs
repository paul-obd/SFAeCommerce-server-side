using SFAeCommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SFAeCommerce.Authentication
{
    public interface IAuthenticationHelpers
    {

        public void CreateHashedPassword(string password, out byte[] passwordHash, out byte[] passwordSalt);

        public bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt);


        public string createToken(Client client, int clientSessionId);

        public  Task<bool> checkClientSession(int clientSessionId);
     
    }
}
