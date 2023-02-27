using REST_letcom_API_V2.Models;

namespace REST_letcom_API_V2.Services
{
    public interface IAppointmentService
    {
        List<Appointment> Get();
        Appointment Get(string id);
        Appointment Create(Appointment appointment);
        void Update(string id, Appointment appointment);
        void Remove(string id);
    }
}
