using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace HospitalAdminSystem.DAL
{
    public class TblAdmin
    { 
     public long Id           {get;set;}
     public string Name       {get;set;}
     public string Email      {get;set;}
     public string Mobile     {get;set;}
     public string Address    {get;set;}
     public string Password   {get;set;}
     public DateTime? CreatedDate { get; set; }


        public void Add()
        {
            try
            {
                string Constr = ConfigurationManager.ConnectionStrings["HospitalAdm"].ConnectionString;
                using (SqlConnection Con = new SqlConnection(Constr))
                {
                    string Sql = @"insert into [TblAdmin]
                                      (
                                        [Name]
                                       ,[Email]
                                       ,[Mobile]
                                       ,[Password]
                                       ,[Address]                                      
                                       ,[CreatedDate]
                                       )
                                       values
                                        (
                                        @Name
                                       ,@Email
                                       ,@Mobile
                                       ,@Password
                                       ,@Address                                      
                                       ,@CreatedDate
                                       );";

                    Sql += "select scope_identity();";
                    Con.Open();

                    using (SqlCommand cmd = new SqlCommand(Sql, Con))
                    {
                        cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 50).Value = Name == null ? (Object)DBNull.Value : Name;
                        cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 50).Value = Email == null ? (Object)DBNull.Value : Email;
                        cmd.Parameters.Add("@Address", SqlDbType.NVarChar, 50).Value = Address == null ? (Object)DBNull.Value : Address;
                        cmd.Parameters.Add("@Password", SqlDbType.NVarChar, 50).Value = Password == null ? (Object)DBNull.Value : Password;
                        cmd.Parameters.Add("@Mobile", SqlDbType.NVarChar, 50).Value = Mobile == null ? (Object)DBNull.Value : Mobile;
                        cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime, 8).Value = CreatedDate == null ? (Object)DBNull.Value : CreatedDate;
                        Id = Convert.ToInt64(cmd.ExecuteScalar());
                        Con.Close();
                    }
                }
            }
            catch (Exception Ex)
            {
                var Msg = Ex.Message;
            }
        }


        public static TblAdmin ValidateUser(string email)
        {
            TblAdmin TblApt = new TblAdmin();
            try
            {
                string Constr = ConfigurationManager.ConnectionStrings["HospitalAdm"].ConnectionString;
                using (SqlConnection Con = new SqlConnection(Constr))
                {
                    string Sql = @"select Name,Email,Password from [TblAdmin] where [Email]=@email";
                    Con.Open();

                    using (SqlCommand cmd = new SqlCommand(Sql, Con))
                    {
                        cmd.Parameters.Add("@email", SqlDbType.NVarChar, 50).Value = email;
                        using (SqlDataReader Rd = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                        {
                            if (Rd.Read())
                            {
                                TblApt.Password = Rd["Password"] == DBNull.Value ? null : Rd["Password"].ToString();
                                TblApt.Email = Rd["Email"] == DBNull.Value ? null : Rd["Email"].ToString();
                                TblApt.Name = Rd["Name"] == DBNull.Value ? null : Rd["Name"].ToString();
                            }
                        }
                    }
                    Con.Close();
                }
            }
            catch (Exception Ex)
            {
                var Msg = Ex.Message;
            }
            return TblApt;
        }
    }
}