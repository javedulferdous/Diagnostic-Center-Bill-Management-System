using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Windows.Forms;
using DiagnosticCenterBillManagementSystem.DAL;
using DiagnosticCenterBillManagementSystem.Models.View_Model;

namespace DiagnosticCenterBillManagementSystem.BLL
{
    public class UnpaidBillManager
    {
        UnpaidBillGateway unpaidBillGateway = new UnpaidBillGateway();
        public List<UmpaidBillViewModel> UnpaidBillReport(string fromDate, string toDate)
        {
            return unpaidBillGateway.UnpaidBillReport(fromDate, toDate);
        }
    }
}