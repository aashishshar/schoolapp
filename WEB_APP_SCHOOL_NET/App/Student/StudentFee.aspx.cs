using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using WEB_APP_SCHOOL_NET.BAL;
using WEB_APP_SCHOOL_NET.Common;
using WEB_APP_SCHOOL_NET.DAL;

namespace WEB_APP_SCHOOL_NET.App.Student
{
    public partial class StudentFee : System.Web.UI.Page
    {
        cls_StudentDTO _StudentDTO;
        cls_FeeDTO _FeeDTO;
        cls_SectionDTO _sectionDTO;
        CommonBindControl commonBindControl;
        cls_ClassDTO _classDTO;
        public  StudentFee()
        {
            _StudentDTO = new cls_StudentDTO();
            commonBindControl = new CommonBindControl();
            _sectionDTO = new cls_SectionDTO();
            _FeeDTO = new cls_FeeDTO();
            _classDTO = new cls_ClassDTO();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindMethod();
            }
        }
        private void BindMethod()
        {
            Bind();
            BindSection();
            BindStudent();
            BindFeeDetailSection();
        }

        private void Bind()
        {
            commonBindControl.BindMasterData(ddlFinYear, EnumConstants.Masters.AcademicYear);
            commonBindControl.BindMasterData(ddlClassName, EnumConstants.Masters.Class);
            commonBindControl.BindMasterData(FeeDetailFinYear, EnumConstants.Masters.AcademicYear);
            commonBindControl.BindMasterData(FeeDetailClass, EnumConstants.Masters.Class);
        }
        protected void ddlClassName_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindSection();
        }
        protected void ddlFinYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindSection();
            BindStudent();
            BindFeeDetailSection();
        }
        private void BindStudent()
        {
            if (ddlSectionName.SelectedIndex > 0)
            {
                ddlStudentList.DataSource = _StudentDTO.GetAllStudentPromoted(Convert.ToInt32(ddlFinYear.SelectedValue.ToString()), Convert.ToInt32(ddlSectionName.SelectedValue.ToString()));
                ddlStudentList.DataValueField = "StudentId";
                ddlStudentList.DataTextField = "StudentName";
                ddlStudentList.DataBind();
                ddlStudentList.Items.Insert(0, new ListItem("[ SELECT ]", "-1"));
            }
            else
            {
                ddlStudentList.Items.Clear();
            }
        }

        private void BindFeeDetailSection()
        {
            _sectionDTO = new cls_SectionDTO();
            if (FeeDetailClass.SelectedIndex >0)
            {
                FeeDetailSection.DataSource = _sectionDTO.GetSection(Convert.ToInt32(FeeDetailClass.SelectedValue.ToString()));
                FeeDetailSection.DataTextField = "SectionName";
                FeeDetailSection.DataValueField = "SectionId";
                FeeDetailSection.DataBind();
                FeeDetailSection.Items.Insert(0, new ListItem("[ SELECT ]", "-1"));
            }
            else
            {
                FeeDetailSection.DataSource = null;
                FeeDetailSection.DataBind();
                FeeDetailSection.Items.Insert(0, new ListItem("[ SELECT ]", "-1"));
            }
        }
        private void BindSection()
        {
            if (ddlClassName.SelectedIndex > 0)
            {
                ddlSectionName.DataSource = _sectionDTO.GetSection(Convert.ToInt32(ddlClassName.SelectedValue.ToString()));
                ddlSectionName.DataTextField = "SectionName";
                ddlSectionName.DataValueField = "SectionId";
                ddlSectionName.DataBind();
                ddlSectionName.Items.Insert(0, new ListItem("[ SELECT ]", "-1"));
            }
            else
            {
                ddlSectionName.DataSource = null;
                ddlSectionName.DataBind();
                ddlSectionName.Items.Insert(0, new ListItem("[ SELECT ]", "-1"));
            }

        }

        protected void ddlSectionName_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindStudent();
        }

        protected void lkbGetFeeDetail_Click(object sender, EventArgs e)
        {
            try
            {

                SqlDataSource1.SelectParameters["CLASS_ID"].DefaultValue = ddlStudentList.SelectedIndex > 0 ? ddlClassName.SelectedValue.ToString() : "0";
                SqlDataSource1.SelectParameters["STUDENT_ID"].DefaultValue = ddlStudentList.SelectedIndex > 0 ? ddlStudentList.SelectedValue.ToString() : "0";
                SqlDataSource1.SelectParameters["FIN_ID"].DefaultValue = ddlStudentList.SelectedIndex > 0 ? ddlFinYear.SelectedValue.ToString() : "0";
                BindPaymentData();
                btnSave.Visible = true;
                lvStudentFee.DataSourceID = "SqlDataSource1";
                lvStudentFee.DataBind();


            }
            catch (Exception ex)
            {
            }
        }

        private void BindPaymentData()
        {
            txtPaymentReceiptNumber.ReadOnly = false;
            DivPaymentType.Visible = true;
            txtPaymentReceiptNumber.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss").Replace("-", "").Replace(" ", "").Replace(":", "");
            txtPaymentReceiptNumber.ReadOnly = true;
            ddlPaymentType.Items.Clear();
            Array PaymentTypes = Enum.GetValues(typeof(EnumConstants.PaymentType));
            foreach (EnumConstants.PaymentType paymentType in PaymentTypes)
            {
                ddlPaymentType.Items.Add(new ListItem(paymentType.ToString(), ((byte)paymentType).ToString()));
            }
            ddlPaymentType.Items.Insert(0, new ListItem("[ SELECT ]", "0"));
            txtTransactionNumber.Text = "";
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


        protected void btnSave_Click(object sender, EventArgs e)
        {
            bool error = false;
            uc_sucess.Visible = false;
            uc_sucess.VisibleError = false;
            if (ddlStudentList.SelectedValue == "" || ddlStudentList.SelectedValue == "0")
            {
                uc_sucess.VisibleError = true;
                uc_sucess.ErrorMessage = "Please Select Student Name!";
                return;
            }
            else if(ddlPaymentType.SelectedValue == "" || ddlPaymentType.SelectedValue == "0")
            {
                uc_sucess.ErrorMessage = "Please Select Payment Type!";
                uc_sucess.VisibleError = true;

                return;
            }
            else if(txtTransactionNumber.Visible == true && txtTransactionNumber.Text.Trim() == "")
            {
                uc_sucess.VisibleError = true;
                uc_sucess.ErrorMessage = "Please Enter Transaction/Cheque Number";
                return;
            }
            try
            {
                List<MST_STUDENTFEE_RECEIPT> StudentFeeReceipts = new List<MST_STUDENTFEE_RECEIPT>();
                decimal newFee=0, OldFee=0,NewSubmittedFee=0,NewTotalFee = 0;
                List<MST_STUDENT_FEE> StudentFeeNewList = new List<MST_STUDENT_FEE>();
                List<MST_STUDENT_FEE> StudentFeeOldList = new List<MST_STUDENT_FEE>();
                MST_STUDENTFEE_RECEIPT FeeReceipt;
                foreach (ListViewDataItem item in lvStudentFee.Items)
                {
                    MST_STUDENT_FEE StudentDtl = new MST_STUDENT_FEE();
                    string StudentFeeId = (lvStudentFee.DataKeys[item.DisplayIndex].Values["STUDENTFEEID"].ToString());
                    int FeeTermId = Convert.ToInt32(lvStudentFee.DataKeys[item.DisplayIndex].Values["FEETERMID"].ToString());
                    decimal TotalFee = Convert.ToDecimal(lvStudentFee.DataKeys[item.DisplayIndex].Values["FEEAMOUNT_NEW"].ToString());
                    NewTotalFee += TotalFee;
                    StudentDtl.FeeTermId =Convert.ToInt32(FeeTermId);
                    StudentDtl.StudentId = Convert.ToInt32(ddlStudentList.SelectedValue);
                    TextBox txtDepositFeeNew = (TextBox)item.FindControl("txtDepositFeeNew");
                    TextBox txtDepositFeeOld = (TextBox)item.FindControl("txtDepositFeeOld");
                    TextBox txtCONCESSIONFEEAMT = (TextBox)item.FindControl("txtCONCESSIONFEEAMT");
                    TextBox txtDUEFEE = (TextBox)item.FindControl("txtDUEFEE");
                    TextBox txtFeeAmountNew = (TextBox)item.FindControl("ComparetxtFeeNew");
                    TextBox txtFeeAmountOld = (TextBox)item.FindControl("ComparetxtFeeOld");
                    FeeReceipt = new MST_STUDENTFEE_RECEIPT
                    {
                        ReceiptNumber = txtPaymentReceiptNumber.Text,
                        SubmitDate = DateTime.Now,
                        SubmitType = Convert.ToByte(ddlPaymentType.SelectedValue),
                        TransactionNumber = txtTransactionNumber.Text,
                        FeeTermId = FeeTermId,
                        TotalFee = Convert.ToDecimal(txtDepositFeeNew.Text),
                        StudentId = StudentDtl.StudentId,
                        Fin_Id=Convert.ToInt32(ddlFinYear.SelectedValue)
                    };
                    if (txtDepositFeeNew.Text != "")
                    {
                        StudentDtl.FeeAmount_New = Convert.ToDecimal(txtDepositFeeNew.Text);
                        NewSubmittedFee += Convert.ToDecimal(txtDepositFeeNew.Text);
                    }
                    if (txtDepositFeeOld.Text != "")
                    {
                        StudentDtl.FeeAmount_Old = Convert.ToDecimal(txtDepositFeeOld.Text);
                    }
                    if (txtCONCESSIONFEEAMT.Text != "")
                    {
                        StudentDtl.ConcessionFeeAmt = Convert.ToDecimal(txtCONCESSIONFEEAMT.Text);
                    }
                    if (txtDUEFEE.Text != "")
                    { 
                        StudentDtl.DueFee = Convert.ToDecimal(txtDUEFEE.Text);
                    }
                    if (TotalFee == Convert.ToDecimal(txtCONCESSIONFEEAMT.Text) + Convert.ToDecimal(txtDepositFeeNew.Text))
                        StudentDtl.IsPaid = true;
                    else
                        StudentDtl.IsPaid = false;
                    StudentDtl.CreatedBy = cls_Common.UserProfile.Id;
                    StudentDtl.CreatedDate = DateTime.Now;
                    StudentDtl.Fin_ID = Convert.ToInt32(ddlFinYear.SelectedValue);
                    if (StudentFeeId == null || StudentFeeId == "")
                    {
                        StudentFeeNewList.Add(StudentDtl);
                        //var result = _FeeDTO.Save(StudentDtl);
                        //if (!result)
                        //    error = true;
                    }
                    else
                    {
                        int exitStudentFeeId = Convert.ToInt32(StudentFeeId);
                        var existStudentDtl = _FeeDTO.GetStudentFee(exitStudentFeeId);
                        FeeReceipt.TotalFee -= existStudentDtl.FeeAmount_New;
                        OldFee += Convert.ToDecimal(existStudentDtl.FeeAmount_New);
                       
                        //OldFee += Convert.ToDecimal(existStudentDtl.FeeAmount_New) + Convert.ToDecimal(existStudentDtl.FeeAmount_Old);
                        existStudentDtl.FeeTermId = Convert.ToInt32(FeeTermId);
                        existStudentDtl.StudentId = Convert.ToInt32(ddlStudentList.SelectedValue);
                        if (txtDepositFeeNew.Text != "")
                        {
                            existStudentDtl.FeeAmount_New = Convert.ToDecimal(txtDepositFeeNew.Text);
                            newFee += Convert.ToDecimal(txtDepositFeeNew.Text);
                        }
                        if (txtDepositFeeOld.Text != "")
                        {
                            existStudentDtl.FeeAmount_Old = Convert.ToDecimal(txtDepositFeeOld.Text);
                        }
                        if (txtCONCESSIONFEEAMT.Text != "")
                        {
                            existStudentDtl.ConcessionFeeAmt = Convert.ToDecimal(txtCONCESSIONFEEAMT.Text);
                        }
                        if (txtDUEFEE.Text != "")
                        {
                            existStudentDtl.DueFee = Convert.ToDecimal(txtDUEFEE.Text);
                        }
                        existStudentDtl.IsPaid = StudentDtl.IsPaid;
                        existStudentDtl.CreatedBy = cls_Common.UserProfile.Id;
                        existStudentDtl.CreatedDate = DateTime.Now;
                        StudentFeeOldList.Add(existStudentDtl);
                        //var result = _FeeDTO.Update(existStudentDtl);
                        //if (!result)
                        //    error = true;
                        
                        //newFee += Convert.ToDecimal(txtDepositFeeNew.Text) + Convert.ToDecimal(txtDepositFeeOld.Text);
                    }
                    StudentFeeReceipts.Add(FeeReceipt);
                }

                if((newFee <= OldFee || NewSubmittedFee<=0) && StudentFeeNewList.Count==0)
                {
                    uc_sucess.VisibleError = true;
                    uc_sucess.ErrorMessage = "You need to Enter more amount before pressing save!";
                    BindPaymentData();
                    return;
                }
                if(NewSubmittedFee > NewTotalFee)
                {
                    uc_sucess.VisibleError = true;
                    uc_sucess.ErrorMessage = "Submitted Amount can't be larger than total amount!";
                    BindPaymentData();
                    return;
                }
                foreach (var Student in StudentFeeNewList)
                {
                    _FeeDTO.Save(Student);
                }
                foreach (var Student in StudentFeeOldList)
                {
                    //if (OldFee >= newFee)
                    //{
                    //    uc_sucess.ErrorMessage = "Fees Total Amount is Still Same or lesser";
                    //    uc_sucess.VisibleError = true;
                    //    return;
                    //}
                    _FeeDTO.Update(Student);
                }
                if (error)
                {
                    uc_sucess.VisibleError = true;
                    uc_sucess.ErrorMessage = "Error Occured";
                }
                else
                {
                    uc_sucess.Visible = true;
                    uc_sucess.SuccessMessage = "Data Saved Successfully!";
                }
                _FeeDTO.Save(StudentFeeReceipts);
                BindPaymentData();
                lvStudentFee.DataBind();
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var eve in ex.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);

                    }
                }
            }
        }

        protected void FeeDetailClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindFeeDetailSection();
        }

        protected void lkbGetFeeDetail2_Click(object sender, EventArgs e)
        {
            try
            {
                SqlDataSource2.SelectParameters["CLASS_ID"].DefaultValue = FeeDetailClass.SelectedValue.ToString();
                SqlDataSource2.SelectParameters["SECTION_ID"].DefaultValue = FeeDetailSection.SelectedValue.ToString();
                SqlDataSource2.SelectParameters["FINYEAR_ID"].DefaultValue = FeeDetailFinYear.SelectedValue.ToString();
                lvFeeDetail.DataSourceID = "SqlDataSource2";
                lvFeeDetail.DataBind();
            }
            catch (Exception ex)
            {
            }
        }

        protected void lvFeeDetail_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                ListViewDataItem dataitem = (ListViewDataItem)e.Item;
                double DUEFEE = Convert.ToDouble(DataBinder.Eval(dataitem.DataItem, "DUEFEE").ToString());
                double AMOUNT = Convert.ToDouble(DataBinder.Eval(dataitem.DataItem, "TOTALFEE").ToString());
                HtmlTableCell cell = (HtmlTableCell)e.Item.FindControl("DueFee");
                if(DUEFEE==0)
                {
                    cell.Style.Add("color", "white");
                    cell.Style.Add("background-color", "Green");
                    return;
                }
                else if (DUEFEE < AMOUNT && DUEFEE>0)
                {
                    cell.Style.Add("color", "white");
                    cell.Style.Add("background-color", "#DAA520");
                    return;
                }
                cell.Style.Add("color", "white");
                cell.Style.Add("background-color", "Red");

            }
        }

        protected void ddlPaymentType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlPaymentType.SelectedValue == ((byte)EnumConstants.PaymentType.Cheque).ToString())
            {
                lblTransaction.Visible = true;
                txtTransactionNumber.Visible = true;
                lblTransaction.Text = "Cheque Number";
            }
            else if (ddlPaymentType.SelectedValue == ((byte)EnumConstants.PaymentType.Wallet).ToString() || ddlPaymentType.SelectedValue == ((byte)EnumConstants.PaymentType.NetBanking).ToString())
            {
                lblTransaction.Visible = true;
                txtTransactionNumber.Visible = true;
                lblTransaction.Text = "Transaction Number";
            }
            else
            {
                lblTransaction.Visible = false;
                txtTransactionNumber.Visible = false;
            }
        }
        public decimal? TotalDueFee=0;
        protected void lvStudentFee_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                byte startMonth = 7;
                int CurrentMonth = DateTime.Now.Month;
                int CurrentFinYear = Int32.Parse(ddlFinYear.SelectedItem.Text.Split('-')[0]);
                int CurrentYear = DateTime.Now.Year;
                TextBox txtDepositFeeNew = (TextBox)e.Item.FindControl("txtDepositFeeNew");
                TextBox txtCONCESSIONFEEAMT = (TextBox)e.Item.FindControl("txtCONCESSIONFEEAMT");
                TextBox txtDUEFEE = (TextBox)e.Item.FindControl("txtDUEFEE");
                ListViewDataItem dataitem = (ListViewDataItem)e.Item;
                decimal? DUEFEE = DataBinder.Eval(dataitem.DataItem, "DUEFEE") as decimal?== null ? 0: DataBinder.Eval(dataitem.DataItem, "DUEFEE") as decimal?;
                decimal? DEPOSIT = DataBinder.Eval(dataitem.DataItem, "STUDENT_FEEAMOUNT_NEW") as decimal? == null ? 0 : DataBinder.Eval(dataitem.DataItem, "STUDENT_FEEAMOUNT_NEW") as decimal?;
                decimal? CONCESSION = DataBinder.Eval(dataitem.DataItem, "CONCESSIONFEEAMT")as decimal? == null ? 0 : DataBinder.Eval(dataitem.DataItem, "CONCESSIONFEEAMT") as decimal?;
                decimal? AMOUNT = DataBinder.Eval(dataitem.DataItem, "FEEAMOUNT_NEW") as decimal? == null ? 0 : DataBinder.Eval(dataitem.DataItem, "FEEAMOUNT_NEW") as decimal?;
                AMOUNT+= DUEFEE - CONCESSION;
                byte? FEETERM = DataBinder.Eval(dataitem.DataItem, "FEETERM") as byte?;
                byte? FEEDURATION = DataBinder.Eval(dataitem.DataItem, "FEEDURATION") as byte?;
                if (AMOUNT == DEPOSIT)
                {
                    txtDepositFeeNew.Attributes.Add("readonly", "true");
                    txtCONCESSIONFEEAMT.Attributes.Add("readonly", "true");
                    txtDUEFEE.Attributes.Add("readonly", "true");
                }
                int tempMonth = 0, tempYear = 0;
                if (FEEDURATION == (byte)EnumConstants.FeeDuration.HalfYearly)
                {
                    //First Half Yearly
                    if(FEETERM == 1)
                    {
                        if (CurrentFinYear <= CurrentYear && startMonth <= CurrentMonth)
                        {
                            if (AMOUNT > DEPOSIT)
                            {
                                TotalDueFee += (AMOUNT - DEPOSIT);
                            }
                        }
                    }
                    //Second Half Yearly
                    else if(FEETERM == 2)
                    {
                        tempMonth += startMonth+6;
                        if(tempMonth>12)
                        {
                            tempMonth -= 12;
                            tempYear = CurrentFinYear + 1;
                        }
                        if (tempYear <= CurrentYear && tempMonth <= CurrentMonth)
                        {
                            if (AMOUNT > DEPOSIT)
                            {
                                TotalDueFee += (AMOUNT - DEPOSIT);
                            }
                        }
                    }
                }
                else if (FEEDURATION == (byte)EnumConstants.FeeDuration.Monthly)
                {
                    if (FEETERM >= startMonth && CurrentMonth >= FEETERM && CurrentFinYear <= CurrentYear)
                    {
                       TotalDueFee += (AMOUNT - DEPOSIT);
                    }
                    else if (FEETERM < startMonth && CurrentMonth >= FEETERM && CurrentFinYear < CurrentYear)
                    { 
                        TotalDueFee += (AMOUNT - DEPOSIT);
                    }
                }
                else if(FEEDURATION == (byte)EnumConstants.FeeDuration.Quartly)
                {
                    //first Quarter
                    if(FEETERM ==4)
                    {
                        if(/*startMonth>=1 && */ startMonth<= 3 && CurrentFinYear <=CurrentYear )
                        {
                            TotalDueFee += (AMOUNT - DEPOSIT);
                        }
                    }
                    //Second Quarter
                    else if (FEETERM == 1)
                    {
                        if (/*startMonth>=  4 &&*/ startMonth<=  6 && CurrentFinYear <= CurrentYear)
                        {
                            TotalDueFee += (AMOUNT - DEPOSIT);
                        }
                    }
                    //Third Quarter
                    else if (FEETERM == 2)
                    {
                        if (/*startMonth >= 7 &&*/ startMonth<=  9 && CurrentFinYear <= CurrentYear)
                        {
                            TotalDueFee += (AMOUNT - DEPOSIT);
                        }
                    }
                    //Fourth Quarter
                    else if (FEETERM == 3)
                    {
                        if (/*startMonth >= 10 && */ startMonth <=  12 && CurrentFinYear <= CurrentYear)
                        {
                            TotalDueFee += (AMOUNT - DEPOSIT);
                        }
                    }
                }
                else if(FEEDURATION == (byte)EnumConstants.FeeDuration.Anually)
                {
                    if(CurrentFinYear <= CurrentYear)
                        TotalDueFee += (AMOUNT - DEPOSIT);
                }
                else if (FEEDURATION == (byte)EnumConstants.FeeDuration.OneTime)
                {
                    if (CurrentFinYear <= CurrentYear)
                        TotalDueFee += (AMOUNT - DEPOSIT);
                }
                lblTotalDueFee.Text = "TOTAL DUE FEE : ₹ " + TotalDueFee.ToString();
            }
        }

        protected void lkbViewReceipt_Click(object sender, EventArgs e)
        {
            _FeeDTO = new cls_FeeDTO();
            long StudentId = Convert.ToInt64(ddlStudentList.SelectedValue);
            var data = _FeeDTO.GetFeeReceipt(StudentId,Convert.ToInt32(ddlFinYear.SelectedValue.ToString()));
            uc_FeeReceipt.BindItems(data, Convert.ToInt32(ddlStudentList.SelectedValue));

        }

        
    }
}