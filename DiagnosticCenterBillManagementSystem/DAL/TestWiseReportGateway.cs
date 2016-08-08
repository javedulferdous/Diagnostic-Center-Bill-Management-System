using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using DiagnosticCenterBillManagementSystem.Models.View_Model;

namespace DiagnosticCenterBillManagementSystem.DAL
{
    public class TestWiseReportGateway
    {
        string connectionString = WebConfigurationManager.ConnectionStrings["DiagnocisDB"].ConnectionString;
        public List<DateWiseTestReport> GetDateWiseTestReport(string startDate, string endDate)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string query = @"SELECT  TestName,SUM(TotalCount) as TotalCount,SUM(Fee) as TotalFee  from DateWiseTestReport WHERE InsertDate BETWEEN '" + startDate + "' AND '" + endDate + "' group by TestName";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<DateWiseTestReport> testWiseReportList = new List<DateWiseTestReport>();
            while (reader.Read())
            {
                DateWiseTestReport testReport = new DateWiseTestReport();

                testReport.TestName = reader["TestName"].ToString();
                testReport.TotalCount = Convert.ToInt32(reader["TotalCount"].ToString());
                testReport.TotalFee = Convert.ToDecimal(reader["TotalFee"].ToString());

                testWiseReportList.Add(testReport);
            }



            reader.Close();
            connection.Close();

            return testWiseReportList;

        }
    }
}