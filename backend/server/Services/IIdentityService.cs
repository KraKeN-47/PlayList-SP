using System.Threading.Tasks;
using server.Domain;

namespace server.Services
{
    public interface IIdentityService
    {
        Task<AuthenticationResult> RegisterAsync(string email, string password);
    }
}