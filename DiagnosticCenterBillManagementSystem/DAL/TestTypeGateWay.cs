using DiagnosticCenterBillManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace DiagnosticCenterBillManagementSystem.DAL
{
    public class TestTypeGateWay
    {
        string connectionString=WebConfigurationManager.ConnectionStrings["DiagnocisDB"].ConnectionString;
        public int SaveTestType(TestType testType )
        {
            int rowAffected;
            SqlConnection con= new SqlConnection(connectionString);
            string query = "INSERT INTO TestType(Name,InsertDate) VALUES('" + testType.TestTypeName + "',GETDATE())";
            SqlCommand cmd = new SqlCommand(query,con);
            con.Open();
            rowAffected=cmd.ExecuteNonQuery();
            con.Close();
            return rowAffected;
        }

        public List<TestType> GetAlltype()
        {
            SqlConnection con = new SqlConnection(connectionString);
            string query = "SELECT Id,Name FROM TestType";
            SqlCommand cmd = new SqlCommand(query, con);
            List<TestType> testTypes = new List<TestType>();
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if(reader.HasRows)
            {
                while(reader.Read())
                {
                    TestType testType = new TestType();
                    testType.Id =int.Parse( reader["Id"].ToString());
                    testType.TestTypeName = reader["Name"].ToString();
                    testTypes.Add(testType);
                }
                reader.Close();
            }
            con.Close();
            return testTypes;
        }
    }
}