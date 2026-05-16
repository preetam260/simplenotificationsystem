using System;
public class EmailNotification : INotification
{
    public void Send(User user, Notification notification)
    {
        Console.WriteLine($"Email To: {user.Email}");
        Console.WriteLine($"{notification.Message}");
        Console.WriteLine($"Sent At: {notification.SentAt}");
    }
}