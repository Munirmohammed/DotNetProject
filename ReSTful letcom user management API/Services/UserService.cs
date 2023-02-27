using ReSTful_letcom_user_management_API.Models;
using MongoDB.Driver;
using System.Text;

namespace ReSTful_letcom_user_management_API.Services
{
    public class UserService : IUserService
    {
        private readonly IMongoCollection<Users> _users;

        public UserService(IUsersStoreDatabaseSettings Settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(Settings.DatabaseName);
            _users = database.GetCollection<Users>(Settings.CollectionName);

        }

        public Users Create(Users users)
        {
            _users.InsertOne(users);
            return users;
        }

        public List<Users> Get()
        {
            return _users.Find(Users => true).ToList();
        }

        public Users Get(string id)
        {
            return _users.Find(users => users.Id == id).FirstOrDefault();
            
        }

        public void Remove(string id)
        {
            _users.DeleteOne(users=> users.Id == id);
        }

        public void Update(string id, Users users)
        {
            _users.ReplaceOne(users=> users.Id == id, users);
        }
    }
}
