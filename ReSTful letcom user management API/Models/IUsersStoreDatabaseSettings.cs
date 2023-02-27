namespace ReSTful_letcom_user_management_API.Models
{
    public interface IUsersStoreDatabaseSettings
    {
        string CollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
