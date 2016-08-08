using DiagnosticCenterBillManagementSystem.DAL;
using DiagnosticCenterBillManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiagnosticCenterBillManagementSystem.BLL
{
    public class TestEntryManager
    {
        TestEntryGateway testSetupGateway = new TestEntryGateway();
        
        public List<TestSetup> GetAlltestSetup()
        {
            return testSetupGateway.GetAlltestSetup();
        }

        public TestSetup GetTestSetup(string testName)
        {
            return testSetupGateway.GetTestSetup(testName);
        }

        public int SavePatient(Patient patient)
        {
            return testSetupGateway.SavePatient(patient);
        }

        public int UpdatePaymentStatus(string billNo, string mobileNo)
        {
            return testSetupGateway.UpdatePaymentStatus(billNo, mobileNo);
        }
    }
}