using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using DiagnosticCenterBillManagementSystem.Models;

namespace DiagnosticCenterBillManagementSystem.DAL
{
    public class PaymentGateway
    {
        string connectionString = WebConfigurationManager.ConnectionStrings["DiagnocisDB"].ConnectionString;
        public int UpdatePaymentStatus(string billNo)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string query = "UPDATE Patient SET PaymentStatus='True' WHERE BillNo='" + billNo + "'";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
        }

        public TestEntry SearchByBillorMobile(string mobileNo)
        {
            string query = @"SELECT *  FROM Patient INNER JOIN
                         PatientTest ON Patient.Id = PatientTest.PatientId INNER JOIN
                         TestSetup ON PatientTest.TestSetupId = TestSetup.Id  WHERE Patient.Mobile='" + mobileNo + "' or  Patient.BillNo='" + mobileNo + "'";
            SqlConnection connection = new SqlConnection(connectionString);

            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            TestEntry testRequest = null;
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    testRequest = new TestEntry();

                    //testRequest.Id = Convert.ToInt32(reader["Id"].ToString());
                    //testRequest.PatientName = reader["PatientName"].ToString();
                    //testRequest.MobileNo = reader["Mobile"].ToString();

                    testRequest.TotalAmount = Convert.ToDecimal(reader["Fee"].ToString());
                    testRequest.DueDate = Convert.ToDateTime(reader["InsertDate"].ToString());

                }
                reader.Close();
            }
            connection.Close();
            return testRequest;
        }


        public bool IsPatientTestExists(int patientId, int testId)
        {
            string query = "SELECT * FROM PatientTests WHERE PatientId=" + patientId + " AND TestId=" + testId;
            SqlConnection connection = new SqlConnection(connectionString);

            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            bool isPatientTestExist = false;
            if (reader.HasRows)
            {
                isPatientTestExist = true;
            }
            reader.Close();
            connection.Close();
            return isPatientTestExist;
        }

        public int SavePatientTests(int patientId, int testId, string requestDate)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "INSERT INTO PatientTests(PatientId,TestId,RequestDate) VALUES(" + patientId + "," + testId + ",'" + requestDate + "')";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
        }

        public List<TestSetup> GetAllSetup(string billNoOrMob)
        {
            SqlConnection con = new SqlConnection(connectionString);
            string query = @"SELECT TestSetup.TestName,TestSetup.Fee FROM Patient  
                                INNER JOIN PatientTest ON Patient.Id = PatientTest.PatientId 
                                INNER JOIN TestSetup ON PatientTest.TestSetupId = TestSetup.Id  
                            WHERE Patient.BillNo='" + billNoOrMob + "' or Patient.Mobile='" + billNoOrMob + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            List<TestSetup> testSetups = new List<TestSetup>();
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    TestSetup testSetup = new TestSetup();
                    testSetup.TestName = reader["TestName"].ToString();
                    testSetup.Fee =Convert.ToDecimal( reader["Fee"]);
                    testSetups.Add(testSetup);
                }
                reader.Close();
            }
            con.Close();
            return testSetups;
        }

       

    }
}