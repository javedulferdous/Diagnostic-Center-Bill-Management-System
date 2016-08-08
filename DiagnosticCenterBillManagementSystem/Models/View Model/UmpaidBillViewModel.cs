using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiagnosticCenterBillManagementSystem.Models.View_Model
{
    public class UmpaidBillViewModel
    {
        public string PatientName { get; set; }
        public String BillNo { get; set; }
        public string MobileNo { get; set; }
        public decimal TotalAmount { get; set; }
    }
}