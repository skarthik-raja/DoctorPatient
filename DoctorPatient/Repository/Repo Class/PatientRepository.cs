using DoctorPatient.Context;
using DoctorPatient.Models;
using DoctorPatient.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace DoctorPatient.Repository.Repo_Class
{
   
        public class PatientRepositary : IPatientRepository
        {
            private readonly DoctorContext _context;

            public PatientRepositary(DoctorContext context)
            {
                _context = context;
            }

            public async Task<IEnumerable<Patient>> GetPatients()
            {
                return await _context.Patients.Include(x => x.Doctor).ToListAsync();
            }

            public async Task<Patient> GetPatient(int id)
            {
                return await _context.Patients.FindAsync(id);
            }

            public async Task AddPatient(Patient patient)
            {

                var r = _context.Doctors.Find(patient.Doctor.Doctor_Id);
                patient.Doctor = r;
                _context.Patients.Add(patient);
                await _context.SaveChangesAsync();
            }

            public async Task UpdatePatient(Patient patient)
            {
                _context.Entry(patient).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }

            public async Task DeletePatient(Patient patient)
            {
                _context.Patients.Remove(patient);
                await _context.SaveChangesAsync();
            }

            public async Task<bool> PatientExists(int id)
            {
                return await _context.Patients.AnyAsync(e => e.Patient_Id == id);
            }
        }
    }

