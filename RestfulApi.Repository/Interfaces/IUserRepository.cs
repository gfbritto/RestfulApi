using RestfulApi.Models.Core.Entities;
using RestfulApi.Models.Data.VO;

namespace RestfulApi.Repository.Interfaces
{
    public interface IUserRepository
    {
        User ValidateCredentials(UserVO user);

        User ValidateCredentials(string userName);

        User RefreshUserInfo(User user);

        bool RevokeToken(string userName);
    }
}
