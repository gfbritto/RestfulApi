using RestfulApi.Models.Data.VO;

namespace RestfulApi.Business.Interfaces
{
    public interface ILoginBusiness
    {
        TokenVO ValidateCredentials(UserVO userCredentials);

        TokenVO ValidateCredentials(TokenVO token);

        bool RevokeToken(string userName);
    }
}
