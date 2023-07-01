using DoctorPatient.Models;
using Microsoft.EntityFrameworkCore;

namespace DoctorPatient.Context
{
    public class DoctorContext : DbContext
    {

        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<DoctorPatient.Models.Admin>? Admin { get; set; }

        public DoctorContext(DbContextOptions<DoctorContext> options) : base(options)
        {

        }
    }
}
