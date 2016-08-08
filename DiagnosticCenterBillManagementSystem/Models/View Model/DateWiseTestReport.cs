using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiagnosticCenterBillManagementSystem.Models.View_Model
{
    public class DateWiseTestReport
    {
        public string TestName { get; set; }
        public int TotalCount { get; set; }
        public decimal TotalFee { get; set; }
    }
}