using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HospitalAdminSystem.DAL;

namespace HospitalManagementAdmin
{
    public partial class AdminSignup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        protected void BtnCreate_ServerClick(object sender, EventArgs e)
        {
            if (txtName.Value != "" && txtEmail.Value != "" && txtAddress.Value != "" && txtMobile.Value != "" && txtpassword.Value != "")
            {
                TblAdmin admin = new TblAdmin();
                admin.Name = txtName.Value;
                admin.Mobile = txtMobile.Value;
                admin.Email = txtEmail.Value;
                admin.Address = txtAddress.Value;
                admin.CreatedDate = DateTime.Now;

                if (txtpassword.Value == txtcpassword.Value)
                {
                    admin.Password = txtpassword.Value;
                    admin.Add();
                    if(admin.Id > 0)
                    {
                        Clear();
                        Response.Write("<script>alert('Congratulations ! Your Account Created Successfully. ')</script>");
                    }
                }
                else
                {
                    Response.Write("<script>alert('password and confirm password')</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Fill All Details ')</script>");
            }
        }

        public void Clear()
        {
            txtName.Value = "";
            txtEmail.Value = "";
            txtMobile.Value = "";
            txtAddress.Value = "";
            txtcpassword.Value = "";
            txtpassword.Value = "";
        }
    }
}