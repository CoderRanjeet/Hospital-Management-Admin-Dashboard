using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace HospitalManagementAdmin.DAL
{
    public class TblPatient
    {
      public long  PatId      {get;set;}
      public string FullName { get;set;}
      public string  Email      {get;set;}
      public string  Mobile     {get;set;}
      public DateTime?  DOB        {get;set;}
      public string  City       {get;set;}
      public string  Address    {get;set;}
      public string  Gender     {get;set;}
      public int  CreatedBy  {get;set;}
      public DateTime? CreatedDate { get; set; }


        public void Add()
        {
            try
            {
                string Constr = ConfigurationManager.ConnectionStrings["HospitalAdm"].ConnectionString;
                using (SqlConnection Con = new SqlConnection(Constr))
                {
                    string Sql = @"insert into [TblPatient]
                                      (
                                        [FullName]
                                       ,[Email]
                                       ,[DOB]
                                       ,[Gender]
                                       ,[Address]
                                       ,[City]
                                       ,[Mobile]                                     
                                       ,[CreatedBy]
                                       ,[CreatedDate]
                                       )
                                       values
                                        (
                                        @FullName
                                       ,@Email
                                       ,@DOB
                                       ,@Gender
                                       ,@Address
                                       ,@City
                                       ,@Mobile
                                       ,@CreatedBy
                                       ,@CreatedDate

                                       );";
                    Sql += "select scope_identity();";
                    Con.Open();

                    using (SqlCommand cmd = new SqlCommand(Sql, Con))
                    {
                        cmd.Parameters.Add("@FullName", SqlDbType.NVarChar, 50).Value = FullName == null ? (Object)DBNull.Value : FullName;
                        cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 50).Value = Email == null ? (Object)DBNull.Value : Email;
                        cmd.Parameters.Add("@DOB", SqlDbType.DateTime, 8).Value = DOB == null ? (Object)DBNull.Value : DOB;
                        cmd.Parameters.Add("@Gender", SqlDbType.NVarChar, 50).Value = Gender == null ? (Object)DBNull.Value : Gender;
                        cmd.Parameters.Add("@Address", SqlDbType.NVarChar, 50).Value = Address == null ? (Object)DBNull.Value : Address;
                        cmd.Parameters.Add("@City", SqlDbType.NVarChar, 50).Value = City == null ? (Object)DBNull.Value : City;   
                        cmd.Parameters.Add("@Mobile", SqlDbType.NVarChar, 50).Value = Mobile == null ? (Object)DBNull.Value : Mobile;               
                        cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = CreatedBy;
                        cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime, 8).Value = CreatedDate == null ? (Object)DBNull.Value : CreatedDate;
                        PatId = Convert.ToInt64(cmd.ExecuteScalar());
                        Con.Close();
                    }
                }
            }
            catch (Exception Ex)
            {
                var Msg = Ex.Message;
            }
        }

        public long GetPatients()
        {
            long appoint = 0;
            try
            {
                string Constr = ConfigurationManager.ConnectionStrings["HospitalAdm"].ConnectionString;
                using (SqlConnection Con = new SqlConnection(Constr))
                {
                    string Sql = @"SELECT COUNT(PatId) As Patients
                                     FROM [TblPatient]";
                    Con.Open();

                    using (SqlCommand cmd = new SqlCommand(Sql, Con))
                    {
                        using (SqlDataReader Rd = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                        {
                            if (Rd.Read())
                            {
                                appoint = Convert.ToInt64(Rd["Patients"]);
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

        public static TblDoctor Get(long Id)
        {
            TblDoctor TblApt = new TblDoctor();
            try
            {
                string Constr = ConfigurationManager.ConnectionStrings["HospitalAdm"].ConnectionString;
                using (SqlConnection Con = new SqlConnection(Constr))
                {
                    string Sql = @"select * from [TblPatient] where [PatId]=@PatId";
                    Con.Open();

                    using (SqlCommand cmd = new SqlCommand(Sql, Con))
                    {
                        cmd.Parameters.Add("@DocId", SqlDbType.BigInt, 8).Value = Id;
                        using (SqlDataReader Rd = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                        {
                            TblApt.FullName = Rd["FullName"] == DBNull.Value ? null : Rd["FullName"].ToString();
                            TblApt.Email = Rd["Email"] == DBNull.Value ? null : Rd["Email"].ToString();
                            TblApt.Address = Rd["Address"] == DBNull.Value ? null : Rd["Address"].ToString();
                            TblApt.Gender = Rd["Gender"] == DBNull.Value ? null : Rd["Gender"].ToString();
                            TblApt.Mobile = Rd["Mobile"] == DBNull.Value ? null : Rd["Mobile"].ToString();
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
                    string Sql = @"select * from [TblPatient]";
                    Con.Open();

                    using (SqlCommand cmd = new SqlCommand(Sql, Con))
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
                    string Sql = @"update [TblPatient]
                                        set
                                      (
                                       [FullName] =@FullName
                                      ,[Email]      =@Email
                                      ,[Mobile]     =@Mobile
                                      ,[Address]    =@Address
                                      ,[Gender]     =@Gender
                                      where [PatId] =@PatId
                                        );";
                    Con.Open();

                    using (SqlCommand cmd = new SqlCommand(Sql, Con))
                    {
                        cmd.Parameters.Add("@DocId", SqlDbType.BigInt, 8).Value = PatId;
                        cmd.Parameters.Add("@FullName", SqlDbType.NVarChar, 50).Value = FullName == null ? (Object)DBNull.Value : FullName;
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

        public bool Delete(long Id)
        {
            bool IsDelete = false;
            try
            {
                string Constr = ConfigurationManager.ConnectionStrings["HospitalAdm"].ConnectionString;
                using (SqlConnection Con = new SqlConnection(Constr))
                {
                    string Sql = @"delete [TblPatient] where [PatId]=@PatId";

                    Con.Open();

                    using (SqlCommand cmd = new SqlCommand(Sql, Con))
                    {
                        cmd.Parameters.Add("@DocId", SqlDbType.BigInt, 8).Value = PatId;

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