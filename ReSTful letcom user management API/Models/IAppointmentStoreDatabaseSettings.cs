namespace REST_letcom_API_V2.Models
{
    public interface IAppointmentStoreDatabaseSettings
    {
        string AppointmentCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
