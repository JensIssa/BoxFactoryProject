using Domain.Entities;

namespace Application.InterfacesRepos;

public interface IManagerRepository
{
    Manager login(string username, string password);
}