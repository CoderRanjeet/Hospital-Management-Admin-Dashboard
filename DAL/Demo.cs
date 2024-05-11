using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace HospitalAdminSystem.DAL
{
    public class Demo
    {
        public long Id { get; set; }
        public string  Name { get; set; }
        public string  Email { get; set; }
        public DateTime Date { get; set; }


        public void Add()
        {
            try
            {
                string Constr = ConfigurationManager.ConnectionStrings["HospitalAdm"].ConnectionString;
                using (SqlConnection Con = new SqlConnection(Constr))
                {                   
                    Con.Open();                   
                    using (SqlCommand cmd = new SqlCommand("spinsert", Con))
                    {
                     
                        cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 50).Value = Name == null ? (Object)DBNull.Value : Name;
                        cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 50).Value = Email == null ? (Object)DBNull.Value : Email;
                        cmd.Parameters.Add("@Date", SqlDbType.DateTime, 8).Value = Date == null ? (Object)DBNull.Value : Date;
                        cmd.Parameters.Add("@Id", SqlDbType.BigInt,8).Direction = ParameterDirection.Output;
                        cmd.CommandType = CommandType.StoredProcedure;
                   
                        cmd.ExecuteNonQuery();
                        long id = Convert.ToInt64(cmd.Parameters["@Id"].Value);
                        Con.Close();
                    }
                }
            }
            catch (Exception Ex)
            {
                var Msg = Ex.Message;
            }
        }

        public static Demo Get(long Id)
        {
            Demo TblApt = new Demo();
            try
            {
                string Constr = ConfigurationManager.ConnectionStrings["HospitalAdm"].ConnectionString;
                using (SqlConnection Con = new SqlConnection(Constr))
                {
                   
                    Con.Open();

                    using (SqlCommand cmd = new SqlCommand("sp_Databyid", Con))
                    {
                        cmd.Parameters.Add("@Id", SqlDbType.BigInt, 8).Value = Id;
                        cmd.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader Rd = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                        {
                            if (Rd.Read())
                            {
                                TblApt.Name = Rd["Name"] == DBNull.Value ? null : Rd["Name"].ToString();
                                TblApt.Email = Rd["Email"] == DBNull.Value ? null : Rd["Email"].ToString();
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

        public static DataTable GetAll()
        {
            DataTable Dt = new DataTable();
            try
            {
                string Constr = ConfigurationManager.ConnectionStrings["HospitalAdm"].ConnectionString;
                using (SqlConnection Con = new SqlConnection(Constr))
                {
                    
                    Con.Open();

                    using (SqlCommand cmd = new SqlCommand("sp_Data", Con))
                    {
                        using (SqlDataReader Rd = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                        {
                            Dt.Load(Rd);
                        }
                    }
                    Con.Close();
                }
            }
            catch (Exception Ex)
            {
                var Msg = Ex.Message;
            }
            return Dt;
        }

        public void Update()
        {
            try
            {
                string Constr = ConfigurationManager.ConnectionStrings["HospitalAdm"].ConnectionString;
                using (SqlConnection Con = new SqlConnection(Constr))
                {
                   
                    Con.Open();

                    using (SqlCommand cmd = new SqlCommand("sp_update", Con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@Id", SqlDbType.BigInt, 8).Value = Id;
                        cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 50).Value = Name == null ? (Object)DBNull.Value : Name;
                        cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 50).Value = Email == null ? (Object)DBNull.Value : Email;
                       
                        cmd.ExecuteNonQuery();
                        Con.Close();
                    }
                }
            }
            catch (Exception Ex)
            {
                var Msg = Ex.Message;
            }
        }

        public bool Delete(long Id)
        {
            bool IsDelete = false;
            try
            {
                string Constr = ConfigurationManager.ConnectionStrings["HospitalAdm"].ConnectionString;
                using (SqlConnection Con = new SqlConnection(Constr))
                {
                  
                    Con.Open();

                    using (SqlCommand cmd = new SqlCommand("sp_Delete", Con))
                    {
                        cmd.Parameters.Add("@Id", SqlDbType.BigInt, 8).Value = Id;
                        cmd.CommandType = CommandType.StoredProcedure;
                        int Msg = cmd.ExecuteNonQuery();
                        if (Msg == 1)
                        {
                            IsDelete = true;
                        }
                        else
                        {
                            IsDelete = false;
                        }
                    }
                    Con.Close();
                }
            }
            catch (Exception Ex)
            {
                var Msg = Ex.Message;
            }
            return IsDelete;
        }
    }
}