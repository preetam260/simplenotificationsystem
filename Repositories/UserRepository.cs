using System.Linq;
public class UserRepository : AbstractRepository<User>
{
    public override User? GetById(int id)
    {
        return items.FirstOrDefault(user => user.Id == id);
    }

    public override void Update(User user) // user contains updated details
    {
        var userr = GetById(user.Id); // get the object of existing user using id
        if(userr != null)
        {
            userr.Name = user.Name;
            userr.Email = user.Email;
            userr.Number = user.Number;
        }
    }

    public override void Delete(int id)
    {
        var user = GetById(id);

        if(user != null) items.Remove(user);
    }
}