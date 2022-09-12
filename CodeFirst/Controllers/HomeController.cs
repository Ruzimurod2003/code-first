using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeFirst.Data;
using CodeFirst.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CodeFirst.Controllers
{
    [Route("api/[controller]")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private MY_DB db;
        public HomeController(MY_DB db)
        {
            this.db = db;
        }
        // GET: api/<HomeController>
        [HttpGet]
        public List<Student> Get()
        {
            return db.Students.ToList();
        }

        // GET api/<HomeController>/5
        [HttpGet("{id}")]
        public Student Get(Guid id)
        {
            return db.Students.Find(id);
        }

        // POST api/<HomeController>
        [HttpPost]
        public void Add([FromBody] Student student)
        {
            db.Students.Add(student);
            db.SaveChanges();
        }

        // PUT api/<HomeController>/5
        [HttpPut("{id}")]
        public void Update([FromBody] Student student)
        {
            db.Students.Update(student);
            db.SaveChanges();
        }

        // DELETE api/<HomeController>/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            var student = db.Students.Find(id);
            db.Students.Remove(student);
            db.SaveChanges();
        }
    }
}
