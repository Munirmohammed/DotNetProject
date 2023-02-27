using MongoDB.Driver;
using REST_letcom_API_V2.Models;

namespace REST_letcom_API_V2.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IMongoCollection<Appointment> _appointments;

        public AppointmentService(IAppointmentStoreDatabaseSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _appointments = database.GetCollection<Appointment>(settings.AppointmentCollectionName);
        }

        public Appointment Create(Appointment appointment)
        {
            _appointments.InsertOne(appointment);
            return appointment;
        }

        public List<Appointment> Get()
        {
            return _appointments.Find(appointment => true).ToList();
        }

        public Appointment Get(string id)
        {
            return _appointments.Find(appointment => appointment.Id == id).FirstOrDefault();
        }

        public void Remove(string id)
        {
            _appointments.DeleteOne(appointment => appointment.Id == id);
        }

        public void Update(string id, Appointment appointment)
        {
            _appointments.ReplaceOne(appointment => appointment.Id == id, appointment);
        }
    }
}
