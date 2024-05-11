using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HospitalAdminSystem.DAL;

namespace HospitalManagementAdmin
{
    
    public partial class AdminLogin : System.Web.UI.Page
    {
        public enum MessageType { success, danger, info, warning };
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        protected void ShowMessage(string Title, string message, MessageType type)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "AlertMessage('" + Title + "','" + message + "','" + type + "');", true);
        }

        protected void BtnLogin_ServerClick(object sender, EventArgs e)
        {
            var email = txtemail.Value;
            var pass = txtpassword.Value;

            TblAdmin user = TblAdmin.ValidateUser(email);
            if (user.Email == txtemail.Value && txtpassword.Value == pass)
            {
                Session["Admin"] = user.Email;
                Session["name"] = user.Name;

                Response.Redirect("Home.aspx");
            }
            else
            {
                ShowMessage("Oops ?", "Email & Password Not Correct", MessageType.warning);
            }
        }
    }
}