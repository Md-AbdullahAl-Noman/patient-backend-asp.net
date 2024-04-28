using DAL.Interface;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
     internal class PatientRepo : Repos, IRepo<Patient, int, Patient>
    {
        public Patient Create(Patient obj)
        {
            db.Patients.Add(obj);
            if (db.SaveChanges() > 0)
                return obj;
            return null;
        }

        public bool Delete(int id)
        {
            var patientToDelete = db.Patients.FirstOrDefault(p => p.Id == id);
            if (patientToDelete != null)
            {
                db.Patients.Remove(patientToDelete);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public List<Patient> GetAll()
        {
            return db.Patients.ToList();
        }

        public Patient GetById(int id)
        {
            return db.Patients.FirstOrDefault(p => p.Id == id);
        }

       
        public Patient Update(Patient obj)
        {
            var existingPatient = db.Patients.Find(obj.Id);
            if (existingPatient != null)
            {
                db.Entry(existingPatient).CurrentValues.SetValues(obj);

                db.SaveChanges();
                return existingPatient;
            }
            return null;
        }
    }
}
