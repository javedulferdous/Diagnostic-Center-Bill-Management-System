using DiagnosticCenterBillManagementSystem.DAL;
using DiagnosticCenterBillManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DiagnosticCenterBillManagementSystem.Models.View_Model;

namespace DiagnosticCenterBillManagementSystem.BLL
{
    
    public class TestWiseReportManager
    {
        
        TestWiseReportGateway testGateway = new TestWiseReportGateway();

        internal bool ValidateInput(string startDate, string endDate)
        {
            if (startDate == String.Empty)
            {
                throw new Exception("Select a Date");
            }

            else if (endDate == String.Empty)
            {
                throw new Exception("Select a Date");
            }

            else if (Convert.ToDateTime(startDate) > DateTime.Now)
            {
                throw new Exception("Search Date Cannot Go Beyond Current Date!");
            }

            else if (Convert.ToDateTime(endDate) > DateTime.Now)
            {
                throw new Exception("Search Date Cannot Go Beyond Current Date!");
            }

            return true;
        }

        internal List<DateWiseTestReport> GetDateWiseTestReport(string startDate, string endDate)
        {
            try
            {
                return testGateway.GetDateWiseTestReport(startDate, endDate);
            }

            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }
    }
}