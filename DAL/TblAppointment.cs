using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace HospitalManagementAdmin.DAL
{
    public class TblAppointment
    {
      public long  AptId       {get;set;}
      public string  PatientName {get;set;}
      public string  Email       {get;set;}
      public string  Mobile      {get;set;}
      public string  Address     {get;set;}
      public string  Gender      {get;set;}
      public DateTime? AppointDate {get;set;}
      public string Department  {get;set;}
      public string DoctorName  {get;set;}
      public string Description { get; set; }
      public DateTime? CreatedDate { get; set; }


        public void Add()
        {
            try
            {
                string Constr = ConfigurationManager.ConnectionStrings["HospitalAdm"].ConnectionString;
                using (SqlConnection Con = new SqlConnection(Constr))
                {
                    string Sql = @"insert into [TblAppointment]
                                      (
                                      [PatientName]
                                      ,[Email]
                                      ,[Mobile]
                                      ,[Address]
                                      ,[Gender]
                                      ,[AppointDate]
                                      ,[Department]
                                      ,[DoctorName]
                                      ,[Description]
                                      ,[CreatedDate]
                                       )
                                       values
                                        (
                                       ,@PatientName
                                       ,@Email
                                       ,@Mobile
                                       ,@Address
                                       ,@Gender
                                       ,@AppointDate
                                       ,@Department
                                       ,@DoctorName
                                       ,@Description
                                       ,@CreatedDate
                                       );";
                    Sql += "select scope_identity();";
                    Con.Open();

                    using (SqlCommand cmd = new SqlCommand(Sql, Con))
                    {
                        cmd.Parameters.Add("@PatientName", SqlDbType.NVarChar, 50).Value =PatientName== null ? (Object)DBNull.Value : PatientName;
                        cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 50).Value = Email == null ? (Object)DBNull.Value : Email;
                        cmd.Parameters.Add("@Mobile", SqlDbType.NVarChar, 50).Value = Mobile == null ? (Object)DBNull.Value : Mobile;
                        cmd.Parameters.Add("@Address", SqlDbType.NVarChar, 50).Value =    Address== null ? (Object)DBNull.Value :  Address;
                        cmd.Parameters.Add("@Gender", SqlDbType.NVarChar, 50).Value = Gender == null ? (Object)DBNull.Value : Gender;
                        cmd.Parameters.Add("@AppointDate", SqlDbType.DateTime,8).Value = AppointDate == null ? (Object)DBNull.Value : AppointDate;
                        cmd.Parameters.Add("@Department", SqlDbType.NVarChar, 50).Value = Department == null ? (Object)DBNull.Value : Department;
                        cmd.Parameters.Add("@DoctorName", SqlDbType.NVarChar, 50).Value = DoctorName == null ? (Object)DBNull.Value : DoctorName;
                        cmd.Parameters.Add("@Description", SqlDbType.NVarChar, 50).Value = Description == null ? (Object)DBNull.Value : Description;
                        cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime,8).Value = CreatedDate == null ? (Object)DBNull.Value : CreatedDate;
                        AptId = Convert.ToInt64(cmd.ExecuteScalar());
                        Con.Close();
                    }
                }
            }
            catch(Exception Ex)
            {
                var Msg = Ex.Message;
            }
        }

        public static TblAppointment Get(string Mobile)
        {
            TblAppointment TblApt = new TblAppointment();
            try
            {
                string Constr = ConfigurationManager.ConnectionStrings["HospitalAdm"].ConnectionString;
                using (SqlConnection Con = new SqlConnection(Constr))
                {
                    string Sql = @"select * from [TblAppointment] where [Mobile]=@Mobile";
                    Con.Open();

                    using (SqlCommand cmd = new SqlCommand(Sql, Con))
                    {
                        cmd.Parameters.Add("@Mobile", SqlDbType.NVarChar,50).Value= Mobile;
                        using (SqlDataReader Rd = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                        {
                            if (Rd.Read())
                            {
                                TblApt.PatientName = Rd["PatientName"] == DBNull.Value ? null : Rd["PatientName"].ToString();
                                TblApt.Email = Rd["Email"] == DBNull.Value ? null : Rd["Email"].ToString();
                                TblApt.Address = Rd["Address"] == DBNull.Value ? null : Rd["Address"].ToString();
                                TblApt.Gender = Rd["Gender"] == DBNull.Value ? null : Rd["Gender"].ToString();
                                TblApt.Mobile = Rd["Mobile"] == DBNull.Value ? null : Rd["Mobile"].ToString();
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
                    string Sql = @"select * from [TblAppointment]";
                    Con.Open();

                    using (SqlCommand cmd = new SqlCommand(Sql, Con))
                    {                      
                        using (SqlDataReader Rd = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                        {
                            if (Rd.Read())
                            {
                                Dt.Load(Rd);
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
            return Dt;
        }

        public void Update()
        {
            try
            {
                string Constr = ConfigurationManager.ConnectionStrings["HospitalAdm"].ConnectionString;
                using (SqlConnection Con = new SqlConnection(Constr))
                {
                    string Sql = @"update [TblAppointment]
                                        set
                                      (
                                      [PatientName] =@PatientName
                                      ,[Email]      =@Email
                                      ,[Mobile]     =@Mobile
                                      ,[Address]    =@Address
                                      ,[Gender]     =@Gender
                                  where [AptId] =@AptId
                                        );";
                                     
                    
                    Con.Open();

                    using (SqlCommand cmd = new SqlCommand(Sql, Con))
                    {
                        cmd.Parameters.Add("@AptId", SqlDbType.BigInt,8).Value = AptId;
                        cmd.Parameters.Add("@PatientName", SqlDbType.NVarChar, 50).Value = PatientName == null ? (Object)DBNull.Value : PatientName;
                        cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 50).Value = Email == null ? (Object)DBNull.Value : Email;
                        cmd.Parameters.Add("@Mobile", SqlDbType.NVarChar, 50).Value = Mobile == null ? (Object)DBNull.Value : Mobile;
                        cmd.Parameters.Add("@Address", SqlDbType.NVarChar, 50).Value = Address == null ? (Object)DBNull.Value : Address;
                        cmd.Parameters.Add("@Gender", SqlDbType.NVarChar, 50).Value = Gender == null ? (Object)DBNull.Value : Gender;
                        cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime, 8).Value = CreatedDate == null ? (Object)DBNull.Value : CreatedDate;
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

        public long GetAppointments()
        {
            long appoint = 0;
            try
            {
                string Constr = ConfigurationManager.ConnectionStrings["HospitalAdm"].ConnectionString;
                using (SqlConnection Con = new SqlConnection(Constr))
                {
                    string Sql = @"SELECT COUNT(AptId) As Appointments
                                     FROM [TblAppointment]";
                    Con.Open();

                    using (SqlCommand cmd = new SqlCommand(Sql, Con))
                    {
                        using (SqlDataReader Rd = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                        {
                            if (Rd.Read())
                            {
                                appoint =  Convert.ToInt64(Rd["Appointments"]);
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
            return appoint;
        }

        public bool Delete(string Mobile)
        {
            bool IsDelete = false;
            try
            {
                string Constr = ConfigurationManager.ConnectionStrings["HospitalAdm"].ConnectionString;
                using (SqlConnection Con = new SqlConnection(Constr))
                {
                    string Sql = @"delete [TblAppointment] where [Mobile]=@Mobile";

                    Con.Open();

                    using (SqlCommand cmd = new SqlCommand(Sql, Con))
                    {
                       cmd.Parameters.Add("@Mobile", SqlDbType.NVarChar,50).Value = Mobile;
                      
                     int Msg = cmd.ExecuteNonQuery();
                        if (Msg >0)
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