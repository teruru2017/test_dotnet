namespace octa_dotnet.Interfaces
{
    public interface IAccountsService
    {
        Task Register(string  accounts);
        Task Login(string username, string password);
    }

   
}