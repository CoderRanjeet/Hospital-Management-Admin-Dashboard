using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HospitalManagementAdmin.DAL;

namespace HospitalManagementAdmin
{
    public partial class AddPatient : System.Web.UI.Page
    {
        public enum MessageType { success, danger, info, warning };
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Admin"] == null)
                {
                    Response.Redirect("AdminLogin.aspx");
                }
            }
        }
        protected void ShowMessage(string Title, string message, MessageType type)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "AlertMessage('" + Title + "','" + message + "','" + type + "');", true);
        }

        protected void BtnAddPatient_ServerClick(object sender, EventArgs e)
        {
            TblPatient Tp = new TblPatient();
            Tp.FullName = txtfname.Value;
            Tp.Email = txtemail.Value;
            Tp.Gender = ddlgender.Value;
            Tp.Mobile = txtmobile.Value;
            Tp.DOB = Convert.ToDateTime(txtdob.Value);
            Tp.CreatedBy = 1;
            Tp.CreatedDate = DateTime.Now;
            Tp.Address = txtaddress.Value;
            Tp.City = txtcity.Value;
            Tp.Add();
            if(Tp.PatId > 0)
            {
                Clear();
            }
            else
            {

            }
        }

        public void Clear()
        {
            txtfname.Value = "";
            txtemail.Value = "";
            txtcity.Value = "";
            txtdob.Value = "";
            txtaddress.Value = "";
            txtmobile.Value = "";        
            ddlgender.Value = "";      
        }
    }
}