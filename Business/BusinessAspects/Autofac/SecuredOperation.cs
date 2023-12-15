using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Authentication;
using System.Text;
using Business.Constants;
using Castle.DynamicProxy;
using Core.Extensions;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Business.BusinessAspects.Autofac
{
    public class SecuredOperation : MethodInterception
    {
        private string[] _roles;
        private IHttpContextAccessor _httpContextAccessor;
        private JwtSecurityTokenHandler tokenHandler;

        public SecuredOperation(string roles)
        {
            _roles = roles.Split(',');
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
            tokenHandler = ServiceTool.ServiceProvider.GetService<JwtSecurityTokenHandler>();
        }

        protected override void OnBefore(IInvocation invocation)
        {
            var token = _httpContextAccessor.HttpContext.Request.Headers.SingleOrDefault(h => h.Key == "Authorization");
            var tokenString = token.Value.ToString();
            tokenString = tokenString.Split(" ")[1];
            var readedToken = tokenHandler.ReadJwtToken(tokenString);
            var tokenClaims = readedToken.Claims.FirstOrDefault(c => c.Type == "http://schemas.microsoft.com/ws/2008/06/identity/claims/role");
            var claims = tokenClaims.Value;

            foreach (var role in _roles)
            {
                if (claims.Contains(role))
                {
                    return;
                }
            }
            throw new AuthenticationException(Messages.AuthorizationDenied);
        }
    }
}
