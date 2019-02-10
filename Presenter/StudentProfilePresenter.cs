using DataAccessLayer;
using Entity;
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using View;

namespace Presenter
{
    public class StudentProfilePresenter
    {
        StudentProfileModel _studentProfileModel;
        IStudentProfileView _studentProfileView;
        public StudentProfilePresenter(IStudentProfileView studentProfileView,
            StudentProfileModel studentProfileModel)
        {
            _studentProfileView = studentProfileView;
            _studentProfileModel = studentProfileModel;
        }

        public Student SetStudent(int studentId)
        {
            Student student = new Student();
            try
            {
                student.Id = studentId;
                student.FirstName = _studentProfileView.TxtFirstName;
                student.LastName = _studentProfileView.TxtLastName;
                student.CountryId = _studentProfileView.DdlCountry == "" ? 0 : Convert.ToInt32(_studentProfileView.DdlCountry);
                student.GenderId = _studentProfileView.DdlGender == "" ? 0 : Convert.ToInt32(_studentProfileView.DdlGender);
                return student;
            }
            catch (InvalidCastException invalidCastException)
            {
                student = null;
                _studentProfileView.StatusMessage("Not Save");
                Log.Error(invalidCastException);
            }
            catch (Exception exception)
            {
                student = null;
                _studentProfileView.StatusMessage("Not Save");
                Log.Error(exception);
            }
            return student;
        }

        public void SaveStudnetProfile()
        {
            try
            {
                if (Convert.ToInt32(_studentProfileView.HdnStudentId) > 0)
                    UpdateStudentRecord(Convert.ToInt32(_studentProfileView.HdnStudentId));
                else
                    AddStudentRecord();
            }
            catch (InvalidCastException invalidCastException)
            {
                _studentProfileView.StatusMessage("Not Save");
                Log.Error(invalidCastException);
            }
            catch (NullReferenceException nullReferenceException)
            {
                _studentProfileView.StatusMessage("Not Save");
                Log.Error(nullReferenceException);
            }
            catch (Exception exception)
            {
                _studentProfileView.StatusMessage("Not Save");
                Log.Error(exception);
            }
        }
        public void AddStudentRecord()
        {
            Student student = SetStudent(0);
            var context = new ValidationContext(student, null, null);
            var result = new List<ValidationResult>();
            bool IsValid = Validator.TryValidateObject(student, context, result, true);

            if (IsValid)
            {
                bool isSave = _studentProfileModel.AddStudentRecord(student);

                if (isSave)
                {
                    ClearFields();
                    _studentProfileView.StatusMessage("Save Successfully");
                    BindStudentListGrid();
                }
                else
                {
                    _studentProfileView.StatusMessage("Not Save");
                }
            }
            else
            {
                StringBuilder sb = new StringBuilder();

                foreach (var error in result)
                {
                    sb.Append("<br/>" + error);
                }
                _studentProfileView.StatusMessage(sb.ToString());
            }
        }
        public void UpdateStudentRecord(int studentId)
        {
            Student student = SetStudent(studentId);
            var context = new ValidationContext(student, null, null);
            var result = new List<ValidationResult>();
            bool IsValid = Validator.TryValidateObject(student, context, result, true);

            if (IsValid)
            {
                bool isSave = _studentProfileModel.UpdateStudentRecord(student);

                if (isSave)
                {
                    ClearFields();
                    _studentProfileView.StatusMessage("Save Successfully");
                    BindStudentListGrid();
                }
                else
                {
                    _studentProfileView.StatusMessage("Not Save");
                }
            }
            else
            {
                StringBuilder sb = new StringBuilder();

                foreach (var error in result)
                {
                    sb.Append("<br/>" + error);
                }
                _studentProfileView.StatusMessage(sb.ToString());
            }
        }
        public void ClearFields()
        {
            _studentProfileView.TxtFirstName = "";
            _studentProfileView.TxtLastName = "";
            _studentProfileView.DdlCountrySelectedIndex = 0;
            _studentProfileView.DdlGenderSelectedIndex = 0;
            _studentProfileView.HdnStudentId = "0";
            _studentProfileView.LblMessage = "";
            _studentProfileView.BtnSaveStudentProfile  = "Add Record";
        }
        public void DeleteStudentRecord(int studentId)
        {
            bool isDelete = _studentProfileModel.DeleteStudentRecord(studentId);

            if (isDelete)
            {
                ClearFields();
                _studentProfileView.StatusMessage("Delete Successfully");
                BindStudentListGrid();
            }
            else
            {
                _studentProfileView.StatusMessage("Not Deleted");
            }
        }
        public void SetStudentProfileFormFields(int studentId)
        {
            Student student = _studentProfileModel.GetStudentById(studentId);

            _studentProfileView.TxtFirstName = student.FirstName;
            _studentProfileView.TxtLastName = student.LastName;
            _studentProfileView.DdlCountry = student.CountryId.ToString();
            _studentProfileView.DdlGender = student.GenderId.ToString();
            _studentProfileView.BtnSaveStudentProfile = "Edit Record";
        }
        public void BindStudentListGrid()
        {
            List<StudentProfileDTO> students = _studentProfileModel.GetAllStudents();
            _studentProfileView.SetStudentsListGrid(students);
        }
        public void BindCountries()
        {
            List<Country> countries = _studentProfileModel.GetCountries();
            _studentProfileView.SetDdlCountry(countries);
        }
        public void BindGenders()
        {
            List<Gender> countries = _studentProfileModel.GetGenders();
            _studentProfileView.SetDdlGender(countries);
        }
    }
}
