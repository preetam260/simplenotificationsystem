namespace notificationsystem.Models;

public class Notification
{
    public int Id {get; set;}
    public int Userid { get; set; }
    public string Message {get; set;} = string.Empty;
    public string NotificationType {get; set;} = string.Empty;
    public DateTime Sentat {get; set;} 

    public Notification()
    {
        Sentat = DateTime.Now;
    }
}

