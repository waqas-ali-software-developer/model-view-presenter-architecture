using Entity;
using Model;
using Presenter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using View;

namespace College.SIS.Web
{
    public partial class StudentProfile : System.Web.UI.Page, IStudentProfileView
    {
        StudentProfilePresenter _studentProfilePresenter;
        protected void Page_Load(object sender, EventArgs e)
        {
            StudentProfileModel _studentProfileModel = new StudentProfileModel();
            _studentProfilePresenter = new StudentProfilePresenter(this, _studentProfileModel);

            if (!IsPostBack)
            {
                _studentProfilePresenter.BindCountries();
                _studentProfilePresenter.BindGenders();
                _studentProfilePresenter.BindStudentListGrid();
            }
        }

        public string TxtFirstName
        {
            get
            {
                return txtFirstName.Text;
            }
            set
            {
                txtFirstName.Text = value;
            }
        }

        public string TxtLastName
        {
            get
            {
                return txtLastName.Text;
            }
            set
            {
                txtLastName.Text = value;
            }
        }

        public string DdlCountry
        {
            get
            {
                return ddlCountry.SelectedValue;
            }
            set
            {
                ddlCountry.SelectedValue = value;
            }
        }

        public int DdlCountrySelectedIndex
        {
            set { ddlCountry.SelectedIndex = value; }
        }

        public void SetDdlCountry(List<Country> countries)
        {
            ddlCountry.DataSource = countries;
            ddlCountry.DataTextField = "Name";
            ddlCountry.DataValueField = "Id";
            ddlCountry.DataBind();
            if (countries.Count > 0)
            {
                ddlCountry.Items.Insert(0, new ListItem("Select", "-1"));
            }
        }

        public string DdlGender
        {
            get
            {
                return ddlGender.SelectedValue;
            }
            set
            {
                ddlGender.SelectedValue = value;
            }
        }

        public int DdlGenderSelectedIndex
        {
            set { ddlGender.SelectedIndex = value; }
        }

        public void SetDdlGender(List<Gender> genders)
        {
            ddlGender.DataSource = genders;
            ddlGender.DataTextField = "Name";
            ddlGender.DataValueField = "Id";
            ddlGender.DataBind();
            if (genders.Count > 0)
            {
                ddlGender.Items.Insert(0, new ListItem("Select", "-1"));
            }
        }

        public void SetStudentsListGrid(List<StudentProfileDTO> students)
        {
            gvStudentsList.DataSource = students;
            gvStudentsList.DataBind();
        }

        public string HdnStudentId
        {
            get
            {
                return hdnStudentId.Value;
            }
            set
            {
                hdnStudentId.Value = value;
            }
        }

        public string BtnSaveStudentProfile
        {
            set { btnSaveStudentProfile.Text = value; }
        }

        public void StatusMessage(string message)
        {
            //Here you will write your own logic to display message
            lblMessage.Text = message;
        }

        protected void btnSaveStudentProfile_Click(object sender, EventArgs e)
        {
            _studentProfilePresenter.SaveStudnetProfile();
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            _studentProfilePresenter.ClearFields();
        }

        protected void lbtnDelete_Click(object sender, EventArgs e)
        {
            GridViewRow currentRow = (GridViewRow)((LinkButton)sender).Parent.Parent;
            HiddenField hdnstudentId = (HiddenField)currentRow.FindControl("hdnStudent_Id") as HiddenField;

            _studentProfilePresenter.DeleteStudentRecord(Convert.ToInt32(hdnstudentId.Value));
        }

        protected void lbtnEdit_Click(object sender, EventArgs e)
        {
            GridViewRow currentRow = (GridViewRow)((LinkButton)sender).Parent.Parent;
            HiddenField hdnstudentId = (HiddenField)currentRow.FindControl("hdnStudent_Id") as HiddenField;

            _studentProfilePresenter.SetStudentProfileFormFields(Convert.ToInt32(hdnstudentId.Value));
        }

        public string LblMessage
        {
            set
            {
                lblMessage.Text = value;
            }
        }
    }
}