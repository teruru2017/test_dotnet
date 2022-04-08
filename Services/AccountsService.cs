using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using octa_dotnet.Data;
using octa_dotnet.Interfaces;

namespace octa_dotnet.Services
{
    public class AccountsService : IAccountsService
    {
        private readonly DatabaseContext databaseContext;
        public AccountsService(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public async Task Register(string accounts)
        {
            var existingAccounts = await databaseContext.Accounts.SingleOrDefaultAsync(a => a.Username == accounts.Username);
            if(existingAccounts != null){
                throw new Exception("Existing Account");

            }
                accounts.Password = CreatePasswordHash(accounts.Password);
                databaseContext.Add(accounts);
                await databaseContext.SaveChangesAsync();
        }

        public Task Login(string username, string password)
        {
            throw new NotImplementedException();
        }

        private string CreatePasswordHash(string password)
        {
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA512,
                iterationCount: 10000,
                numBytesRequested: 258 / 8
                ));
               return $"{Convert. ToBase64String(salt)}.{hashed}";
 
         }
         private bool VerifyPassword(string hash, string password){
             var parts = hash.Split('.',2);
             if(parts.Length != 2){
                 return false;
             }
             var salt =Convert.FromBase64String(parts[0]);
             var passwordHash = parts[1];
             string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA512,
                iterationCount: 10000,
                numBytesRequested: 258 / 8
                ));
                return passwordHash == hashed;
         }
    }
    }