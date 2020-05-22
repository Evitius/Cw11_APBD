using Cw_10.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cw_10.Services
{
    public interface IDbSqlService
    {
        public IEnumerable<Doctor> GetDoctors();
        public IActionResult AddDoctor(Doctor doctor);
        public IActionResult ModifyDoctor(Doctor doctor);
        public IActionResult DeleteDoctor(int id);
        public IActionResult Seed();
    }
}
