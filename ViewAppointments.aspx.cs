using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using HospitalManagementAdmin.DAL;

namespace HospitalManagementAdmin
{
    public partial class ViewAppointments : System.Web.UI.Page
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
                        GetAppointments();
                    }
            }
        }
        public void GetAppointments()
        {
            DataTable dt = TblAppointment.GetAll();
            RptAppointments.DataSource = dt;
            RptAppointments.DataBind();
        }
    }
}