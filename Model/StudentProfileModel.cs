using DataAccessLayer;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class StudentProfileModel
    {
        StudentDAL studentDAL = new StudentDAL();
        public bool AddStudentRecord(Student student)
        {
            return studentDAL.AddStudentRecord(student);
        }
        public bool UpdateStudentRecord(Student student)
        {
            return studentDAL.UpdateStudentRecord(student);
        }
        public bool DeleteStudentRecord(int studentId)
        {
            return studentDAL.DeleteStudentRecord(studentId);
        }
        public Student GetStudentById(int studentId)
        {
            return studentDAL.GetStudentById(studentId);
        }
        public List<StudentProfileDTO> GetAllStudents()
        {
            return studentDAL.GetAllStudents();
        }
        public List<Country> GetCountries()
        {
            return studentDAL.GetCountries();
        }
        public List<Gender> GetGenders()
        {
            return studentDAL.GetGenders();
        }
    }
}
