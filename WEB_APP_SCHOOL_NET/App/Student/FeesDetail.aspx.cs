using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web.UI.WebControls;
using WEB_APP_SCHOOL_NET.BAL;
using WEB_APP_SCHOOL_NET.Common;
using WEB_APP_SCHOOL_NET.DAL;

namespace WEB_APP_SCHOOL_NET.App.Student
{
    public partial class FeesManagement : System.Web.UI.Page
    {
        cls_FeeDTO feeDTO;
        cls_ClassDTO _ClassDTO;
        CommonBindControl commonBindControl;
        cls_Fee_Structure _fee_Structure;
       
        
        public void FeesObject()
        {
            feeDTO = new cls_FeeDTO();
            _ClassDTO = new cls_ClassDTO();
            commonBindControl = new CommonBindControl();
            _fee_Structure = new cls_Fee_Structure();
        }
        protected void Page_Load(object sender, EventArgs e) 
        {
            FeesObject();
            if (!IsPostBack)
            {
                
                BindClass();
                BindFeeDuration(); BindFee();
            }
        }
        private void BindClass()
        {
            commonBindControl.BindMasterData(ddlFinYear, EnumConstants.Masters.AcademicYear);
            commonBindControl.BindMasterData(ddlClass, EnumConstants.Masters.Class);
            commonBindControl.BindMasterData(ddlAcaYearFeeStrucure, EnumConstants.Masters.AcademicYear);
            commonBindControl.BindMasterData(ddlClassFeeStru, EnumConstants.Masters.Class);
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                bool error = false;
                List<MST_FEE_DETAIL> NewFeeDetailList = new List<MST_FEE_DETAIL>();
                List<MST_FEE_DETAIL> OldFeeDetailList = new List<MST_FEE_DETAIL>();
                cls_Fee_Structure structure = new cls_Fee_Structure();

                foreach (ListViewDataItem item in lvFees.Items)
                {
                    MST_FEE_DETAIL FeeDtl = new MST_FEE_DETAIL();
                    string FeeDtlId = (lvFees.DataKeys[item.DisplayIndex].Values["FeeDetailId"].ToString());
                    int FeeId = Convert.ToInt32(lvFees.DataKeys[item.DisplayIndex].Values["FeeId"].ToString());
                    FeeDtl.FeeId = FeeId;
                    FeeDtl.ClassId = Convert.ToInt32(ddlClass.SelectedValue);
                    TextBox txtAmtNew = (TextBox)item.FindControl("txtAmtNew");
                    TextBox txtAmtOld = (TextBox)item.FindControl("txtAmtOld");
                    TextBox txtRemark = (TextBox)item.FindControl("txtRemark");
                    //if(Convert.ToDecimal(txtAmtNew.Text)<=0)
                    //{
                    //    error = true;
                    //    uc_sucess.ErrorMessage = "Amount Cannot be lower than or equal to 0";
                    //}
                    FeeDtl.FeeAmount_New = Convert.ToDecimal(txtAmtNew.Text);
                    FeeDtl.FeeAmount_Old = Convert.ToDecimal(txtAmtOld.Text);
                    FeeDtl.Remark = Convert.ToString(txtRemark.Text);
                    FeeDtl.Fin_ID = Convert.ToInt32(ddlFinYear.SelectedValue);
                    int exitFeeDtlId = Convert.ToInt32(FeeDtlId);
                    var existFeeDtl = feeDTO.GetFeeDetails(exitFeeDtlId > 0 ? exitFeeDtlId : 0, Convert.ToInt32(ddlClass.SelectedValue), Convert.ToInt32(ddlFinYear.SelectedValue.ToString()));
                    if (existFeeDtl==null)
                    {
                        NewFeeDetailList.Add(FeeDtl);
                    }
                    else
                    {                       
                        //existFeeDtl.FeeDetailId = exitFeeDtlId;
                       // existFeeDtl.FeeId = FeeId;
                        //existFeeDtl.ClassId = Convert.ToInt32(ddlClass.SelectedValue);
                        existFeeDtl.FeeAmount_New = Convert.ToDecimal(txtAmtNew.Text);
                        existFeeDtl.FeeAmount_Old = Convert.ToDecimal(txtAmtOld.Text);
                        existFeeDtl.Remark = Convert.ToString(txtRemark.Text);
                       // existFeeDtl.Fin_ID = Convert.ToInt32(ddlFinYear.SelectedValue);
                        OldFeeDetailList.Add(existFeeDtl);
                    }
                }
                if (error)
                {
                    uc_sucess.VisibleError = true;
                    return;
                }
                else
                {
                    uc_sucess.SuccessMessage = "Data Saved Successfully!";
                    uc_sucess.Visible = true;
                }
                foreach (var items in NewFeeDetailList)
                {
                    var result = feeDTO.Save(items);
                    structure.CreateFeeStructure(Convert.ToInt32(ddlFinYear.SelectedValue), Convert.ToInt32(ddlClass.SelectedValue), Convert.ToInt32(items.FeeId));
                    if (!result)
                    {
                        uc_sucess.ErrorMessage = "Error Occured in saving Data";
                        uc_sucess.VisibleError = true;
                        return;
                    }
                }
                foreach (var items in OldFeeDetailList)
                {
                    var result = feeDTO.Update(items);
                    structure.CreateFeeStructure(Convert.ToInt32(ddlFinYear.SelectedValue), Convert.ToInt32(ddlClass.SelectedValue), Convert.ToInt32(items.FeeId));
                    if (!result)
                    {
                        uc_sucess.ErrorMessage = "Error Occured in saving Data";
                        uc_sucess.VisibleError = true;
                        return;
                    }
                }
                lvFees.DataSource = feeDTO.GetFeeDetail(Convert.ToInt32(ddlClass.SelectedValue.ToString()), ddlFinYear.SelectedValue);
                lvFees.DataBind();
            }
            catch(Exception ex)
            {
                //TODO
            }
        }
        public string GetDuration(object feeDuration)
        {
            EnumConstants.FeeDuration duration = (EnumConstants.FeeDuration)Enum.Parse(typeof(EnumConstants.FeeDuration), feeDuration.ToString());
            return duration.ToDescription();
        }
       

        protected void ddlClassFee_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlClassFeeStru.SelectedIndex > -1)
            {
                lvFeeStructure.DataSource = _fee_Structure.GetFEE_STRUCTURE(Convert.ToInt32(ddlAcaYearFeeStrucure.SelectedValue.ToString()) , Convert.ToInt32(ddlClassFeeStru.SelectedValue.ToString()));
                lvFeeStructure.DataBind();
            }
            else
            {
                lvFeeStructure.DataSource = null;
                lvFeeStructure.DataBind();
            }
        }

        protected void lkbFeeSave_Click(object sender, EventArgs e)
        {
            try
            {
                if(txtFeeText.Text.Trim() == "")
                {
                    txtFeeText.ForeColor = Color.Red;
                    txtFeeText.BorderColor = Color.Red;
                    txtFeeText.Focus();
                    return;
                }
                if (ddlFeeDuration.SelectedIndex > -1)
                {
                    MST_FEE obj = new MST_FEE();
                    obj.FeeName = txtFeeText.Text.Trim();
                    obj.UserId = cls_Common.UserProfile.Id;
                    obj.Org_ID = cls_Common.UserProfile.ORG_ID;
                    EnumConstants.FeeDuration duration = (EnumConstants.FeeDuration)Enum.Parse(typeof(EnumConstants.FeeDuration), ddlFeeDuration.SelectedValue);
                    List<MST_FEE_TERM> terms = new List<MST_FEE_TERM>();
                    if (ddlFeeDuration.SelectedItem.Text == EnumConstants.FeeDuration.Monthly.ToString()
                        || ddlFeeDuration.SelectedItem.Text == EnumConstants.FeeDuration.Quartly.ToString()
                        || ddlFeeDuration.SelectedItem.Text == EnumConstants.FeeDuration.HalfYearly.ToString())
                    {
                        int countIsSelect = 0;
                        if (cbTerm.Items.Count > 0)
                        {
                            foreach (ListItem item in cbTerm.Items)
                            {
                                MST_FEE_TERM term = new MST_FEE_TERM();
                                if (ddlFeeDuration.SelectedValue == ((byte)EnumConstants.FeeDuration.Monthly).ToString())
                                {
                                    if (item.Selected)
                                    {
                                        EnumConstants.MonthName fD = (EnumConstants.MonthName)Enum.Parse(typeof(EnumConstants.MonthName), item.Value);
                                        term.FeeTerm = (byte)fD;
                                        terms.Add(term);
                                        countIsSelect++;
                                    }
                                }
                                else if (ddlFeeDuration.SelectedValue == ((byte)EnumConstants.FeeDuration.Quartly).ToString())
                                {
                                    if (item.Selected)
                                    {
                                        EnumConstants.Quaterly fD = (EnumConstants.Quaterly)Enum.Parse(typeof(EnumConstants.Quaterly), item.Value);
                                        term.FeeTerm = (byte)fD;
                                        terms.Add(term);
                                        countIsSelect++;
                                    }
                                }
                                else if (ddlFeeDuration.SelectedValue == ((byte)EnumConstants.FeeDuration.HalfYearly).ToString())
                                {
                                    if (item.Selected)
                                    {
                                        EnumConstants.HalfYearly fD = (EnumConstants.HalfYearly)Enum.Parse(typeof(EnumConstants.HalfYearly), item.Value);
                                        term.FeeTerm = (byte)fD;
                                        terms.Add(term);
                                        countIsSelect++;
                                    }
                                }
                            }
                        }
                        if (countIsSelect == 0|| cbTerm.Items.Count < 1)
                        {
                            uc_sucess3.VisibleError = true;
                            uc_sucess3.ErrorMessage = "Kindly Select at least one term..";
                            return;
                        }
                    }
                    
                    if (ddlFeeDuration.SelectedItem.Text == EnumConstants.FeeDuration.Anually.ToString())
                    {
                        terms.Add(new MST_FEE_TERM { FeeTerm = 1 });
                    }
                    else if (ddlFeeDuration.SelectedItem.Text == EnumConstants.FeeDuration.OneTime.ToString())
                    {
                        terms.Add(new MST_FEE_TERM { FeeTerm = 1 });
                    }

                    obj.MST_FEE_TERM = terms;
                    obj.FeeDuration = (byte)duration;
                    obj.CreatedBy = cls_Common.UserProfile.Id;
                    obj.CreatedDate = DateTime.Now;
                    feeDTO.Save(obj);
                    uc_sucess3.Visible = true;
                    uc_sucess3.SuccessMessage = "Data Saved Successfully.";
                    txtFeeText.Text = "";
                    BindFee();
                    cbTerm.Items.Clear();
                    ddlFeeDuration.SelectedIndex = -1;
                    txtFeeText.BorderColor = ddlFeeDuration.BorderColor;
                    txtFeeText.ForeColor = ddlFeeDuration.ForeColor;
                    
                }

            }
            catch (Exception ex)
            {
            }
        }

        private void BindFeeDuration()
        {
            ddlFeeDuration.DataSource = typeof(Common.EnumConstants.FeeDuration).ToList();
            ddlFeeDuration.DataTextField ="Key" ;
            ddlFeeDuration.DataValueField = "Value";
            ddlFeeDuration.DataBind();
            ddlFeeDuration.Items.Insert(0, new ListItem("[ SELECT ]", "-1"));
        }
        //public string GetDuration(object feeDuration)
        //{
        //    EnumConstants.FeeDuration duration = (EnumConstants.FeeDuration)Enum.Parse(typeof(EnumConstants.FeeDuration), feeDuration.ToString());
        //    return duration.ToDescription();
        //}
        private void BindFee()
        {
            lvFee.DataSource = feeDTO.GetFee();
            lvFee.DataBind();
        }

        protected void lkbFeeDelete_Click(object sender, EventArgs e)
        {
            uc_sucess3.Visible = false;
            uc_sucess3.VisibleError = false;
            try
            {
                LinkButton lkb = (LinkButton)sender;
                var fee = feeDTO.GetFee(Convert.ToInt32(lkb.CommandArgument));

                feeDTO.Delete(fee);
                
                uc_sucess3.Visible = true;
                uc_sucess3.SuccessMessage = "Fee deleted successfully.";
                BindFee();
            }
            catch (Exception ex)
            {
                uc_sucess3.VisibleError = true;
                uc_sucess3.ErrorMessage = ex.Message;
            }
        }

        protected void ddlFeeDuration_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlFeeDuration.SelectedValue == ((byte)EnumConstants.FeeDuration.Monthly).ToString())
            {
                cbTerm.DataSource = typeof(Common.EnumConstants.MonthName).ToList();
                cbTerm.DataTextField = "Key";
                cbTerm.DataValueField = "Value";
                cbTerm.DataBind();
                
                //.DataSource=
            }
            else if (ddlFeeDuration.SelectedValue == ((byte)EnumConstants.FeeDuration.Quartly).ToString())
            {
                cbTerm.DataSource = typeof(Common.EnumConstants.Quaterly).ToList();
                cbTerm.DataTextField = "Key";
                cbTerm.DataValueField = "Value";
                cbTerm.DataBind();
            }
            else if (ddlFeeDuration.SelectedValue == ((byte)EnumConstants.FeeDuration.HalfYearly).ToString())
            {
                cbTerm.DataSource = typeof(Common.EnumConstants.HalfYearly).ToList();
                cbTerm.DataTextField = "Key";
                cbTerm.DataValueField = "Value";
                cbTerm.DataBind();
            }
            else
            {
                cbTerm.Items.Clear();          
            }
            foreach (ListItem li in cbTerm.Items)
            {
                li.Selected = true;
            }
        }

        protected void btnGetData_Click(object sender, EventArgs e)
        {
            ddlClass.ForeColor = ddlFinYear.ForeColor;
            ddlClass.BorderColor = ddlFinYear.BorderColor;
            if (ddlClass.SelectedIndex == 0)
            {
                ddlClass.ForeColor = Color.Red;
                ddlClass.BorderColor = Color.Red;
                return;
            }
            if (ddlClass.SelectedIndex > 0)
            {
                lvFees.DataSource = feeDTO.GetFeeDetail(Convert.ToInt32(ddlClass.SelectedValue.ToString()), ddlFinYear.SelectedValue);
                lvFees.DataBind();
                btnSave.Visible = true;
            }
            else
            {
                lvFees.DataSource = null;
                lvFees.DataBind();
            }
        }
    }
}