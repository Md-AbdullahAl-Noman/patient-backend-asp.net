using DAL.Interface;
using DAL.Models;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataAccessFactory
    {
        public static IRepo<Patient, int, Patient> PatientData() {
            return new  PatientRepo();
        }
        public static IRepo<Appointment, int, Appointment> AppointmentData()
        {
            return new AppointmentRepo();
        }
    }
}
