using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HealthPlus.Core.Abstractions;
using HealthPlus.Core.DataTransferObjects;
using AutoMapper;

namespace HealthPlus.WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DocAppointmentController : ControllerBase
    {
        private static List<DocAppointmentDto> DocAppointments = new List<DocAppointmentDto>()
        {
            new DocAppointmentDto()
            {
                Id =Guid.NewGuid(),
                UserId = Guid.NewGuid(),
                Specialization = "123",
                Note = "empty",
                AppointmentDate = DateTime.Now
            },
                        new DocAppointmentDto()
            {
                Id =Guid.NewGuid(),
                UserId = Guid.NewGuid(),
                Specialization = "1244",
                Note = "empdy2",
                AppointmentDate = DateTime.Now
            }
        };
        [HttpGet("id")]
        public IActionResult GetDocAppointmentById(Guid id)
        {
            var docAppointment = DocAppointments.FirstOrDefault(dto => dto.Id.Equals(id));
                return Ok(docAppointment);
        }
        [HttpGet]
        public IActionResult GetDocAppointmentByName(string specialization)
        {
            var docAppointments = DocAppointments.Where(dto => dto.Specialization.Equals(specialization));
            return Ok(docAppointments);
        }

        //[HttpGet]
        //public IActionResult GetDocAppointmentByDate(DateTime selectedDateTime)
        //{
        //    var docAppointments = DocAppointments.Where(dto => dto.AppointmentDate.Equals(selectedDateTime));
        //    return Ok(docAppointments);
        //}
    }
}
