using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class StudentDAL
    {
        public bool AddStudentRecord(Student student)
        {
            try
            {
                //Here you write database query.Let suppose insert successfully and return true
                return true;
            }
            catch (Exception exception)
            {
                //In case of database error then log the error
                Log.Error(exception);
                return false;
            }
            
        }
        public bool UpdateStudentRecord(Student student)
        {
            try
            {
                //Here you write database query.Let suppose update successfully and return true
                return true;
            }
            catch (Exception exception)
            {
                //In case of database error then log the error
                Log.Error(exception);
                return false;
            }
        }
        public bool DeleteStudentRecord(int studentId)
        {
            try
            {
                //Here you write database query.Let suppose studentId is greater than zero and delete successfully and return true
                if (studentId > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception exception)
            {
                //In case of database error then log the error
                Log.Error(exception);
                return false;
            }
        }
        public Student GetStudentById(int studentId)
        {
            //Here you write database query.Let suppose studentId is 1 
            var student = new Student();

            student.Id = studentId;
            student.FirstName = "Alex";
            student.LastName = "Johan";
            student.CountryId = 1;
            student.GenderId = 2;

            return student;
        }
        public List<StudentProfileDTO> GetAllStudents()
        {
            //Here you write database query.Let suppose current only one record in database
            List<StudentProfileDTO> students = new List<StudentProfileDTO>();
            StudentProfileDTO student1 = new StudentProfileDTO();

            student1.Id = 1;
            student1.FirstName = "Alex";
            student1.LastName = "Johan";
            student1.CountryName = "Germany";
            student1.GenderName = "Female";

            students.Add(student1);

            return students;
        }
        public List<Country> GetCountries()
        {
            //database query.Let suppose current only three records in database
            List<Country> countries = new List<Country>();
            var country1 = new Country { Id = 1, Name = "Germany" };
            countries.Add(country1);

            var country2 = new Country { Id = 2, Name = "Netherland" };
            countries.Add(country2);

            var country3 = new Country { Id = 3, Name = "France" };
            countries.Add(country3);

            return countries;
        }
        public List<Gender> GetGenders()
        {
            //Here you write database query
            List<Gender> genders = new List<Gender>();

            var gender1 = new Gender { Id = 1,Name = "Male"};
            genders.Add(gender1);

            var gender2 = new Gender { Id = 2, Name = "Female" };
            genders.Add(gender2);

            return genders;
        }
    }
}
