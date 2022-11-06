using OwnSignDemo.Models;

namespace OwnSignDemo.Interfaces
{
    public interface IAuthenticationService
    {
        AuthenticationToken? Authenticate(User user);
    }
}
