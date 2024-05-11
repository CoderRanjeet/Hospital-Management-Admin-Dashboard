using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HospitalManagementAdmin.DAL;

namespace HospitalManagementAdmin
{
    public partial class ViewDoctors : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Admin"] == null)
                {
                    Response.Redirect("AdminLogin.aspx");
                }
                else
                {
                    GetDoctors();
                }          
            }
        }

        public void GetDoctors()
        {
            DataTable Dt = TblDoctor.GetAll();
            RptDoctors.DataSource = Dt;
            RptDoctors.DataBind();
        }
    }
}