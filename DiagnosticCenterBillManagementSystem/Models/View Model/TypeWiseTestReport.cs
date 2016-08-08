using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Org.BouncyCastle.Utilities.IO.Pem;

namespace DiagnosticCenterBillManagementSystem.Models.View_Model
{
    public class TypeWiseTestReport
    {
        public string Name { get; set; }
        public DateTime InsertDate { get; set; }
        public int Count { get; set; }
        public decimal Total { get; set; }

    }
}