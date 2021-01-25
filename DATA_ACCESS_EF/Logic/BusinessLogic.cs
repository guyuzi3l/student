using DATA_ACCESS_EF.DTO;
using DATA_ACCESS_EF.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATA_ACCESS_EF.DataAccessLayer
{
    public class BusinessLogic
    {
        static guyEntities dal = new guyEntities();
        static StudentModel student = new StudentModel();
        //dynamic - Unwanted because it is heavy, and does not give complication errors
        ////Pulling a student table from the DB
        public static List<StudentModel> GetStudentsByLogic()
        {
            return dal.Students.Select(stu => new StudentModel
            {
                Student_Name = stu.StudentName,
                Student_Id = stu.StudentId
            }).ToList();
        }
        //Alter student name in  the DB
        public static void UpdateStudentByLogic(string name, int id)

        {
            Student student = dal.Students.SingleOrDefault(s => s.StudentId == id);
            if (student != null && !string.IsNullOrEmpty(name.ToString()))
            {
                student.StudentName = name.ToString();
                dal.SaveChanges();
            }
            
        }
        //Insert student details in the DB
        public static void PostStudentByLogic(StudentModel student)

        {
            
            Student stud = dal.Students.SingleOrDefault(s => s.StudentId == student.Student_Id);
            if (stud == null)
            {
                var details = new Student
                {
                    StudentName = student.Student_Name,
                    StudentId = student.Student_Id,
                    AvgGrade = student.Avg_Grade,
                    IsActive = student.Is_Active

                };
                try
                {
                    dal.Students.Add(details);
                    dal.SaveChanges();
                   
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException.InnerException.Message);
                }
                
            }
           

        }
    }
}

