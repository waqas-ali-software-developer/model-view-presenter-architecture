using Entity;
using System.Collections.Generic;

namespace View
{
    public interface IStudentProfileView
    {
        string TxtFirstName { get; set; }
        string TxtLastName { get; set; }
        string DdlCountry { get; set; }
        int DdlCountrySelectedIndex { set; }
        void SetDdlCountry(List<Country> countries);
        string DdlGender { get; set; }
        string LblMessage {  set; }
        int DdlGenderSelectedIndex { set; }
        void SetDdlGender(List<Gender> genders);
        void SetStudentsListGrid(List<StudentProfileDTO> students);
        string HdnStudentId { get; set; }
        string BtnSaveStudentProfile { set; }
        void StatusMessage(string message);
    }
}
