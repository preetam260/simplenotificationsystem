using System.Linq;
using System;
public class NotificationRepository : AbstractRepository<Notification>
{
    public override Notification? GetById(int id)
    {
        return items.FirstOrDefault(notification => notification.Id == id);
    }

    public override void Update(Notification notification)
    {
        var notif = GetById(notification.Id);
        if(notif != null)
        {
            notif.UserId = notification.UserId;
            notif.Type = notification.Type;
            notif.Message = notification.Message;
            notif.SentAt = DateTime.Now;
        }
    }

    public override void Delete(int id)
    {
        var notif = GetById(id);
        if(notif != null) items.Remove(notif);
    }
}