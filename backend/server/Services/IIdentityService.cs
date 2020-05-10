using System.Threading.Tasks;
using server.Contracts.V1.Requests;
using server.Domain;

namespace server.Services
{
    public interface IIdentityService
    {
        Task<AuthenticationResult> RegisterAsync(UserRegistrationRequest request);
        Task<AuthenticationResult> LoginAsync(string username, string password);
    }
}