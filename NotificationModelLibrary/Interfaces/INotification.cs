using NotificationModelLibrary.Models;

namespace NotificationModelLibrary.Interfaces;

public interface INotification
{
    void Send(User user, Notification notification);
}
