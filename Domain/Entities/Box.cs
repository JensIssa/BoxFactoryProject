namespace Domain.Entities;

public class Box
{
    private int id;
    private string boxName;
    private double heigth;
    private double length;
    private double width;
    private string imageUrl;
    private string description;
    
    public int Id
    {
        get => id;
    }

    public string BoxName
    {
        get => boxName;
    }

    public double Heigth
    {
        get => heigth;
    }

    public double Length
    {
        get => length;
    }

    public double Width
    {
        get => width;
    }

    public string ImageUrl
    {
        get => imageUrl;
    }

    public string Description
    {
        get => description;
    }
}