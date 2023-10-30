using Microsoft.AspNetCore.Identity;

namespace Books.Reposistories
{
    public interface ITokenRepository
    {
        string CreateJwtToken(IdentityUser identityUser, List<String> Roles);
    }
}
