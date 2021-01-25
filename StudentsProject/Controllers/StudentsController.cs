using DATA_ACCESS_EF.DataAccessLayer;
using DATA_ACCESS_EF.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace StudentsProject.Controllers
{
    public class StudentsController : ApiController
    {
        // GET api/values
        [HttpGet]
        public List<StudentModel> GetStudents()
        {
            try
            {
                return BusinessLogic.GetStudentsByLogic();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        

        // POST api/values
        [HttpPost]
        public void CreateStudent(StudentModel student)
        {
            string res = string.Empty;
            BusinessLogic.PostStudentByLogic(student);
            
        }
        
        // PUT api/values/5
        [HttpPut]
        [Route("api/students/{id}")]
        public void Update([FromBody] string name, int id)
        {
            try
            {
                BusinessLogic.UpdateStudentByLogic(name, id);
            }
            catch(Exception ex)
            {

            }

        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
