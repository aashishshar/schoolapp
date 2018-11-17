using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEB_APP_SCHOOL_NET.BAL;
using WEB_APP_SCHOOL_NET.Common;

namespace WEB_APP_SCHOOL_NET.UC
{
    public class ReceiptData
    {
        public string ReceiptNumber { get; set; }
        public string SubmitDate { get; set; }
    }

    public class ReceiptDataSubmitted
    {
        public string FeeName { get; set; }
        public string TotalFee { get; set; }
        public string ReceiptNumber { get; set; }
    }

    public partial class uc_FeeReceipt : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        public uc_FeeReceipt()
        {
            _OrganizationDTO = new cls_OrganizationDTO();
            _StudentDTO = new cls_StudentDTO();
        }

        cls_OrganizationDTO _OrganizationDTO;
        cls_StudentDTO _StudentDTO;
        public static List<ReceiptData> lsDuplicate = new List<ReceiptData>();
        public static List<ReceiptDataSubmitted> lsReceipts = new List<ReceiptDataSubmitted>();
        public string SchoolName = string.Empty;
        public string SchoolAddress = string.Empty;
        public string StudentName = string.Empty;
        public string FathersName = string.Empty;
        public string FormNumber = string.Empty;
        public string SchoolImage = string.Empty;

        public void BindItems(List<dynamic> data, int StudentId)
        {
            int Org_Id = cls_Common.UserProfile.ORG_ID;
            SchoolName = _OrganizationDTO.GetORGANIZATION(Org_Id).Name;
            SchoolAddress = _OrganizationDTO.GetORGANIZATION(Org_Id).Address;
            SchoolImage = _OrganizationDTO.GetORGANIZATION(Org_Id).ImagePath;
            var Student = _StudentDTO.GetDataForEdit(StudentId);
            if (Student != null)
            {
                StudentName = Student.StudentName;
                FathersName = Student.FatherName;
                FormNumber = Student.FormNumber.ToString();

                lsDuplicate = (from t in data
                               group t by new { t.ReceiptNumber, t.SubmitDate } into g
                               select new ReceiptData { ReceiptNumber = g.Key.ReceiptNumber, SubmitDate = g.Key.SubmitDate.ToString("MMM dd, yyy") }).ToList();
                lsReceipts = (from t in data
                              select new ReceiptDataSubmitted { FeeName = t.FeeName + FeeTermName(t.FeeTerm, t.FeeDuration), TotalFee = t.TotalFee.ToString(), ReceiptNumber = t.ReceiptNumber }).ToList();
                var totalamt = lsReceipts.Sum(s => Convert.ToDecimal(s.TotalFee));
                //litTotalFee.Text = totalamt.ToString();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowModal", "$('#myModal').modal();", true);
            }
        }

        public string FeeTermName(byte FeeTerm, byte FeeDuration)
        {
            string description;
            if (FeeDuration == 1)
                description = " (One-Time)";
            else if (FeeDuration == 5)
                description = " (Annually)";
            else if (FeeDuration == 2)
            {
                description = " (" + ((EnumConstants.MonthName)FeeTerm).ToString() + ")";
            }
            else if (FeeDuration == 3)
            {
                description = " (" + ((EnumConstants.Quaterly)FeeTerm).ToName() + ")";
            }
            else
            {
                description = " (" + ((EnumConstants.HalfYearly)FeeTerm).ToName() + ")";
            }
            return description;
        }
    }
}