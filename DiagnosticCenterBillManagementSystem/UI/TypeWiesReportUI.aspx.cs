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
    public partial class TypeWiesReportUI : System.Web.UI.Page
    {
        int serialNo = 0;
        TypeWiseReportManager typeWiseReportManager = new TypeWiseReportManager();
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
            typeWiesReportGridView.DataSource = dataTable;
            typeWiesReportGridView.DataBind();
        }


        protected void showButton_Click(object sender, EventArgs e)
        {
           try
            {
                string startDate = fromDateTextBox.Text;
                string endDate = toDateTextBox.Text;

                if (startDate == String.Empty || endDate == String.Empty)
                {
                   messageLabel.Text="Please select both date";
                    return;
                }

                LoadTestGridView(startDate, endDate);

            }

            catch (Exception exception)
            {
                
               messageLabel.Text=exception.Message;

                pDFButton.Visible = false;
                typeWiesReportGridView.Visible = false;
            }


        }


        private void LoadTestGridView(string startDate, string endDate)
        {
            List<TypeWiseTestReport> testSetups = typeWiseReportManager.GetAllTypeWiseReport(startDate, endDate);
            typeWiesReportGridView.DataSource = testSetups;
            typeWiesReportGridView.DataBind();


            if (testSetups.Count != 0)
            {
                typeWiesReportGridView.DataSource = testSetups;
                typeWiesReportGridView.DataBind();
                pDFButton.Visible = true;
            }
            else
            {
                typeWiesReportGridView.DataSource = null;
                typeWiesReportGridView.DataBind();
                pDFButton.Visible = false;
            }
        }

        

        private decimal total = 0;

        protected void typeWiesReportGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[0].Text = (serialNo += 1).ToString();
                e.Row.Cells[1].Text = DataBinder.Eval(e.Row.DataItem, "Name").ToString();
                e.Row.Cells[2].Text = DataBinder.Eval(e.Row.DataItem, "Count").ToString();
                e.Row.Cells[3].Text = DataBinder.Eval(e.Row.DataItem, "Total").ToString();

                total = total + Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Total"));

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

            int columnsCount = typeWiesReportGridView.HeaderRow.Cells.Count;
            PdfPTable pdfTable = new PdfPTable(columnsCount);
            foreach (TableCell gridViewHeaderCell in typeWiesReportGridView.HeaderRow.Cells)
            {
                Font font = new Font();
                font.Color = new BaseColor(typeWiesReportGridView.HeaderStyle.ForeColor);
                PdfPCell pdfCell = new PdfPCell(new Phrase(gridViewHeaderCell.Text, font));
                pdfTable.AddCell(pdfCell);
            }

            foreach (GridViewRow gridViewRow in typeWiesReportGridView.Rows)
            {
                if (gridViewRow.RowType == DataControlRowType.DataRow)
                {
                    foreach (TableCell gridViewCell in gridViewRow.Cells)
                    {
                        Font font = new Font();
                        font.Color = new BaseColor(typeWiesReportGridView.RowStyle.ForeColor);
                        PdfPCell pdfCell = new PdfPCell(new Phrase(gridViewCell.Text, font));
                        pdfTable.AddCell(pdfCell);
                    }
                }
            }

            foreach (TableCell gridViewHeaderCell in typeWiesReportGridView.FooterRow.Cells)
            {
                Font font = new Font();
                font.Color = new BaseColor(typeWiesReportGridView.FooterStyle.ForeColor);
                PdfPCell pdfCell = new PdfPCell(new Phrase(gridViewHeaderCell.Text, font));
                pdfTable.AddCell(pdfCell);
            }
            Document pdfDocument = new Document(PageSize.A4, 20f, 10f, 10f, 10f);
            PdfWriter.GetInstance(pdfDocument, Response.OutputStream);
            string Name = "                                                     Diagnostic Center Bill Management System";
            string moduleName = "                                                            Type Wise Report";
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
            Response.AppendHeader("content-disposition", "attachment;filename=TypeWiseReport.pdf");
            Response.Write(pdfDocument);
            Response.Flush();
            Response.End();
        }
    }
}