namespace DAL.Migrations
{
    using DAL.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DAL.Models.PatientContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DAL.Models.PatientContext context)
        {
            var patient1 = new Patient { Name = "Noman", Password = "12345", Email = "noman@example.com", Phone = "123-456-7890", DateOfBirth = new DateTime(1985, 5, 10) };
            var patient2 = new Patient { Name = "Das", Password = "123456", Email = "das@example.com", Phone = "987-654-3210", DateOfBirth = new DateTime(1990, 8, 15) };

            // Create some sample doctors
            var doctor1 = new Doctor { Name = "Dr. Smith", Specialty = "Cardiology" };
            var doctor2 = new Doctor { Name = "Dr. Johnson", Specialty = "Pediatrics" };

            // Create some sample appointments
            var appointment1 = new Appointment
            {
                Patient = patient1,
                Doctor = doctor1,
                Date = new DateTime(2024, 4, 30, 10, 0, 0),
                Specialty = doctor1.Specialty
            };

            var appointment2 = new Appointment
            {
                Patient = patient2,
                Doctor = doctor2,
                Date = new DateTime(2024, 5, 5, 14, 30, 0),
                Specialty = doctor2.Specialty
            };


            context.Patients.AddOrUpdate(p => p.Id, patient1, patient2);
            context.Doctors.AddOrUpdate(d => d.Id, doctor1, doctor2);
            context.Appointments.AddOrUpdate(a => a.Date, appointment1, appointment2);

            context.SaveChanges();
        }
    }
}
