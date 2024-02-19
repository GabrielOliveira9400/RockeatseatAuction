using RockeatseatAuction.API.Entities;
using RockeatseatAuction.API.Interfaces;
using RockeatseatAuction.API.Repositories;

namespace RockeatseatAuction.API.Services;

public class LoggedUser
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IUserRepository _userRepository;
    
    public LoggedUser(IHttpContextAccessor httpContextAccessor, IUserRepository userRepository)
    {
        _httpContextAccessor = httpContextAccessor;
        _userRepository = userRepository;
    }
    public User User()
    {
        var token = TokenOnRequest();
        
        var email = FromBase64String(token);
        
        return _userRepository.GetByEmail(email);
    }
    
    private string TokenOnRequest()
    {
        var authentication = _httpContextAccessor.HttpContext!.Request.Headers.Authorization.ToString();
        
        return authentication["Bearer ".Length..];
    }

    private string FromBase64String(string base64) => System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(base64));
}