using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using RockeatseatAuction.API.Interfaces;
using RockeatseatAuction.API.Repositories;

namespace RockeatseatAuction.API.Filters;

public class AuthenticationUserAttribute : AuthorizeAttribute, IAuthorizationFilter
{
    private IUserRepository _userRepository;
    
    public AuthenticationUserAttribute(IUserRepository userRepository) => _userRepository = userRepository;
    
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        try
        {
            var token = TokenOnRequest(context.HttpContext);

            var email = FromBase64String(token);
        
            var existEmail = _userRepository.ExistUserWithEmail(email);

            if (!existEmail)
            {
                context.Result = new UnauthorizedObjectResult("Email not valid");
            }
        }
        catch (Exception e)
        {
            context.Result = new UnauthorizedObjectResult(e.Message);
        }
    }

    private string TokenOnRequest(HttpContext context)
    {
        var authentication = context.Request.Headers.Authorization.ToString();

        if (string.IsNullOrEmpty(authentication) || !authentication.StartsWith("Bearer "))
        {
            throw new Exception("Token not found");
        }

        return authentication["Bearer ".Length..];
    }

    private string FromBase64String(string base64) => System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(base64));
}