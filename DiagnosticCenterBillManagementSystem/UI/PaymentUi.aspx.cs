using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using DiagnosticCenterBillManagementSystem.BLL;
using DiagnosticCenterBillManagementSystem.Models;
using Label = System.Windows.Forms.Label;

namespace DiagnosticCenterBillManagementSystem.UI
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private double amount, newAmount;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private PaymentManager paymentManager = new PaymentManager();

        protected void searchButton_Click(object sender, EventArgs e)
        {

            if (billNoTextBox.Text == String.Empty)
            {
                MessageBox.Show("Please provide Mobile No");
                return;
            }

            


            TestEntry testRequest = paymentManager.SearchByBillorMobile(billNoTextBox.Text);

            if (testRequest == null)
            {
                MessageBox.Show("Please provide Mobile No");
            }
            else
            {
                newAmount = Convert.ToDouble(testRequest.TotalAmount);
                totalFeeLabel.Text = newAmount.ToString();
                billDateLabel.Text = testRequest.DueDate.ToShortDateString();
                amount = Convert.ToDouble(totalFeeLabel.Text);

                if ((newAmount - amount) == 0)
                {
                    dueAmountLabel.Text = newAmount.ToString();
                    paidAmountLabel.Text = (newAmount - amount).ToString();
                }
                else if ((newAmount - amount) < 0)
                {
                    double temp = newAmount - amount;
                    dueAmountLabel.Text = temp.ToString();
                    paidAmountLabel.Text = temp.ToString();
                }
                SearchTestByMobOrBill();
            }
        }

        protected void payButton_Click(object sender, EventArgs e)
        {
            paymentManager.UpdatePaymentStatus(billNoTextBox.Text);
            MessageBox.Show("Payment Successful!");
        }

        private void SearchTestByMobOrBill()
        {
            string BollOrMpbNo = billNoTextBox.Text;
            List<TestSetup> aTestSetups = paymentManager.GetAllSetup(BollOrMpbNo);

            typeNameGridView.DataSource = aTestSetups;
            typeNameGridView.DataBind();
        }

        private decimal total = 0;
        protected void typeNameGridView_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                total += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Fee"));
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                //Label totaLabel = (Label)e.Row.FindControl("totalamountLabel");
                //totaLabel.Text = total.ToString();
            }
            totalFeeLabel.Text = total.ToString();
        }


    }
}