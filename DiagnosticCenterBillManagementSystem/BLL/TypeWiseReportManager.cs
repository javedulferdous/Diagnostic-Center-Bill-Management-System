using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DiagnosticCenterBillManagementSystem.DAL;
using DiagnosticCenterBillManagementSystem.Models;
using DiagnosticCenterBillManagementSystem.Models.View_Model;

namespace DiagnosticCenterBillManagementSystem.BLL
{
    public class TypeWiseReportManager
    {
        TypeWiseReportGateway typeWiseReportGateway = new TypeWiseReportGateway();
        public List<TypeWiseTestReport> GetAllTypeWiseReport(string fromDate, string toDate)
        {
            return typeWiseReportGateway.GetAllTypeWiseReport(fromDate, toDate);
        }

    }
}