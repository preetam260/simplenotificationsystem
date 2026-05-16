namespace NotificationModelLibrary;

public class User
{
    public int Id {get; set;}
    public string Username {get; set;} = string.Empty;
    public string Email {get; set;} = string.Empty;
    public string Number {get; set;} = string.Empty;
    public ICollection<Notification> Notifications { get; set; } = new List<Notification>();
    
    public User() { }
    
    public User(string inputname, string inputemail, string phonenumber)
    {   
        Username = inputname;
        Email = inputemail;
        Number = phonenumber;
    }
}