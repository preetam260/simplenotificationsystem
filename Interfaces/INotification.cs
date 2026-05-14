using notificationsystem.Models;

namespace notificationsystem.Interfaces;

public interface INotification
{
    void Send(User user, Notification notification);
}
