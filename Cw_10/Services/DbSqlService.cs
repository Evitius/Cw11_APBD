using Cw_10.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cw_10.Services
{
    public class DbSqlService : Controller,IDbSqlService
    {
        private readonly CodeFirstContext _cfc;
        public DbSqlService(CodeFirstContext context)
        {
            _cfc = context;
        }

        public IActionResult AddDoctor(Doctor doctor)
        {
            var d = new Doctor
            {
                IdDoctor = doctor.IdDoctor,
                FirstName = doctor.FirstName,
                LastName = doctor.LastName,
                Email = doctor.Email,
                Prescriptions = new List<Prescription>()
            };
            _cfc.Doctors.Add(d);
            _cfc.SaveChanges();
            return Ok("Added doctor " + d);
        }

        public IActionResult DeleteDoctor(int id)
        {
            var doc = _cfc.Doctors.FirstOrDefault(doc => doc.IdDoctor == id);
           
            if (doc == null)
            {
                return Ok("Doctor does not exist");
            }

            _cfc.Doctors.Remove(doc);
            _cfc.SaveChanges();
            return Ok("Doctor removed");
        }

        public IEnumerable<Doctor> GetDoctors()
        {
            return _cfc.Doctors.ToList(); ;
        }

        public IActionResult ModifyDoctor(Doctor doctor)
        {
            var doc = _cfc.Doctors.FirstOrDefault(doc => doc.IdDoctor == doctor.IdDoctor);

            if (doc == null)
            {
                return Ok("Doctor does not exist");
            }

            _cfc.Doctors.Remove(doc);
            _cfc.Doctors.Add(doctor);              
            _cfc.SaveChanges();
           
            return Ok("Doctor modified");
        }

        public IActionResult Seed()
        {
            var d1 = new Doctor
            {
                IdDoctor = 1,
                FirstName = "Piotr",
                LastName = "Juszkiewicz",
                Email = "piojusz@wp.pl"
            };

            _cfc.Doctors.Add(d1);

            var d2 = new Doctor
            {
                IdDoctor = 2,
                FirstName = "Jan",
                LastName = "Kocisz",
                Email = "kocisz@wp.pl"
            };
          
            _cfc.Doctors.Add(d2);

            var p1 = new Patient
            {
                IdPatient = 1,
                FirstName = "Tomasz",
                LastName = "Lusztyk",
                BirthDate = DateTime.Now
            };
            
            _cfc.Patients.Add(p1);

            var p2 = new Patient
            {
                IdPatient = 2,
                FirstName = "Grzegorz",
                LastName = "Matczak",
                BirthDate = DateTime.Now
            };

            _cfc.Patients.Add(p2);

            var pr1 = new Prescription
            {
                IdPrescription = 1,
                Date = DateTime.Now,
                DueDate = DateTime.Now,
                IdPatient = 1,
                IdDoctor = 1
            };

            _cfc.Prescriptions.Add(pr1);

            var pr2 = new Prescription
            {
                IdPrescription = 2,
                Date = DateTime.Now,
                DueDate = DateTime.Now,
                IdPatient = 2,
                IdDoctor = 2
            };

            _cfc.Prescriptions.Add(pr2);

            var m1 = new Medicament
            {
                IdMedicament = 1,
                Name = "medicament1",
                Description = "description1",
                Type = "type1"
            };

            _cfc.Medicaments.Add(m1);

            var m2 = new Medicament
            {
                IdMedicament = 2,
                Name = "medicament2",
                Description = "description2",
                Type = "type2"
            };

            _cfc.Medicaments.Add(m2);

            var pm1 = new Prescription_Medicament
            {
                IdMedicament = 1,
                IdPrescription = 1,
                Dose = 1,
                Details = "details1"
            };

            _cfc.Prescription_Medicaments.Add(pm1);

            var pm2 = new Prescription_Medicament
            {
                IdMedicament = 2,
                IdPrescription = 2,
                Dose = 2,
                Details = "details2"
            };

            _cfc.Prescription_Medicaments.Add(pm2);

            return Ok("Seed done");
        }
    }
}
