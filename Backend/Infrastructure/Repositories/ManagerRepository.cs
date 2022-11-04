using Application.InterfacesRepos;
using Domain.Entities;

namespace Infrastructure.Repositories;

public class ManagerRepository : IManagerRepository
{
    private readonly RepositoryDBContext _context;
    
    public ManagerRepository(RepositoryDBContext context)
    {
        _context = context;
    }

    public Manager GetManagerByUsername(string username)
    {
        return _context.ManagerTable.FirstOrDefault(m => m.Username == username) ?? throw new KeyNotFoundException("There was no matching username found");
    }

    public Manager CreateNewManager(Manager manager)
    {
        _context.ManagerTable.Add(manager);
        _context.SaveChanges();
        return manager;
    }
    
}