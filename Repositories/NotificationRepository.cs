using System.Linq;
using System;
public class NotificationRepository : AbstractRepository<Notification>
{
    public override Notification? GetById(int id)
    {
        return items.FirstOrDefault(notification => notification.Id == id);
    }

    public override void Update(Notification notification) // contains updated notif details
    {
        var notif = GetById(notification.Id); //grabbing exisiting notification object
        if(notif != null)
        {
            notif.UserId = notification.UserId; // if you want to update who youre sending notif to
            notif.Type = notification.Type;
            notif.Message = notification.Message;
            notif.SentAt = notification.SentAt; //
        }
    }

    public override void Delete(int id)
    {
        var notif = GetById(id);
        if(notif != null) items.Remove(notif);
    }
}
