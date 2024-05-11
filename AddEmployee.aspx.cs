using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HospitalAdminSystem.DAL;
using System.Data;
using System.IO;

namespace HospitalManagementAdmin
{
    public partial class AddEmployee : System.Web.UI.Page
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

        protected void BtnAddEmployee_ServerClick(object sender, EventArgs e)
        {
            TblEmployee Td = new TblEmployee();
            Td.FullName = txtfname.Value;
            Td.Address = txtaddress.Value;
            Td.City = txtcity.Value;
            Td.CreatedBy = 1;
            Td.CreatedDate = DateTime.Now;
            Td.DOB = Convert.ToDateTime(txtdob.Value);
            Td.Email = txtemail.Value;
            Td.Gender = ddlgender.Value;
            Td.Mobile = txtmobile.Value;

            var filename = (txtphoto.PostedFile.FileName);
            var path = Path.Combine(Server.MapPath("~/Images/"), filename);
            txtphoto.PostedFile.SaveAs(path);
            var image = "Images/" + filename;

            Td.Photo = image;
            Td.PostalCode = txtpostalcode.Value;
            Td.State = ddlstate.Value;
            Td.Add();
            if (Td.EmpId > 0)
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
            txtpostalcode.Value = "";
            ddlgender.Value = "";
            ddlstate.Value = "";
        }
    }
}