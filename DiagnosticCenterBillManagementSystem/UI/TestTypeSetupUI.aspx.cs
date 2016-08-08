using DiagnosticCenterBillManagementSystem.BLL;
using DiagnosticCenterBillManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DiagnosticCenterBillManagementSystem.UI
{
    public partial class TestTypeSetupUI : System.Web.UI.Page
    {
        TestTypeManager testTypeManager = new TestTypeManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {

               
            }
            List<TestType> testTypes = testTypeManager.GetAlltype();
            typeNameGridView.DataSource = testTypes;
            typeNameGridView.DataBind();

        }

        protected void typeNameButton_Click(object sender, EventArgs e)
        {
            TestType testType = new TestType();
            testType.TestTypeName = typeNameTextBox.Text;

            int rowAffected = testTypeManager.SaveTestType(testType);
            if (rowAffected > 0)
            {
                errorMessageLabel.Text = "Test type Save successfuly.";
            }
            else
            {
                errorMessageLabel.Text = "Test type Save fail.";
            }
            typeNameTextBox.Text = string.Empty;
            typeNameTextBox.Focus();
        }

        protected void typeNameGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            testTypeManager.GetAlltype();
            typeNameGridView.PageIndex = e.NewPageIndex;
            typeNameGridView.DataBind();
        }

    }
}