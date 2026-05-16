
public class Notification
{
    public int Id {get; set;} // needed for retrieval, updation & deletion
    public int UserId {get; set;} //of the reciever
    public string Type {get; set;} = string.Empty;
    public string Message{get; set;} = string.Empty;
    public DateTime SentAt{get; set;}

}