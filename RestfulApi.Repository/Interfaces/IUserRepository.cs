using RestfulApi.Models.Core.Entities;
using RestfulApi.Models.Data.VO;

namespace RestfulApi.Repository.Interfaces
{
    public interface IUserRepository
    {
        User ValidateCredentials(UserVO user);

        User RefreshUserInfo(User user);
    }
}
