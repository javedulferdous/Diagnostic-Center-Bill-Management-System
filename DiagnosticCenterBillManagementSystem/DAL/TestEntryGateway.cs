using System.Data;
using System.Web.UI.WebControls;
using DiagnosticCenterBillManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace DiagnosticCenterBillManagementSystem.DAL
{
    public class TestEntryGateway
    {
        string connectionString = WebConfigurationManager.ConnectionStrings["DiagnocisDB"].ConnectionString;
        public List<TestSetup> GetAlltestSetup()
        {
            SqlConnection con = new SqlConnection(connectionString);
            string query = "SELECT Id,TestName,Fee FROM TestSetup";
            SqlCommand cmd = new SqlCommand(query, con);
            List<TestSetup> testSetups = new List<TestSetup>();
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    TestSetup TestSetup = new TestSetup();
                    TestSetup.Id = int.Parse(reader["Id"].ToString());
                    TestSetup.TestName = reader["TestName"].ToString();
                    TestSetup.Fee =Convert.ToDecimal( reader["Fee"].ToString());
                    testSetups.Add(TestSetup);
                }
                reader.Close();
            }
            con.Close();
            return testSetups;
        }

        public TestSetup GetTestSetup(string testName)
        {
            SqlConnection con = new SqlConnection(connectionString);
            string query = "SELECT Id,TestName,Fee FROM TestSetup WHERE Id='" + testName + "' ";
            SqlCommand cmd = new SqlCommand(query, con);
            TestSetup testSetup = null;
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    testSetup = new TestSetup();
                    testSetup.Id = int.Parse(reader["Id"].ToString());
                    testSetup.TestName = reader["TestName"].ToString();
                    testSetup.Fee = Convert.ToDecimal(reader["Fee"].ToString());
                }
                reader.Close();
            }
            con.Close();
            return testSetup;
        }

        public int SavePatient(Patient patient)
        {
            
                      
            SqlConnection con = new SqlConnection(connectionString);
            string query = @"INSERT INTO Patient(PatientName,DateOfBirth,BillNo,Mobile,InsertDate) 
                            VALUES('" + patient.PatientName + "','" + patient.DateOfBirth + "','" + patient.BillNumber + "','" + patient.MobileNo + "',GETDATE());SELECT SCOPE_IDENTITY()";
            SqlCommand cmd=new SqlCommand(query,con);
            //cmd.Connection = con;
            //cmd.CommandText = query;
            int patientId;
            cmd.CommandType=CommandType.Text;
            con.Open();
            patientId =Convert.ToInt32( cmd.ExecuteScalar());
            con.Close();
            return patientId;
        }
        public int UpdatePaymentStatus(string billNo, string mobileNo)
        {
        
            SqlConnection con = new SqlConnection(connectionString);        
            string query = "UPDATE Patient SET PaymentStatus='True' WHERE BillNo='" + billNo + "' OR MobileNo='" + mobileNo + "'";
            SqlCommand command = new SqlCommand(query, con);
            con.Open();
            int rowAffected = command.ExecuteNonQuery();
            con.Close();
            return rowAffected;
        }
    }
}