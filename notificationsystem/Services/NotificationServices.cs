public class NotificationService
{
    public void SendNotification(INotification notifier, User user, string message)
    {
        var notification = new Notification(message);
        notifier.Send(user, notification);

        /*
        this helps if company wants to extend to whatsapp service: 
        we can have a new service whatsapp inheriting Inotification 
            public class WhatsappNptifiation : INotification {
                public void Send() {}
        */
    }
}
