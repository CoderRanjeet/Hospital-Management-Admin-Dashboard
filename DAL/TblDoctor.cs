using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;


namespace HospitalManagementAdmin.DAL
{
    public class TblDoctor
    {
         public long DocId { get;set;}
         public string FullName   {get;set;}
         public string Email      {get;set;}
         public DateTime? DOB        {get;set;}
         public string Gender     {get;set;}
         public string Address    {get;set;}
         public string City       {get;set;}
         public string State      {get;set;}
         public string PostalCode {get;set;}
         public string Mobile { get;set;}
         public string Photo      {get;set;}
         public int CreatedBy  {get;set;}
         public DateTime? CreatedDate { get; set; }

        public void Add()
        {
            try
            {
                string Constr = ConfigurationManager.ConnectionStrings["HospitalAdm"].ConnectionString;
                using (SqlConnection Con = new SqlConnection(Constr))
                {
                    string Sql = @"insert into [TblDoctor]
                                      (
                                        [FullName]
                                       ,[Email]
                                       ,[DOB]
                                       ,[Gender]
                                       ,[Address]
                                       ,[City]
                                       ,[State]
                                       ,[PostalCode]
                                       ,[Mobile]
                                       ,[Photo]
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
                                       ,@State
                                       ,@PostalCode
                                       ,@Mobile
                                       ,@Photo
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
                        cmd.Parameters.Add("@State", SqlDbType.NVarChar, 50).Value = State == null ? (Object)DBNull.Value : State;
                        cmd.Parameters.Add("@PostalCode", SqlDbType.NVarChar, 50).Value = PostalCode == null ? (Object)DBNull.Value : PostalCode;
                        cmd.Parameters.Add("@Mobile", SqlDbType.NVarChar, 50).Value = Mobile == null ? (Object)DBNull.Value : Mobile;
                        cmd.Parameters.Add("@Photo", SqlDbType.NVarChar, 50).Value = Photo == null ? (Object)DBNull.Value : Photo;
                        cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = CreatedBy;
                        cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime, 8).Value = CreatedDate == null ? (Object)DBNull.Value : CreatedDate;
                        DocId = Convert.ToInt64(cmd.ExecuteScalar());
                        Con.Close();
                    }
                }
            }
            catch (Exception Ex)
            {
                var Msg = Ex.Message;
            }
        }

        public static TblDoctor Get(string Email)
        {
            TblDoctor TblApt = new TblDoctor();
            try
            {
                string Constr = ConfigurationManager.ConnectionStrings["HospitalAdm"].ConnectionString;
                using (SqlConnection Con = new SqlConnection(Constr))
                {
                    string Sql = @"select * from [TblDoctor] where [Email]=@Email";
                    Con.Open();

                    using (SqlCommand cmd = new SqlCommand(Sql, Con))
                    {
                        cmd.Parameters.Add("@Email", SqlDbType.NVarChar,50).Value = Email;
                        using (SqlDataReader Rd = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                        {
                            if (Rd.Read())
                            {
                                TblApt.FullName = Rd["FullName"] == DBNull.Value ? null : Rd["FullName"].ToString();
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
                    string Sql = @"select * from [TblDoctor]";
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
                    string Sql = @"update [TblDoctor]
                                        set
                                      (
                                       [FullName] =@FullName
                                      ,[Email]      =@Email
                                      ,[Mobile]     =@Mobile
                                      ,[Address]    =@Address
                                      ,[Gender]     =@Gender
                                      where [DocId] =@DocId
                                        );";
                    Con.Open();

                    using (SqlCommand cmd = new SqlCommand(Sql, Con))
                    {
                        cmd.Parameters.Add("@DocId", SqlDbType.BigInt, 8).Value = DocId;
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

        public long GetDoctors()
        {
            long appoint = 0;
            try
            {
                string Constr = ConfigurationManager.ConnectionStrings["HospitalAdm"].ConnectionString;
                using (SqlConnection Con = new SqlConnection(Constr))
                {
                    string Sql = @"SELECT COUNT(DocId) As Doctors
                                     FROM [TblDoctor]";
                    Con.Open();

                    using (SqlCommand cmd = new SqlCommand(Sql, Con))
                    {
                        using (SqlDataReader Rd = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                        {
                            if (Rd.Read())
                            {
                                appoint = Convert.ToInt64(Rd["Doctors"]);
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

        public bool Delete(string Email)
        {
            bool IsDelete = false;
            try
            {
                string Constr = ConfigurationManager.ConnectionStrings["HospitalAdm"].ConnectionString;
                using (SqlConnection Con = new SqlConnection(Constr))
                {
                    string Sql = @"delete [TblDoctor] where [Email]=@Email";

                    Con.Open();

                    using (SqlCommand cmd = new SqlCommand(Sql, Con))
                    {
                        cmd.Parameters.Add("@Email", SqlDbType.NVarChar,50).Value = Email;

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