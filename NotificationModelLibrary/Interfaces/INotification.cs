namespace NotificationModelLibrary;

public interface INotification
{
    void Send(User user, Notification notification);
}
