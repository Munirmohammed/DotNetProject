using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using REST_letcom_API_V2.Models;
using REST_letcom_API_V2.Services;

namespace REST_letcom_API_V2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService appointmentService;

        public AppointmentController(IAppointmentService appointmentService)
        {
            this.appointmentService = appointmentService;
        }
        // GET: api/<StudentsController>
        [HttpGet]
        public ActionResult<List<Appointment>> Get()
        {
            return appointmentService.Get();
        }

        // GET api/<StudentsController>/5
        [HttpGet("{id}")]
        public ActionResult<Appointment> Get(string id)
        {
            var appointment = appointmentService.Get(id);

            if (appointment == null)
            {
                return NotFound("No appointment found");
            }

            return appointment;
        }

        // POST api/<StudentsController>
        [HttpPost]
        public ActionResult<Appointment> Post([FromBody] Appointment appointment)
        {
            appointmentService.Create(appointment);

            return CreatedAtAction(nameof(Get), new { id = appointment.Id }, appointment);
        }

        // PUT api/<StudentsController>/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] Appointment appointment)
        {
            var existingAppointment = appointmentService.Get(id);

            if (existingAppointment == null)
            {
                return NotFound("No appointment");
            }

            appointmentService.Update(id, appointment);

            return NoContent();
        }

        // DELETE api/<StudentsController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var appointment = appointmentService.Get(id);

            if (appointment == null)
            {
                return NotFound("you don't have any appointment");
            }

            appointmentService.Remove(appointment.Id);

            return Ok("appointment cancelled!");
        }
    }
}
