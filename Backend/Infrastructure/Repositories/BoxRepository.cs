using Application.InterfacesRepos;
using Domain.Entities;

namespace Infrastructure.Repositories;

public class BoxRepository: IBoxRepository
{
    private RepositoryDBContext _repositoryDbContext;

    public BoxRepository(RepositoryDBContext repositoryDbContext)
    {
        _repositoryDbContext = repositoryDbContext;
    }

    public List<Box> GetAllBoxes()
    {
        return _repositoryDbContext.BoxTable.ToList();
    }

    public Box GetBoxById(int id)
    {
        return _repositoryDbContext.BoxTable.Find(id) ?? throw new KeyNotFoundException("Id not found");
    }

    public Box CreateBox(Box box)
    {
        _repositoryDbContext.BoxTable.Add(box);
        _repositoryDbContext.SaveChanges();
        return box;
    }

    public Box UpdateBox(Box box, int id)
    {
        _repositoryDbContext.BoxTable.Update(box);
            _repositoryDbContext.SaveChanges();
            return box;
    }

    public Box DeleteBox(int id)
    {
         var boxToDelete = _repositoryDbContext.BoxTable.Find(id) ?? throw new KeyNotFoundException("Id to delete not found");
        _repositoryDbContext.BoxTable.Remove(boxToDelete);
        _repositoryDbContext.SaveChanges();
        return boxToDelete;
    }

    public void RebuildDb()
    {
        _repositoryDbContext.Database.EnsureDeleted();
        _repositoryDbContext.Database.EnsureCreated();
    }
}