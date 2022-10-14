using Application.DTOs;
using Domain.Entities;

namespace Application.InterfacesServices;

public interface IBoxService
{
    List<Box> GetAllBoxex();
    Box CreateBox(PostBoxDTO boxDto);
    Box GetBoxById(int id);
    Box DeleteBox(int id);
    Box UpdateBox(int id, Box box);
}