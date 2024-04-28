using DAL.Interface;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
      internal class AppointmentRepo : Repos, IRepo<Appointment, int, Appointment>
    {
        public Appointment Create(Appointment obj)
        {
            db.Appointments.Add(obj);
            db.SaveChanges();
            return obj;
        }

        public bool Delete(int id)
        {
            var appointmentToDelete = db.Appointments.FirstOrDefault(a => a.Id == id);
            if (appointmentToDelete != null)
            {
                db.Appointments.Remove(appointmentToDelete);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public List<Appointment> GetAll()
        {
            return db.Appointments.ToList();
        }

        public Appointment GetById(int id)
        {
            return db.Appointments.FirstOrDefault(a => a.Id == id);
        }

        public Appointment Update(Appointment obj)
        {
            var existingAppointment = db.Appointments.Find(obj.Id);
            if (existingAppointment != null)
            {
                db.Entry(existingAppointment).CurrentValues.SetValues(obj);
                db.SaveChanges();
                return existingAppointment;
            }
            return null;
        }
    }
}
