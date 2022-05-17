using Microsoft.IdentityModel.JsonWebTokens;
using RestfulApi.Business.Interfaces;
using RestfulApi.Models.Configuration;
using RestfulApi.Models.Core.Entities;
using RestfulApi.Models.Data.VO;
using RestfulApi.Repository.Interfaces;
using RestfulApi.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace RestfulApi.Business.Implementations
{
    public class LoginBusiness : ILoginBusiness
    {
        private const string DATE_FORMAT = "yyyy-MM-dd HH:MM:SS";
        private readonly TokenConfiguration _configuration;

        private readonly IUserRepository _repository;
        private readonly ITokenService _tokenService;

        public LoginBusiness(TokenConfiguration configuration, IUserRepository repository, ITokenService tokenService)
        {
            _configuration = configuration;
            _repository = repository;
            _tokenService = tokenService;
        }

        public TokenVO ValidateCredentials(UserVO userCredentials)
        {
            var user = _repository.ValidateCredentials(userCredentials);

            if (user == null)
            {
                return null;
            }

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString("N")),
                new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName)
            };

            var acessToken = _tokenService.GenerateAcessToken(claims);
            var refreshToken = _tokenService.GenerateRefreshToken();

            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiryTime = DateTime.Now.AddDays(_configuration.DaysToExpiry);

            _repository.RefreshUserInfo(user);

            return RefreshUserToken(acessToken, refreshToken, user);
        }

        public TokenVO ValidateCredentials(TokenVO token)
        {
            var acessToken = token.AcessToken;
            var refreshToken = token.RefreshToken;

            var principal = _tokenService.GetPrincipalFromExpiredToken(acessToken);

            var userName = principal.Identity.Name;

            var user = _repository.ValidateCredentials(userName);

            var isInvalidToken = user.RefreshToken != refreshToken || user.RefreshTokenExpiryTime <= DateTime.Now;

            if (user == null || isInvalidToken)
            {
                return null;
            }

            acessToken = _tokenService.GenerateAcessToken(principal.Claims);
            refreshToken = _tokenService.GenerateRefreshToken();

            user.RefreshToken = refreshToken;

            return RefreshUserToken(acessToken, refreshToken, user);
        }

        private TokenVO RefreshUserToken(string acessToken, string refreshToken, User user)
        {
            _repository.RefreshUserInfo(user);

            var createDate = DateTime.Now;
            var expirationDate = createDate.AddMinutes(_configuration.Minutes);

            return new TokenVO(
                true,
                createDate.ToString(DATE_FORMAT),
                expirationDate.ToString(DATE_FORMAT),
                acessToken,
                refreshToken
            );
        }

        public bool RevokeToken(string userName)
        {
            return _repository.RevokeToken(userName);
        }
    }
}
