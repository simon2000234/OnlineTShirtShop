using OTSSCore.Entities;

namespace Infrastructure.SQL.Helpers
{
    public interface IAuthenticationHelper
    {
        string GenerateToken(User user);

    }
}