using NotificationDALLibrary;
using NotificationModelLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace NotificationBLLibrary;

public class NotificationService
{
    private readonly AppDbContext _context;
    private readonly EmailNotification _emailNotification;
    private readonly SmsNotification _smsNotification;

    public NotificationService(AppDbContext context, EmailNotification email, SmsNotification sms)
    {
        _context = context;
        _emailNotification = email;
        _smsNotification = sms;
    }
    public void AddUser(User user) {
        _context.Users.Add(user);
        _context.SaveChanges();
    }
    public List<User> GetAllUsers() {
        return _context.Users.ToList();
    }
    public void SendNotification(Notification notification){
        // Validate notification type
        string notificationType = notification.NotificationType.ToLower();

        if(string.IsNullOrWhiteSpace(notification.Message))
            throw new Exception("Message empty");

        if(notification.Message.Length < 5)
            throw new Exception("Message too short");

        if(notificationType == "sms" && notification.Message.Length > 160)
            throw new Exception("SMS too long");
            
        if (notificationType != "email" && notificationType != "sms")
            throw new Exception("Invalid notification type");

        // Find user
        User? user = _context.Users.FirstOrDefault(u => u.Id == notification.UserId);
        if (user == null)
        {
            throw new Exception($"User with id {notification.UserId} not found");
        }

        // Send through appropriate service
        if (notificationType == "email")
        {
            _emailNotification.Send(user, notification);
        }
        else if (notificationType == "sms")
        {
            _smsNotification.Send(user, notification);
        }

        // Save to database
        _context.Notifications.Add(notification);
        _context.SaveChanges();
        System.Console.WriteLine($"Notification sent to user with id: {notification.UserId}");
    }

    public List<Notification> GetNotifications()
    {
        return _context.Notifications.Include(n => n.User).ToList();
    }
    
}