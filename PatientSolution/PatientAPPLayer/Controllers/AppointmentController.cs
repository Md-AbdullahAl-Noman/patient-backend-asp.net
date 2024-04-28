using BLL.DTO;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PatientAPPLayer.Controllers
{
    public class AppointmentController : ApiController
    {
        [HttpGet]
        [Route("api/appointment/getall")]
        public HttpResponseMessage Getappointment()
        {

            try
            {
                var data = AppointmentService.GetAll();

                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });

            }


        }

        [HttpGet]
        [Route("api/appointment/get/{id}")]
        public HttpResponseMessage GetAppointmentById(int id)
        {
            try
            {
                var data = AppointmentService.GetById(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpPost]
        [Route("api/appointment/book")]
        public HttpResponseMessage CreateAppointment(AppointmentDTO appointmentDTO)
        {
            try
            {
                var result = AppointmentService.Create(appointmentDTO);
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpPut]
        [Route("api/appointment/update/{id}")]
        public HttpResponseMessage UpdateAppointment(int id,  AppointmentDTO appointmentDTO)
        {
            try
            {
                var result = AppointmentService.Update(id, appointmentDTO);
                if (result)
                    return Request.CreateResponse(HttpStatusCode.OK, "Appointment updated successfully.");
                else
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Appointment not found.");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpDelete]
        [Route("api/appointment/delete/{id}")]
        public HttpResponseMessage DeleteAppointment(int id)
        {
            try
            {
                var result = AppointmentService.Delete(id);
                if (result)
                    return Request.CreateResponse(HttpStatusCode.OK, "Appointment deleted successfully.");
                else
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Appointment not found.");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }
    }
}
