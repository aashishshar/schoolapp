using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEB_APP_SCHOOL_NET.BAL;
using WEB_APP_SCHOOL_NET.Common;
using WEB_APP_SCHOOL_NET.DAL;
using System.IO;


namespace WEB_APP_SCHOOL_NET.Account
{
    public partial class Profile : System.Web.UI.Page
    {
        cls_OrganizationDTO _OrganizationDTO;

       
        public Profile()
        {
            _OrganizationDTO = new cls_OrganizationDTO();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                GetOrganizationInfo();
            }
        }

        private void GetOrganizationInfo()
        {
            var organizationInfo = _OrganizationDTO.GetORGANIZATION(cls_Common.UserProfile.ORG_ID);
            if (organizationInfo != null)
            {
                txtName.Text =organizationInfo.Name;
                txtimgPath.Text = organizationInfo.ImagePath;
                txtAddress.Text = organizationInfo.Address;
                txtAffilated.Text = organizationInfo.AffilatedFrom;
                txtDirectorName.Text = organizationInfo.DirectorName;
                txtFaxNo.Text = organizationInfo.FaxNumber;
                txtManagerName.Text = organizationInfo.ManagerName;
                txtPANNo.Text = organizationInfo.PanNumber;
                txtPhoneno.Text = organizationInfo.PhoneNumber;
                txtRegNo.Text = organizationInfo.RegistrationNumber;
                txtPrincipalName.Text = organizationInfo.PrincipalName;
                txtAddress.Text = organizationInfo.Address;
                
            }
        }

        protected void lkbSave_Click(object sender, EventArgs e)
        {
            try
            {
                var obj = _OrganizationDTO.GetORGANIZATION(cls_Common.UserProfile.ORG_ID);
                Byte[] ImgByte = null;
                //  string ima = HiddenField1.Value;
                if (FileUpload1.HasFile)
                {
                    // Read the file and convert it to Byte Array
                    string filePath = FileUpload1.PostedFile.FileName;
                    string filename = Path.GetFileName(filePath);
                    string ext = Path.GetExtension(filename);
                    string contenttype = String.Empty;
                    //Set the contenttype based on File Extension 
                    switch (ext)
                    {
                        case ".jpg":
                        case ".JPG":
                            contenttype = "image/jpg";
                            break;
                        case ".png":
                        case ".PNG":
                            contenttype = "image/png";
                            break;
                        case ".jpeg":
                        case ".JPEG":
                            contenttype = "image/jpeg";
                            break;
                    }
                    if (contenttype != String.Empty)
                    {
                        Stream fs = FileUpload1.PostedFile.InputStream;
                        BinaryReader br = new BinaryReader(fs);
                        Byte[] bytes = br.ReadBytes((Int32)fs.Length);
                        System.Drawing.Image img = System.Drawing.Image.FromStream(FileUpload1.PostedFile.InputStream);
                        decimal size = Math.Round(((decimal)FileUpload1.PostedFile.ContentLength / (decimal)1024), 2);
                        if (size > 2048)
                        {
                            ShowMessage("Size of the image to be uploaded cannot exceed two mb.", false);

                            return;
                        }
                        ImgByte = bytes;
                    }
                    obj.Image = ImgByte;
                }
                obj.Name = txtName.Text.Trim();
                obj.ManagerName = txtManagerName.Text.Trim();
                obj.PanNumber = txtPANNo.Text.Trim();
                obj.PrincipalName = txtPrincipalName.Text.Trim();
                obj.RegistrationNumber = txtRegNo.Text.Trim();
                obj.Status = 1;
                obj.ImagePath = txtimgPath.Text.Trim();
                obj.AffilatedFrom = txtAffilated.Text.Trim();
                obj.FaxNumber = txtFaxNo.Text.Trim();
                obj.DirectorName = txtDirectorName.Text.Trim();
                obj.PhoneNumber = txtPhoneno.Text.Trim();
                obj.Address = txtAddress.Text.Trim();
              
                
               var result= _OrganizationDTO.Update(obj);
                if (result)
                {
                    ShowMessage("Profile Updated Successfully", true);
                }
                else
                {
                    ShowMessage("Some Error Found", false);
                }
            }

            catch(Exception ex)
            {

            }


        }
        private void ShowMessage(string message, bool successMessage)
        {
            // UC.uc_sucess msg = new UC.uc_sucess();
            UC.uc_sucess msg = (UC.uc_sucess)Page.LoadControl("~/uc/uc_sucess.ascx");
            msg.ID = "msg_id_student";
            if (successMessage)
            {
                msg.Visible = true;

                msg.VisibleError = false;
                msg.SuccessMessage = message;
            }
            else
            {
                msg.VisibleError = true;
                msg.Visible = false;
                msg.ErrorMessage = message;
            }
            litMessage.Controls.Add(msg);
        }



    }
}

