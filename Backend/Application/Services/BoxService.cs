using Application.DTOs;
using Application.InterfacesRepos;
using Application.InterfacesServices;
using AutoMapper;
using Domain.Entities;
using FluentValidation;

namespace Application.Services;

public class BoxService : IBoxService
{
    private readonly IBoxRepository _repository;
    private readonly IMapper _mapper;
    private readonly IValidator<PostBoxDTO> _postValidator;
    private readonly IValidator<PutBoxDTO> _boxValidator;

    public BoxService(IBoxRepository repository, IMapper mapper, IValidator<PostBoxDTO> postValidator, IValidator<PutBoxDTO> boxValidator)
    {
        _repository = repository;
        _mapper = mapper;
        _postValidator = postValidator;
        _boxValidator = boxValidator;
    }

    public void RebuildDB()
    {
        _repository.RebuildDb();
    }

    public List<Box> GetAllBoxes()
    {
        return _repository.GetAllBoxes();
    }

    public Box CreateBox(PostBoxDTO boxDto)
    {
        var validation = _postValidator.Validate(boxDto);
        if (!validation.IsValid)
        {
            throw new ValidationException(validation.ToString());
        }
        return _repository.CreateBox(_mapper.Map<Box>(boxDto));
    }

    public Box GetBoxById(int id)
    {
        return _repository.GetBoxById(id);
    }

    public Box DeleteBox(int id)
    {
        return _repository.DeleteBox(id);
    }

    public Box UpdateBox(int id, PutBoxDTO box)
    {
        if (id != box.Id)
        {
            throw new ValidationException("ID in body and route are different");
        }
        var validation = _boxValidator.Validate(box);
        if (!validation.IsValid)
        {
            throw new ValidationException(validation.ToString());
        }
        return _repository.UpdateBox(_mapper.Map<Box>(box), id);
    }
}