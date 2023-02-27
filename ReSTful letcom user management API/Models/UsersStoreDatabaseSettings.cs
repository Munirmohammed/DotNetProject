namespace ReSTful_letcom_user_management_API.Models
{
    public class UsersStoreDatabaseSettings : IUsersStoreDatabaseSettings
    {
        public string CollectionName { get; set; } = String.Empty;
        public string ConnectionString { get; set; } = String.Empty;
        public string DatabaseName { get; set; } = String.Empty;
    }
}
