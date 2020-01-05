using System.Linq;
using Microsoft.AspNetCore.Mvc;
using StudentApi.Models;

namespace StudentApi.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class StudentController : ControllerBase
  {
    [HttpGet]
    public ActionResult GetAllStudents()
    {
      var db = new DatabaseContext();
      return Ok(db.Students.OrderBy(student => student.FullName));
    }
    [HttpGet("{id}")]
    public ActionResult GetOneStudent(int id)
    {
      var db = new DatabaseContext();
      var student = db.Students.FirstOrDefault(st => st.Id == id);
      if (student == null)
      {
        return NotFound();
      }
      else
      {
        return Ok(student);
      }
    }

    [HttpPost]
    public ActionResult CreateStudent(Student student)
    {
      // look for (inside of json) all of the properties of Student (name, gpa, etc)
      var db = new DatabaseContext();
      db.Students.Add(student);
      db.SaveChanges();
      return Ok(student);
    }

    [HttpPut("{id}")]
    public ActionResult UpdateStudent(Student student)
    {
      var db = new DatabaseContext();
      var prevStudent = db.Students.FirstOrDefault(st => st.Id == student.Id);
      if (prevStudent == null)
      {
        return NotFound();
      }
      else
      {
        prevStudent.FullName = student.FullName;
        prevStudent.GPA = student.GPA;
        prevStudent.IsJoyful = student.IsJoyful;
        db.SaveChanges();
        return Ok(prevStudent);
      }
    }
    [HttpDelete]
    public ActionResult DeleteStudent(int id)
    {
      var db = new DatabaseContext();
      var student = db.Students.FirstOrDefault(st => st.Id == id);
      if (student == null)
      {
        return NotFound();
      }
      else
      {
        db.Students.Remove(student);
        db.SaveChanges();
        return Ok();
      }
    }
  }
}