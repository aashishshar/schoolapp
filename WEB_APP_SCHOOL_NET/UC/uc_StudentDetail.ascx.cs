using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEB_APP_SCHOOL_NET.BAL;
using WEB_APP_SCHOOL_NET.Common;
using WEB_APP_SCHOOL_NET.DAL;
namespace WEB_APP_SCHOOL_NET.UC
{
    public partial class uc_StudentDetail : System.Web.UI.UserControl
    {
        cls_StudentDTO studentDTO = new cls_StudentDTO();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        private void GetStudentDetails(int studentId)
        {
            var student = studentDTO.GetDataForEdit(studentId);
            litAadharNo.Text = student.AadharNumber;
            litContactNo.Text = student.ContactNumber;
            litCorrespondenceAdd.Text = student.CorrespondenceAddress;
            litEmailId.Text = student.Email;
            litFatherName.Text = student.FatherName;
            litMobNo.Text = student.ContactNumber;
            litMotherName.Text = student.MotherName;
            litNationality.Text = student.Nationality;
            if (student.Occupation.HasValue)
                litOccupation.Text = student.MST_OCCUPATION.OccupationName;// Convert.ToString(student.Occupation);
                                                                           // if (student.CityId.HasValue)
            litCityName.Text = student.CityId.HasValue ? student.MST_CITY.CityName : "NA";
            // if (student.ReligionId.HasValue)
            litReligionName.Text = student.ReligionId.HasValue ? student.MST_RELIGION.ReligionName : "NA";
            litWhatsap.Text = student.WhatsAppNo;
            litVillage.Text = student.Village_Town;
            litStudentName.Text = student.StudentName;
            litRefer.Text = student.ReferredBy + " " + (student.ReferredMobileNumber);
            litSchoolName.Text = student.LastSchoolName;
            litCastName.Text = student.CasteId.HasValue ? student.MST_CASTE.CasteName : "NA";
            litPinCode.Text = student.ZipCode;
            litRollNo.Text = student.RollNumber;
            //litSectionName.Text = student.SectionId.HasValue ? student.MST_SECTION.SectionName : "NA";
            litSerialNumber.Text = student.SerialNumber;
            if (student.StateId.HasValue)
                litStateName.Text = student.MST_STATE.StateName;
            //if (student.c.HasValue)
            litClassName.Text = student.ClassId.HasValue ? student.MST_SECTION.MST_CLASS.ClassName +"(" +(student.SectionId.HasValue ? student.MST_SECTION.SectionName : "NA")+")" : "NA";
            litGender.Text = Convert.ToString(student.Gender);
            litDoB.Text = student.DOB.Value.ToString("dd/MM/yyyy"); ;//.Date.ToShortDateString();
            //litSubject.Text = student.TRN_STUDENT_SUBJECT;

            litCasteType.Text = student.CasteType.HasValue ? ((EnumConstants.Caste)student.CasteType).ToString() : "NA";
            if (student.ImageUrl != null)
            {
                imgUserImage.ImageUrl = student.ImageUrl;
            }
        }
        private int _studentId;
        public int StudentId
        {
            get
            {

                return _studentId;
            }
            set
            {
                GetStudentDetails(value); 
            }
        }

       
    }
}