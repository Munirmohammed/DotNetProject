namespace REST_letcom_API_V2.Models
{
    public class AppointmentStoreDatabaseSettings : IAppointmentStoreDatabaseSettings
    {
        public string AppointmentCollectionName { get; set; } = String.Empty;
        public string ConnectionString { get; set; } = String.Empty;
        public string DatabaseName { get; set; } = String.Empty;
    }
}
