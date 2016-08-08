using DiagnosticCenterBillManagementSystem.Models;
using DiagnosticCenterBillManagementSystem.View_Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace DiagnosticCenterBillManagementSystem.DAL
{
    public class TestSetupGateway
    {
        string connectionString = WebConfigurationManager.ConnectionStrings["DiagnocisDB"].ConnectionString;
        public List<TestType> GetAllTestType()
        {
            SqlConnection con = new SqlConnection(connectionString);
            string query = "SELECT * FROM TestType";
            SqlCommand cmd = new SqlCommand(query,con);
            List<TestType> testtypeList = new List<TestType>();
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    TestType testType = new TestType();
                    testType.Id=int.Parse( reader["Ïd"].ToString());
                    testType.TestTypeName = reader["TestTypeName"].ToString();
                    testtypeList.Add(testType);
                }
                reader.Close();
            }
            con.Close();
            return testtypeList;
        }

        public int SaveTestSetup(TestSetup testSetup)
        {
            int rowAffected;
            SqlConnection con = new SqlConnection(connectionString);
            string query = "INSERT INTO TestSetup(TestName,Fee,TestTypeId,InsertDate) VALUES('" + testSetup.TestName + "','" + testSetup.Fee + "','" + testSetup.TestTypeId + "',GETDATE())";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            rowAffected = cmd.ExecuteNonQuery();
            con.Close();
            return rowAffected;
        }

        //public List<TestSetup> GetAllTestSetup()
        //{
        //    SqlConnection con = new SqlConnection(connectionString);
        //    //string query = "select ts.Id,ts.TestName,ts.Fee,tt.Name as Type from TestSetup ts inner join TestType tt on tt.Id=ts.TestTypeId";
        //    string query = "select TestName,Fee,Name from TestSetup_view";
        //    SqlCommand cmd = new SqlCommand(query, con);
        //    List<TestSetup> testSetupList = new List<TestSetup>();
        //    con.Open();
        //    SqlDataReader reader = cmd.ExecuteReader();
        //    if (reader.HasRows)
        //    {
        //        while (reader.Read())
        //        {
        //            TestSetup testSetup = new TestSetup();
        //            testSetup.Id = int.Parse(reader["Id"].ToString());
        //            testSetup.TestName = reader["TestName"].ToString();
        //            testSetup.Fee =Convert.ToDecimal( reader["Fee"].ToString());
        //            testSetup.TestTypeId =Convert.ToInt32( reader["Type"].ToString());
        //            testSetupList.Add(testSetup);
        //        }
        //        reader.Close();
        //    }
        //    con.Close();
        //    return testSetupList;
        //}
        public List<TestSetupViewModel> GetAllTestSetup()
        {
            SqlConnection con = new SqlConnection(connectionString);
            string query = "select TestName,Fee,Name from TestSetup_view";
            SqlCommand cmd = new SqlCommand(query, con);
            List<TestSetupViewModel> testSetupListView = new List<TestSetupViewModel>();
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    TestSetupViewModel testSetupView = new TestSetupViewModel();
                    testSetupView.TestName = reader["TestName"].ToString();
                    testSetupView.Fee = Convert.ToDecimal(reader["Fee"].ToString());
                    testSetupView.Name = reader["Name"].ToString();
                    testSetupListView.Add(testSetupView);
                }
                reader.Close();
            }
            con.Close();
            return testSetupListView;
        }
    }
}