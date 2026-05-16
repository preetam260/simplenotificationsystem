using System;
using System.Collections.Generic;
public class NotificationService
{
    private readonly UserRepository _userRepository;
    private readonly NotificationRepository _notificationRepository;

    public NotificationService(UserRepository userRepository, NotificationRepository notificationRepository)
    {
        _userRepository = userRepository;
        _notificationRepository = notificationRepository;
    }

    public void AddUser(User user)
    {
        _userRepository.Add(user);
    }

    public List<User> GetAllUsers()
    {
        return _userRepository.GetAll();
    }

    public List<Notification> GetAllNotifications()
    {
        return _notificationRepository.GetAll();
    }

    public void SendNotification(INotification notifier, int userId, string message, string type)
    {
        var user = _userRepository.GetById(userId);

        if (user == null)
        {
            Console.WriteLine("User not found.");
            return;
        }

        var notification = new Notification {
            Id = _notificationRepository.GetAll().Count + 1,
            Message = message,
            Type = type,
            SentAt = DateTime.Now,
            UserId = userId
        };

        notifier.Send(user, notification);
        _notificationRepository.Add(notification);
    }

    public void DeleteNotification(int id)
    {
        _notificationRepository.Delete(id);
    }

}