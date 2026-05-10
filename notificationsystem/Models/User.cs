using System.Globalization;

public class User
{
    public string Name {get; set;}

    public string Email {get; set;}

    public string Number {get; set;}

    public User(string inputname, string inputemail, string phonenumber)
    {
        Name = inputname;
        Email = inputemail;
        Number = phonenumber;
    }
}