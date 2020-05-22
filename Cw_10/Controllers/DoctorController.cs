using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cw_10.Models;
using Cw_10.Services;
using Microsoft.AspNetCore.Mvc;

namespace Cw_10.Controllers
{
    [Route("api/doctors")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDbSqlService _context;
        public DoctorController(IDbSqlService context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetDoctors()
        {
            return Ok(_context.GetDoctors());
        }

        [HttpPost]
        public IActionResult AddDoctor(Doctor doctor)
        {
            return Ok(_context.AddDoctor(doctor));
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDoctor(int id)
        {
            return Ok(_context.DeleteDoctor(id));
        }
       
        [HttpPut]
        public IActionResult ModifyDoctor(Doctor doc) 
        {
            return Ok(_context.ModifyDoctor(doc));
        }

        [HttpPost("/seed")]
        public IActionResult Seed()
        {
            return Ok(_context.Seed());
        }
    }
}