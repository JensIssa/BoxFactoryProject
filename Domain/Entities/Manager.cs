namespace Domain.Entities;

public class Manager
{
    private int id;
    private string firstName;
    private string lastName;
    private string username;
    private string password;

    public Manager()
    {
        
    }
    public Manager(int id, string firstName, string lastName, string username, string password)
    {
        this.id = id;
        this.firstName = firstName;
        this.lastName = lastName;
        this.username = username;
        this.password = password;
    }

    public int Id
    {
        get => id;
    }

    public string FirstName
    {
        get => firstName;
    }

    public string LastName
    {
        get => lastName;
    }

    public string Username
    {
        get => username;
    }

    public string Password
    {
        get => password;
    }
}