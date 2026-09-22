
using Student_Registry.Models;
using Microsoft.AspNetCore.Mvc;

namespace Student_Registry.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        static List<StudentRegistry> Students = [
            new StudentRegistry {Id = 1, Firstname = "Callen", Lastname = "Thomason", Hobby = "Gettin' Swole", Email = "cthomason@codestack.co", Slackname = "Callen Tomason"},
            new StudentRegistry {Id = 2, Firstname = "Valery", Lastname = "Lot", Hobby = "Trying new restaurants", Email = "vlot@codestack.co", Slackname = "Valery Lot"},
            new StudentRegistry {Id = 3, Firstname = "Zionn", Lastname = "Showers", Hobby = "Gaming", Email = "zshowers@codestack.co", Slackname = "Zionn Showers"},
            new StudentRegistry {Id = 4, Firstname = "Chris", Lastname = "Estrada", Hobby = "Magic: The Gathering", Email = "cestrada@codestack.co", Slackname = "Chris Estrada"},
            new StudentRegistry {Id = 5, Firstname = "Brandon", Lastname = "Langehennig", Hobby = "Art", Email = "blangehennig@codestack.co", Slackname = "Brandon Langehennig"},
            new StudentRegistry {Id = 6, Firstname = "Zackary", Lastname = "Santos", Hobby = "Gaming", Email = "zsantoss@codestack.co", Slackname = "Zackary"}
        ];


        private static int _nextID = 4;

        [HttpGet("StudentsAll")]
        public ActionResult<List<StudentRegistry>> GetAll()
        {
            //return 200 Ok with whole list
            return Ok(Students);
        }

        [HttpGet("GetStudent/{id}")]
        public ActionResult<StudentRegistry> GetByID(int id)
        {
            StudentRegistry? student = Students.FirstOrDefault(c => c.Id == id);

            if (student == null)
            {
                return NotFound($"No student found with id {id}.");
            }

            return Ok(student);
        }

        [HttpGet("GetStudentEmail/{email}")]
        public ActionResult<StudentRegistry> GetByEmail(string email)
        {

            StudentRegistry? student = Students.FirstOrDefault(c => c.Email == email);

            if (student == null)
            {
                return NotFound($"No student found with email {email}.");
            }

            return Ok(student);
        }

        [HttpPost("Add")]
        public ActionResult<StudentRegistry> Create([FromBody] StudentRegistry incoming)
        {
            incoming.Id = _nextID;
            _nextID++;

            Students.Add(incoming);

            return CreatedAtAction(
                actionName: nameof(GetByID),
                routeValues: new { id = incoming.Id },
                value: incoming
            );
        }

        [HttpPut("Update/{id}")]
        public ActionResult<bool> Update(int id, [FromBody] StudentRegistry incoming)
        {
            StudentRegistry? student = Students.FirstOrDefault(c => c.Id == id);

            if (student == null)
            {
                return NotFound($"No student exists with id {id}.");
            }

            student.Firstname = incoming.Firstname;
            student.Lastname = incoming.Lastname;
            student.Hobby = incoming.Hobby;
            student.Email = incoming.Email;
            student.Slackname = incoming.Slackname;

            return Ok(true);
        }


        [HttpDelete("Delete/{id}")]
        public ActionResult<bool> Delete(int id)
        {
            StudentRegistry? student = Students.FirstOrDefault(c => c.Id == id);

            if (student == null)
            {

                return NotFound($"No crew member with id {id}");

            }

            Students.Remove(student);

            return Ok(true);
        }

    }


}