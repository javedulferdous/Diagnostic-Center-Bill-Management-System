using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using DiagnosticCenterBillManagementSystem.Models.View_Model;

namespace DiagnosticCenterBillManagementSystem.DAL
{
    public class UnpaidBillGateway
    {
        string connectionString = WebConfigurationManager.ConnectionStrings["DiagnocisDB"].ConnectionString;
        public List<UmpaidBillViewModel> UnpaidBillReport(string fromDate, string toDate)
        {
            SqlConnection con = new SqlConnection(connectionString);
            string query = @"SELECT  PatientName,BillNo,Mobile,SUM(Total) as Total FROM  unpaidBillView 
                             WHERE InsertDate between '" + fromDate + "' and '" + toDate + "'Group By PatientName,BillNO,Mobile ";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<UmpaidBillViewModel> unpaBillViewModels = new List<UmpaidBillViewModel>();
            while (reader.Read())
            {
                UmpaidBillViewModel unpaidViewModel = new UmpaidBillViewModel();
                unpaidViewModel.PatientName = (reader["PatientName"].ToString());
                unpaidViewModel.BillNo = reader["BillNo"].ToString();
                unpaidViewModel.MobileNo = reader["Mobile"].ToString();
                unpaidViewModel.TotalAmount =Convert.ToDecimal(reader["Total"].ToString());
                unpaBillViewModels.Add(unpaidViewModel);
            }
            reader.Close();
            con.Close();
            return unpaBillViewModels;
        }
    }
}