namespace Domain.Entities;

public class Box
{
    private int id;
    private string boxName;
    private double heigth;
    private double length;
    private double width;
    
    public Box(int id, string boxName, double heigth, double length, double width)
    {
        this.id = id;
        this.boxName = boxName;
        this.heigth = heigth;
        this.length = length;
        this.width = width;
    }
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
}