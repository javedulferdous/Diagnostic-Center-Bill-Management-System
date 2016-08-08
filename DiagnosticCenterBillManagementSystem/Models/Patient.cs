using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiagnosticCenterBillManagementSystem.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public string PatientName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string MobileNo { get; set; }
        public int TestId { get; set; }
        public string BillNumber { get; set; }

        public string GetBillNo()
        {
            Random rnd = new Random();
            int value = rnd.Next(1000, 9999);
            string BillNo = "DBS"+ value.ToString();
            BillNumber = BillNo;
            return BillNumber;
        }

       
    }
}