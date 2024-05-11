using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HospitalManagementAdmin
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if(Session["Admin"] != null && Session["name"] !=null)
                {
                    Session["Admin"] = Session["Admin"].ToString();
                    Session["name"] = Session["name"].ToString();
                    lblAdminName.InnerHtml = Session["name"].ToString();
                    lblAdmin.InnerHtml = Session["name"].ToString();
                }
                else
                {
                    Response.Redirect("AdminLogin.aspx");
                }
            }
          
        }

        protected void BtnLogout_Click(object sender, EventArgs e)
        {
            Session["AdminName"] = null;
            Response.Redirect("AdminLogin.aspx");
        }
    }
}