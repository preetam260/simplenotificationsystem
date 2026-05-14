using notificationsystem.Databases;
using notificationsystem.Interfaces;
using notificationsystem.Models;
using notificationsystem.Repositories;

namespace notificationsystem.Services;

public class NotificationServices
{
    NotificationRepository notificationRepository = new NotificationRepository();

    public void SendNotification(User user, Notification notification){
        INotification sender = notification.NotificationType.ToLower() switch
        {
            "email" => new EmailNotification(),
            "sms" => new SmsNotification(),
            _ => throw new ArgumentException($"Unknown notification type: {notification.NotificationType}")
        };
        sender.Send(user, notification);
        notificationRepository.AddNotification(notification);
    }

    public List<string> GetNotificationHistory() {
        return notificationRepository.GetNotificationHistory();
    }

    
}