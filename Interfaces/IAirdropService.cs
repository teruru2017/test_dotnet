using octa_dotnet.Entities;

namespace octa_dotnet.Interfaces
{
    public interface IAirdropService
    {
         Task<IEnumerable<Airdrop>> FindAll();
         Task<Airdrop> FindById(int id);
         Task Create(Airdrop airdrop);
         Task Update(Airdrop airdrop);
         Task Delete(Airdrop airdrop);
         Task<IEnumerable<Airdrop>> Search(string Account);


    }
}