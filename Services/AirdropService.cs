using Microsoft.EntityFrameworkCore;
using octa_dotnet.Data;
using octa_dotnet.Entities;
using octa_dotnet.Interfaces;

namespace octa_dotnet.Services
{
    public class AirdropService : IAirdropService
    {
        private readonly DatabaseContext databaseContext;

        public AirdropService(DatabaseContext databaseContext) => this.databaseContext = databaseContext;

        public async Task<IEnumerable<Airdrop>> FindAll()
        {
            return await databaseContext.Airdrops
             .OrderByDescending(p => p.AirdropId)
             .ToListAsync();
        }

        public async Task<Airdrop> FindById(int AirdropId)
        {
            return await databaseContext.Airdrops.FindAsync(AirdropId);


        }
        public async Task<IEnumerable<Airdrop>> Search(string account)
        {
            var result = await databaseContext.Airdrops
                .Where(p => p.Account.ToLower().Contains(account.ToLower()))
                .ToListAsync();
            return result;
        }
        public async Task Create(Airdrop airdrop)
        {
            databaseContext.Airdrops.Add(airdrop);
            await databaseContext.SaveChangesAsync();
        }
        public async Task Update(Airdrop airdrop)
        {
            databaseContext.Airdrops.Update(airdrop);
            await databaseContext.SaveChangesAsync();
      
        }
        public async Task Delete(Airdrop airdrop)
        {
        
            databaseContext.Airdrops.Remove(airdrop);
            await databaseContext.SaveChangesAsync();
        }
        

       
    }
}