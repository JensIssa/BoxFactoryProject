using Domain.Entities;

namespace Application.InterfacesRepos;

public interface IManagerRepository
{
    public Manager GetManagerByUsername(string username);
    public Manager CreateNewManager(Manager manager);
}