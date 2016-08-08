using DiagnosticCenterBillManagementSystem.DAL;
using DiagnosticCenterBillManagementSystem.Models;
using DiagnosticCenterBillManagementSystem.View_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiagnosticCenterBillManagementSystem.BLL
{
    public class TestSetupManager
    {
        TestTypeGateWay testTypegateway = new TestTypeGateWay();
        TestSetupGateway testSetupGateway = new TestSetupGateway();
        public List<TestType> GetAllTestType()
        {
            return testTypegateway.GetAlltype();
        }

        public int SaveTestSetup(TestSetup testSetup)
        {
            return testSetupGateway.SaveTestSetup(testSetup);
        }

        public List<TestSetupViewModel> GetAllTestSetup()
        {
            return testSetupGateway.GetAllTestSetup();
        }

    }
}