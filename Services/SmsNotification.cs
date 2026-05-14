using System;
using notificationsystem.Models;
using notificationsystem.Interfaces;

namespace notificationsystem.Services;

public class SmsNotification : INotification
{
    public void Send(User user, Notification notification)
    {
        Console.WriteLine($"SMS To: {user.Number}");
        Console.WriteLine($"{notification.Message}");
        Console.WriteLine($"Sent At: {notification.Sentat}");
    }
}