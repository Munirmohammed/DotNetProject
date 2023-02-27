using ReSTful_letcom_user_management_API.Models;

namespace ReSTful_letcom_user_management_API.Services
{
    public interface IUserService
    {
        List<Users> Get();
        Users Get(string id);
        Users Create(Users users);
        void Update(string id, Users users);
        void Remove (string id);
    }
}
