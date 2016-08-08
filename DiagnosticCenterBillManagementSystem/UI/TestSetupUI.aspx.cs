using DiagnosticCenterBillManagementSystem.BLL;
using DiagnosticCenterBillManagementSystem.Models;
using DiagnosticCenterBillManagementSystem.View_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DiagnosticCenterBillManagementSystem.UI
{
    public partial class TestSetupUI : System.Web.UI.Page
    {
        TestSetupManager testSetupManager = new TestSetupManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadAllTestType();
                
            }

            List<TestSetupViewModel> allTestSetup = testSetupManager.GetAllTestSetup();
           testSetupGridView.DataSource = allTestSetup;
           testSetupGridView.DataBind();
            
        }

        private void LoadAllTestType()
        {
            //TestSetupManager testSetupManager = new TestSetupManager();
            List<TestType> allTestType = testSetupManager.GetAllTestType();
            testTypeDropDownList.DataSource = allTestType;
            testTypeDropDownList.DataTextField = "TestTypeName";
            testTypeDropDownList.DataValueField = "Id";
            testTypeDropDownList.DataBind();
            testTypeDropDownList.Items.Insert(0, "------Select------");
        }

        protected void testSetupButton_Click(object sender, EventArgs e)
        {
            TestSetup testSetup = new TestSetup();
            testSetup.TestName = testNameTextBox.Text;
            testSetup.Fee =Convert.ToDecimal( feeTextBox.Text.ToString());
            testSetup.TestTypeId = testTypeDropDownList.SelectedIndex;

            int rowAffected = testSetupManager.SaveTestSetup(testSetup);

            if (rowAffected > 0)
            {
                errorMessageLabel.Text = "Save Successfuly.";
            }
            else
            {
                errorMessageLabel.Text = "Save fail.";
            }
            ClearAll();
        }
        private void ClearAll()
        {
            testNameTextBox.Text = string.Empty;
            feeTextBox.Text = string.Empty;
            testTypeDropDownList.SelectedIndex = 0;
            testNameTextBox.Focus();
        }

        protected void testSetupGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            testSetupManager.GetAllTestSetup();
            testSetupGridView.PageIndex = e.NewPageIndex;
            testSetupGridView.DataBind();
        }
    }
}