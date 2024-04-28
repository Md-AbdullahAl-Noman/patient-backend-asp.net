using AutoMapper;
using BLL.DTO;
using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
     public class AppointmentService
    {

        private static  IMapper mapper;
        static AppointmentService()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Appointment, AppointmentDTO>();
                cfg.CreateMap<AppointmentDTO, Appointment>();
            });
            mapper = config.CreateMapper();
        }

        public static List<AppointmentDTO> GetAll()
        {
            var data = DataAccessFactory.AppointmentData().GetAll();
            var mapped = mapper.Map<List<AppointmentDTO>>(data);
            return mapped;
        }

        public static AppointmentDTO GetById(int id)
        {
            var data = DataAccessFactory.AppointmentData().GetById(id);
            var mapped = mapper.Map<AppointmentDTO>(data);
            return mapped;
        }

        public static AppointmentDTO Create(AppointmentDTO appointmentDTO)
        {
            var appointment = mapper.Map<Appointment>(appointmentDTO);
            var createdAppointment = DataAccessFactory.AppointmentData().Create(appointment);
            var mapped = mapper.Map<AppointmentDTO>(createdAppointment);
            return mapped;
        }

        public static bool Update(int id, AppointmentDTO appointmentDTO)
        {
            var appointmentRepo = DataAccessFactory.AppointmentData();
            var existingAppointment = appointmentRepo.GetById(id);
            if (existingAppointment == null)
            {
                return false;
            }
            mapper.Map(appointmentDTO, existingAppointment);
            var result = appointmentRepo.Update(existingAppointment);
            return result != null;
        }

        public static bool Delete(int id)
        {
            return DataAccessFactory.AppointmentData().Delete(id);
        }


    }
}
