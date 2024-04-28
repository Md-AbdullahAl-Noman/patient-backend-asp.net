using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
      public class Appointment
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Patient is required")]
        [ForeignKey("Patient")]
        public int PatientId { get; set; }

        [Required(ErrorMessage = "Doctor is required")]
        [ForeignKey("Doctor")]
        public int DoctorId { get; set; }

        public string Specialty { get; set; }

        [Required(ErrorMessage = "Date is required")]
        public DateTime Date { get; set; }

        

     
        public Patient Patient { get; set; }
        public Doctor Doctor { get; set; }

    }
}
