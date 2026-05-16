namespace NotificationModelLibrary.Models;

public class Notification
{
    public int Id {get; set;}
    public User? User {get; set;}
    public int UserId { get; set; } 
    public string Message {get; set;} = string.Empty;
    public string NotificationType {get; set;} = string.Empty;
    public DateTime SentAt {get; set;} 

    public Notification()
    {
        SentAt = DateTime.UtcNow;
    }
}

