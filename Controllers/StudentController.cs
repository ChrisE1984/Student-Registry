
using Student_Registry.Models;
using Microsoft.AspNetCore.Mvc;

namespace Student_Registry.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        static List<StudentRegistry> Students = [
            new StudentRegistry {Id = 1, Name = "Paul Scheer", Year = 12, Grade = 4.0, IsPresent = true},
            new StudentRegistry {Id = 2, Name = "Jason Mantzoukas", Year = 11, Grade = 2.5, IsPresent = false},
            new StudentRegistry {Id = 3, Name = "June Diane Raphael", Year = 12, Grade = 3.7, IsPresent = true}
        ];

        private static int _nextID = 4;

        [HttpGet("StudentsAll")]
        public ActionResult<List<StudentRegistry>> GetAll()
        {
            //return 200 Ok with whole list
            return Ok(Students);
        }

        [HttpGet("GetStudent/{id}")]
        public ActionResult<StudentRegistry> GetByID (int id)
        {
            StudentRegistry? student = Students.FirstOrDefault(c => c.Id == id);

            if (student == null)
            {
                return NotFound($"No student found with id {id}.");
            }

            return Ok(student);
        }

        [HttpPost("Add")]
        public ActionResult<StudentRegistry> Create ([FromBody] StudentRegistry incoming)
        {
            incoming.Id = _nextID;
            _nextID ++;

            Students.Add(incoming);

            return CreatedAtAction(
                actionName: nameof(GetByID),
                routeValues: new {id = incoming.Id},
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

                student.Name = incoming.Name;
                student.Year = incoming.Year;
                student.Grade = incoming.Grade;
                student.IsPresent = incoming.IsPresent;

                return Ok(true);
            } 
        

        [HttpDelete("Delete/{id}")]
        public ActionResult<bool> Delete (int id)
        {
            StudentRegistry? student =Students.FirstOrDefault(c => c.Id == id);

            if (student == null){

                return NotFound ($"No crew member with id {id}");
                
            }

            Students.Remove(student);

            return Ok(true);
        }

    }


}