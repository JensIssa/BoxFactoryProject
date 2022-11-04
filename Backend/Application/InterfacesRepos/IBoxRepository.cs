using Domain.Entities;

namespace Application.InterfacesRepos;

public interface IBoxRepository
{
    List<Box> GetAllBoxes();
    Box GetBoxById(int id);
    Box CreateBox(Box box);
    Box UpdateBox(Box box, int id);
    Box DeleteBox(int id);
    public void RebuildDb();
}