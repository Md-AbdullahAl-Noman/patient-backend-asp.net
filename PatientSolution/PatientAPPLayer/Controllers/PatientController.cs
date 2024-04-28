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
    public class PatientController : ApiController
    {
        [HttpGet]
        [Route("api/patient/getall")]
        public HttpResponseMessage GetPatient()
        {
           
            try {
                var data = PatientService.GetAll();

                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex) {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message=ex.Message });
            
            }
        
         
        }

        [HttpGet]
        [Route("api/patient/get/{id}")]
        public HttpResponseMessage GetPatientById(int id)
        {
            try
            {
                var data = PatientService.GetById(id);
                if (data != null)
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                else
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "Patient not found" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpPost]
        [Route("api/patient/create")]
        public HttpResponseMessage CreatePatient(PatientDTO patient)
        {
            try
            {
                var data = PatientService.Create(patient);
                return Request.CreateResponse(HttpStatusCode.Created, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpPatch]
        [Route("api/patient/update/{id}")] 
        public HttpResponseMessage UpdatePatient(int id, PatientDTO patientDTO)
        {
            try
            {
                bool isUpdated = PatientService.Update(id, patientDTO);
                if (isUpdated)
                    return Request.CreateResponse(HttpStatusCode.OK, "Patient updated successfully");
                else
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Patient not found");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpDelete]
        [Route("api/patient/delete/{id}")]
        public HttpResponseMessage DeletePatient(int id)
        {
            try
            {
                var success = PatientService.Delete(id);
                if (success)
                    return Request.CreateResponse(HttpStatusCode.OK,"Deleted Successfully");
                else
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "Patient not found" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

    }
}
