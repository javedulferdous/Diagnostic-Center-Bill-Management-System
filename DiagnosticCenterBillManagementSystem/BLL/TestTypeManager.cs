using DiagnosticCenterBillManagementSystem.DAL;
using DiagnosticCenterBillManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiagnosticCenterBillManagementSystem.BLL
{
    public class TestTypeManager
    {
        TestTypeGateWay  testTypeGateway = new TestTypeGateWay();
        public int SaveTestType(TestType testType )
        {
            return testTypeGateway.SaveTestType(testType);
        }
        public List<TestType> GetAlltype()
        {
            return testTypeGateway.GetAlltype();
        }
    }
}