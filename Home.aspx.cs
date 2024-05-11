using HospitalManagementAdmin.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HospitalManagementAdmin
{
    
    public partial class Home : System.Web.UI.Page
    {
        public enum MessageType { success, danger, info, warning };
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Admin"] != null)
                {
                    GetAppointments();
                    GetDoctors();
                    DashboardCounts();
                }
                else
                {
                    Response.Redirect("AdminLogin.aspx");
                }
                ShowMessage("Welcome", "You are in Silvercrest Management System", MessageType.success);
            }
        }
        protected void ShowMessage(string Title, string message, MessageType type)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "AlertMessage('" + Title + "','" + message + "','" + type + "');", true);
        }

        public void GetAppointments()
        {
            DataTable dt = TblAppointment.GetAll();
            RptAppointments.DataSource = dt;
            RptAppointments.DataBind();
        }
        public void GetDoctors()
        {
            DataTable Dt = TblDoctor.GetAll();
            RptDoctors.DataSource = Dt;
            RptDoctors.DataBind();
        }
        public void DashboardCounts()
        {
            TblAppointment tbl  = new TblAppointment();
            long Appointments = tbl.GetAppointments();
            lblappointment.InnerText = Appointments.ToString();

            TblDoctor tbl1 = new TblDoctor();
            long Doctors = tbl1.GetDoctors();
            lbldoctors.InnerText = Doctors.ToString();

            TblPatient tb2 = new TblPatient();
            long patients = tb2.GetPatients();
            lblpatients.InnerText = patients.ToString();
        }

        protected void RptAppointments_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                var Mobile = e.CommandArgument.ToString();
                if(Mobile != null)
                {
                    TblAppointment edit = TblAppointment.Get(Mobile);
                    if (edit != null)
                    {

                    }
                }
            }
            else if (e.CommandName == "Delete")
            {
                var Mobile = e.CommandArgument.ToString();
                if (Mobile != null)
                {
                    TblAppointment del = new TblAppointment();
                    bool IsDeleted = del.Delete(Mobile);
                    if (IsDeleted)
                    {
                        GetAppointments();
                    }
                }
            }          
        }

        protected void RptDoctors_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                var Email = e.CommandArgument.ToString();
                if (Email != null)
                {
                    TblDoctor edit = TblDoctor.Get(Email);
                    if(edit != null)
                    {

                    }
                    
                }
            }
            else if (e.CommandName == "Delete")
            {
                var Email = e.CommandArgument.ToString();

                if (Email != null)
                {
                    TblDoctor del = new TblDoctor();
                    bool IsDeleted = del.Delete(Email);
                    if (IsDeleted)
                    {
                        GetDoctors();
                    }
                }
            }
        }
    }
}