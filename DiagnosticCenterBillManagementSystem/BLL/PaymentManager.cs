using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DiagnosticCenterBillManagementSystem.DAL;
using DiagnosticCenterBillManagementSystem.Models;

namespace DiagnosticCenterBillManagementSystem.BLL
{
    public class PaymentManager
    {
        PaymentGateway paymentGateway = new PaymentGateway();

        public TestEntry SearchByBillorMobile(string mobileNo)
        {
            return paymentGateway.SearchByBillorMobile(mobileNo);
        }

        public int UpdatePaymentStatus(string billNo)
        {
            return paymentGateway.UpdatePaymentStatus(billNo);
        }

        public bool IsExistMobileNo(String mobileNo)
        {
            if (SearchByBillorMobile(mobileNo) != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<TestSetup> GetAllSetup(string billNoOrMob)
        {
            return paymentGateway.GetAllSetup(billNoOrMob);
        }

    }
}