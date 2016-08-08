using System.Data;
using DiagnosticCenterBillManagementSystem.BLL;
using DiagnosticCenterBillManagementSystem.DAL;
using DiagnosticCenterBillManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Configuration;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace DiagnosticCenterBillManagementSystem.UI
{
    public partial class TestRequestUI : System.Web.UI.Page
    {
        TestEntryManager testEntryManager = new TestEntryManager();
        TestEntryGateway testEntryGateway = new TestEntryGateway();

        private string patientName, mobileNumber, billNumber;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadAllTestSetup();
            }
            CreateGrid();
        }

        private void CreateGrid()
        {
            if (!this.IsPostBack)
            {
                DataTable dt = new DataTable();
                dt.Columns.AddRange(new DataColumn[3] { new DataColumn("Id"), new DataColumn("Test"), new DataColumn("Fee") });
                ViewState["TestEntry"] = dt;
                this.BindGride();
            }
        }

        protected void BindGride()
        {
            allTestRequestGridView.DataSource = (DataTable)ViewState["TestEntry"];
            allTestRequestGridView.DataBind();
        }
        private void LoadAllTestSetup()
        {
            List<TestSetup> allTestEntry = testEntryManager.GetAlltestSetup();
            selectTestDropDownList.DataSource = allTestEntry;
            selectTestDropDownList.DataTextField = "TestName";
            selectTestDropDownList.DataValueField = "Id";
            selectTestDropDownList.DataBind();
            selectTestDropDownList.Items.Insert(0, "------Select------");
        }

        protected void aDDButton_Click(object sender, EventArgs e)
        {

            DataTable dt = (DataTable)ViewState["TestEntry"];
            dt.Rows.Add(testIdHiddenField.Value, selectTestDropDownList.SelectedItem, fEETextBox.Text.Trim());
            ViewState["TestEntry"] = dt;
            this.BindGride();

            selectTestDropDownList.SelectedIndex = 0;
            fEETextBox.Text = string.Empty;
            testIdHiddenField.Value = string.Empty;
        }

        protected void selectTestDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            TestSetup testSetup = testEntryManager.GetTestSetup(selectTestDropDownList.SelectedValue);
            fEETextBox.Text = testSetup.Fee.ToString();
            testIdHiddenField.Value = testSetup.Id.ToString();

        }

        private int serialNo = 0;
        private decimal total = 0;
        protected void allTestRequestGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                total += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Fee"));
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label totaLabel = (Label)e.Row.FindControl("totalamountLabel");
                totaLabel.Text = total.ToString();
            }


            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    e.Row.Cells[0].Text = (serialNo += 1).ToString();
            //    e.Row.Cells[1].Text = DataBinder.Eval(e.Row.DataItem, "Test").ToString();
            //    e.Row.Cells[2].Text = DataBinder.Eval(e.Row.DataItem, "Fee").ToString();

            //    total = total + Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Fee"));

            //}
            //else if (e.Row.RowType == DataControlRowType.Footer)
            //{
                
            //    e.Row.Cells[0].Text = "Total Amount: ";
            //    e.Row.Cells[1].Text = total.ToString();
            //}

        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            SavePatient();
            SavePatientTest();
            messageLabel.Text = "Test entry successfully.";
            CreateGrid();
          
  
           
            
            CreatePDF();
            ClerAll();
        }

        private void CreatePDF()
        {
            int columnsCount = allTestRequestGridView.HeaderRow.Cells.Count;
            PdfPTable pdfTable = new PdfPTable(columnsCount);
            foreach (TableCell gridViewHeaderCell in allTestRequestGridView.HeaderRow.Cells)
            {
                Font font = new Font();
                font.Color = new BaseColor(allTestRequestGridView.HeaderStyle.ForeColor);
                PdfPCell pdfCell = new PdfPCell(new Phrase(gridViewHeaderCell.Text, font));
                pdfTable.AddCell(pdfCell);
            }
            foreach (GridViewRow gridViewRow in allTestRequestGridView.Rows)
            {
                if (gridViewRow.RowType == DataControlRowType.DataRow)
                {
                    foreach (TableCell gridViewCell in gridViewRow.Cells)
                    {
                        Font font = new Font();
                        font.Color = new BaseColor(allTestRequestGridView.RowStyle.ForeColor);

                        PdfPCell pdfCell = new PdfPCell(new Phrase(gridViewCell.Text, font));

                        pdfTable.AddCell(pdfCell);
                    }
                }
            }

            foreach (TableCell gridViewHeaderCell in allTestRequestGridView.FooterRow.Cells)
            {
                Font font = new Font();
                font.Color = new BaseColor(allTestRequestGridView.FooterStyle.ForeColor);
                PdfPCell pdfCell = new PdfPCell(new Phrase(gridViewHeaderCell.Text, font));
                pdfTable.AddCell(pdfCell);
            }
            Document pdfDocument = new Document(PageSize.A4, 20f, 10f, 10f, 10f);
            PdfWriter.GetInstance(pdfDocument, Response.OutputStream);
            string Name = "                                                     Diagnostic Center Bill Management System";
            string moduleName = "                                                                Patient Entry Report";
            pdfDocument.Open();
            pdfDocument.Add(new Paragraph(" \n"));
            pdfDocument.Add(new Paragraph("                                                                                                                 " + DateTime.Now.ToString()));
            pdfDocument.Add(new Paragraph(Name));
            pdfDocument.Add(new Paragraph(" \n"));
            pdfDocument.Add(new Paragraph("\t" + moduleName));
            pdfDocument.Add(new Paragraph(" \n\n"));
            pdfDocument.Add(new Paragraph("Patient Name: " + patientName));
            pdfDocument.Add(new Paragraph("Mobile Number: " + mobileNumber));
            pdfDocument.Add(new Paragraph("Bill Number: " + billNumber));
            pdfDocument.Add(new Paragraph(" \n\n"));
            pdfDocument.Add(new Paragraph(" \n\n"));
            pdfDocument.Add(new Paragraph(" \n\n"));
            pdfDocument.Add(pdfTable);
            pdfDocument.Close();
            Response.ContentType = "application/pdf";
            Response.AppendHeader("content-disposition", "attachment;filename=PatientEntryReport.pdf");
            Response.Write(pdfDocument);
            Response.Flush();
            Response.End();
        }

        int patientId;
        private void SavePatient()
        {
            Patient aPatient = new Patient();
            aPatient.PatientName = patientNameTextBox.Text;
            aPatient.DateOfBirth = Convert.ToDateTime(dateOfBirthTextBox.Text);
            aPatient.MobileNo = mobileNoTextBox.Text;
            //aPatient.TestId= selectTestDropDownList.SelectedIndex;
            billNumber = aPatient.GetBillNo();
            patientName = patientNameTextBox.Text;
            mobileNumber = mobileNoTextBox.Text;



            patientId = testEntryManager.SavePatient(aPatient);
            //return patientId;
        }
        string connectionString = WebConfigurationManager.ConnectionStrings["DiagnocisDB"].ConnectionString;
        private void SavePatientTest()
        {
            foreach (GridViewRow g1 in allTestRequestGridView.Rows)
            {
                int testTypeId = Convert.ToInt32((g1.FindControl("testTypeIdLabel") as Label).Text);


                SqlConnection con = new SqlConnection(connectionString);
                SqlCommand com = new SqlCommand("INSERT INTO PatientTest(PatientId,TestSetupId,InsertDate) VALUES (" + patientId + ",'" + testTypeId + "',GETDATE())", con);
                con.Open();
                com.ExecuteNonQuery();
                con.Close();
            }
            //Label1.Text = "Records inserted successfully";
        }
        private void ClerAll()
        {
            
            patientNameTextBox.Text = string.Empty;
            mobileNoTextBox.Text = string.Empty;
            dateOfBirthTextBox.Text = string.Empty;
            selectTestDropDownList.SelectedIndex = 0;
            fEETextBox.Text = string.Empty;
        }
    }
}