using RestfulApi.Models.Data.VO;

namespace RestfulApi.Business.Interfaces
{
    public interface ILoginBusiness
    {
        TokenVO ValidateCredentials(UserVO userCredentials);
    }
}
