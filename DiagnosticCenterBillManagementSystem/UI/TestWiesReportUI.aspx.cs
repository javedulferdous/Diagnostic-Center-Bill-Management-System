using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using DiagnosticCenterBillManagementSystem.BLL;
using DiagnosticCenterBillManagementSystem.Models;
using DiagnosticCenterBillManagementSystem.Models.View_Model;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace DiagnosticCenterBillManagementSystem.UI
{
    public partial class TestWiesReportUI : System.Web.UI.Page
    {
        TestWiseReportManager testManager = new TestWiseReportManager();

        private decimal total = 0;
        private int serialNo = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadEmptyTestGridView();
                
            }
            
            pDFButton.Visible = false;
        }
        private void LoadEmptyTestGridView()
        {
            DataTable dataTable = new DataTable();
            testWiesReportGridView.DataSource = dataTable;
            testWiesReportGridView.DataBind();
        }
        protected void showButton_Click(object sender, EventArgs e)
        {

            try
            {
                string startDate = fromDateTextBox.Text;
                string endDate = toDateTextBox.Text;

                if (startDate == String.Empty || endDate == String.Empty)
                {
                    MessageBox.Show("Please select both date");
                    return;
                }

                LoadTestGridView(startDate, endDate);

            }

            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);

                pDFButton.Visible = false;
                testWiesReportGridView.Visible = false;
            }


        }
        private void LoadTestGridView(string startDate, string endDate)
        {
            List<DateWiseTestReport> testReportList = testManager.GetDateWiseTestReport(startDate, endDate);
            if (testReportList.Count != 0)
            {
                testWiesReportGridView.DataSource = testReportList;
                testWiesReportGridView.DataBind();
                pDFButton.Visible = true;
            }
            else
            {
                testWiesReportGridView.DataSource = null;
                testWiesReportGridView.DataBind();
                pDFButton.Visible = false;
            }
        }
        protected void allTestRequestGridView(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[0].Text = (serialNo += 1).ToString();
                e.Row.Cells[1].Text = DataBinder.Eval(e.Row.DataItem, "TestName").ToString();
                e.Row.Cells[2].Text = DataBinder.Eval(e.Row.DataItem, "TotalCount").ToString();
                e.Row.Cells[3].Text = DataBinder.Eval(e.Row.DataItem, "TotalFee").ToString();

                total = total + Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "TotalFee"));

            }
            else if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[0].Text = "";
                e.Row.Cells[1].Text = "";
                e.Row.Cells[2].Text = "Total Amount: ";
                e.Row.Cells[3].Text = total.ToString();
            }
        }


        protected void pDFButton_Click(object sender, EventArgs e)
        {
            int columnsCount = testWiesReportGridView.HeaderRow.Cells.Count;


            PdfPTable pdfTable = new PdfPTable(columnsCount);


            foreach (TableCell gridViewHeaderCell in testWiesReportGridView.HeaderRow.Cells)
            {

                Font font = new Font();
                font.Color = new BaseColor(testWiesReportGridView.HeaderStyle.ForeColor);

                PdfPCell pdfCell = new PdfPCell(new Phrase(gridViewHeaderCell.Text, font));

                pdfTable.AddCell(pdfCell);
            }

            foreach (GridViewRow gridViewRow in testWiesReportGridView.Rows)
            {
                if (gridViewRow.RowType == DataControlRowType.DataRow)
                {
                    foreach (TableCell gridViewCell in gridViewRow.Cells)
                    {
                        Font font = new Font();
                        font.Color = new BaseColor(testWiesReportGridView.RowStyle.ForeColor);

                        PdfPCell pdfCell = new PdfPCell(new Phrase(gridViewCell.Text, font));

                        pdfTable.AddCell(pdfCell);
                    }
                }
            }

            foreach (TableCell gridViewHeaderCell in testWiesReportGridView.FooterRow.Cells)
            {
                Font font = new Font();
                font.Color = new BaseColor(testWiesReportGridView.FooterStyle.ForeColor);
                PdfPCell pdfCell = new PdfPCell(new Phrase(gridViewHeaderCell.Text, font));
                pdfTable.AddCell(pdfCell);
            }


            Document pdfDocument = new Document(PageSize.A4, 20f, 10f, 10f, 10f);

            PdfWriter.GetInstance(pdfDocument, Response.OutputStream);
            string Name = "                                                     Diagnostic Center Bill Management System";
            string moduleName = "                                                            Test Wise Report";
            pdfDocument.Open();
            pdfDocument.Add(new Paragraph(" \n"));
            pdfDocument.Add(new Paragraph("                                                                                                                 " + DateTime.Now.ToString()));
            pdfDocument.Add(new Paragraph(Name));
            pdfDocument.Add(new Paragraph(" \n"));
            pdfDocument.Add(new Paragraph("\t" + moduleName));
            pdfDocument.Add(new Paragraph(" \n\n"));
            pdfDocument.Add(pdfTable);
            pdfDocument.Close();
            Response.ContentType = "application/pdf";
            Response.AppendHeader("content-disposition", "attachment;filename=TesteWiseReport.pdf");
            Response.Write(pdfDocument);
            Response.Flush();
            Response.End();
        }

      

        
    }
}