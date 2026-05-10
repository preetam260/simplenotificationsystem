public class Notification
{
    public string Message{get; set;}
    public DateTime Sent{get;}


    public Notification(string Smessage)
    {
        Message = Smessage;
        Sent = DateTime.Now;
    }
}