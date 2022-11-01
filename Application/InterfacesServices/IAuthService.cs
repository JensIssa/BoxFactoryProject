using Application.DTOs;

namespace Application.InterfacesServices;

public interface IAuthService
{
    public string Register(LoginAndRegisterDTO dto);
    public string Login(LoginAndRegisterDTO dto);
}