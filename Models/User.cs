namespace notificationsystem.Models;

public class User
{
    public int Id {get; set;}
    public string Username {get; set;}
    public string Email {get; set;}
    public string Number {get; set;}

    public User(string inputname, string inputemail, string phonenumber)
    {   
        Username = inputname;
        Email = inputemail;
        Number = phonenumber;
    }
}