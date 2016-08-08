using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using DiagnosticCenterBillManagementSystem.Models;
using System.Web.Configuration;
using DiagnosticCenterBillManagementSystem.Models.View_Model;

namespace DiagnosticCenterBillManagementSystem.DAL
{
    public class TypeWiseReportGateway
    {
        string connectionString = WebConfigurationManager.ConnectionStrings["DiagnocisDB"].ConnectionString;
        public List<TypeWiseTestReport> GetAllTypeWiseReport(string fromDate, string toDate)
        {
            SqlConnection con = new SqlConnection(connectionString);
            string query = @"SELECT  Name,SUM(Total) as Total,SUM(Count) as Count FROM  TypeWiseTestReport 
                             WHERE InsertDate between '" + fromDate + "' and '" + toDate + "' GROUP BY Name";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<TypeWiseTestReport> typeWiseTestReports = new List<TypeWiseTestReport>();
            while (reader.Read())
            {
                TypeWiseTestReport typeWiseTest = new TypeWiseTestReport();
                typeWiseTest.Name = (reader["Name"].ToString());
                typeWiseTest.Total = Convert.ToDecimal(reader["Total"].ToString());
                typeWiseTest.Count = Convert.ToInt32(reader["Count"].ToString());
                typeWiseTestReports.Add(typeWiseTest);
            }
            reader.Close();
            con.Close();
            return typeWiseTestReports;
        }
    }
}