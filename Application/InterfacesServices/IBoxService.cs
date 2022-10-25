using Application.DTOs;
using Domain.Entities;

namespace Application.InterfacesServices;

public interface IBoxService
{
    public void RebuildDB();
    List<Box> GetAllBoxes();
    Box CreateBox(PostBoxDTO boxDto);
    Box GetBoxById(int id);
    Box DeleteBox(int id);
    Box UpdateBox(int id, Box box);
}