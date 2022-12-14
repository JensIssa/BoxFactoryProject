namespace Application.DTOs;

public class PutBoxDTO
{
    public int Id
    {
        get;
        set;
    }
    public string BoxName
    {
        get;
        set;
    }

    public double Heigth
    {
        get;
        set;
    }

    public double Length
    {
        get;
        set;
    }
    
    public double Width
    {
        get;
        set;
    }

    public string ImageUrl
    {
        get;
        set;
    }

    public string Description
    {
        get;
        set;
    }
}