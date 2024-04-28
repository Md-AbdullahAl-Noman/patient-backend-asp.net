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
     public class PatientService
    {

        public static List<PatientDTO> GetAll()
        {

            var data = DataAccessFactory.PatientData().GetAll();
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Patient, PatientDTO>();

            });

            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<PatientDTO>>(data);
            return mapped;

        }



        public static PatientDTO GetById(int id)
        {
            var data = DataAccessFactory.PatientData().GetById(id);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Patient, PatientDTO>();
            });

            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<PatientDTO>(data);
            return mapped;
        }

        public static PatientDTO Create(PatientDTO patientDTO)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<PatientDTO, Patient>();
                cfg.CreateMap<Patient, PatientDTO>();
            });

            var mapper = new Mapper(config);
            var patient = mapper.Map<Patient>(patientDTO); 

            var createdPatient = DataAccessFactory.PatientData().Create(patient);
            var mapped = mapper.Map<PatientDTO>(createdPatient); 

            return mapped;
        }

        public static bool Update(int id, PatientDTO patientDTO)
        {
            
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<PatientDTO, Patient>();
            });

            var mapper = new Mapper(cfg);

           
            var patientRepo = DataAccessFactory.PatientData();

           
            var existingPatient = patientRepo.GetById(id);
            if (existingPatient == null)
            {
                return false; 
            }

            
            mapper.Map(patientDTO, existingPatient);

            
            var result = patientRepo.Update(existingPatient);
            return result != null; 
        }

        public static bool Delete(int id)
        {
            return DataAccessFactory.PatientData().Delete(id);
        }




    }
}
