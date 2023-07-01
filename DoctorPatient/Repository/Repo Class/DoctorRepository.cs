using DoctorPatient.Context;
using DoctorPatient.Models;
using DoctorPatient.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace DoctorPatient.Repository.Repo_Class
{
   
        public class DoctorRepositary : IDoctorRepository
        {
            public readonly DoctorContext _context;

            public DoctorRepositary(DoctorContext context)
            {
                _context = context;
            }

            public async Task<IEnumerable<Doctor>> GetDoctors()
            {
                return await _context.Doctors.Include(x => x.Patients).Include(y => y.Appointments).ToListAsync();
            }

            public async Task<Doctor> GetDoctor(int id)
            {
                return await _context.Doctors.FindAsync(id);
            }

            public async Task AddDoctor(Doctor doctor)
            {
                _context.Doctors.Add(doctor);
                await _context.SaveChangesAsync();
            }

            public async Task UpdateDoctor(Doctor doctor)
            {
                _context.Entry(doctor).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }

            public async Task DeleteDoctor(int id)
            {
                var doctor = await _context.Doctors.FindAsync(id);
                if (doctor != null)
                {
                    _context.Doctors.Remove(doctor);
                    await _context.SaveChangesAsync();
                }
            }

            public async Task<bool> DoctorExists(int id)
            {
                return await _context.Doctors.AnyAsync(e => e.Doctor_Id == id);
            }
        }
    }



