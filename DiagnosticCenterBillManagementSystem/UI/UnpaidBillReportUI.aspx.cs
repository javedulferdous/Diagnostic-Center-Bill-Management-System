using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DiagnosticCenterBillManagementSystem.BLL;
using DiagnosticCenterBillManagementSystem.Models.View_Model;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace DiagnosticCenterBillManagementSystem.UI
{
    public partial class UnpaidBillReportUI : System.Web.UI.Page
    {
        private int serialNo = 0;
        UnpaidBillManager unpaidBillManager=new UnpaidBillManager();
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
            unpaidBillReportGridView.DataSource = dataTable;
            unpaidBillReportGridView.DataBind();
        }

        protected void pDFButton_Click(object sender, EventArgs e)
        {
            int columnsCount = unpaidBillReportGridView.HeaderRow.Cells.Count;
            PdfPTable pdfTable = new PdfPTable(columnsCount);
            foreach (TableCell gridViewHeaderCell in unpaidBillReportGridView.HeaderRow.Cells)
            {
                Font font = new Font();
                font.Color = new BaseColor(unpaidBillReportGridView.HeaderStyle.ForeColor);
                PdfPCell pdfCell = new PdfPCell(new Phrase(gridViewHeaderCell.Text, font));
                pdfTable.AddCell(pdfCell);
            }

            foreach (GridViewRow gridViewRow in unpaidBillReportGridView.Rows)
            {
                if (gridViewRow.RowType == DataControlRowType.DataRow)
                {
                    foreach (TableCell gridViewCell in gridViewRow.Cells)
                    {
                        Font font = new Font();
                        font.Color = new BaseColor(unpaidBillReportGridView.RowStyle.ForeColor);
                        PdfPCell pdfCell = new PdfPCell(new Phrase(gridViewCell.Text, font));
                        pdfTable.AddCell(pdfCell);
                    }
                }
            }

            foreach (TableCell gridViewHeaderCell in unpaidBillReportGridView.FooterRow.Cells)
            {
                Font font = new Font();
                font.Color = new BaseColor(unpaidBillReportGridView.FooterStyle.ForeColor);
                PdfPCell pdfCell = new PdfPCell(new Phrase(gridViewHeaderCell.Text, font));
                pdfTable.AddCell(pdfCell);
            }
            Document pdfDocument = new Document(PageSize.A4, 20f, 10f, 10f, 10f);
            PdfWriter.GetInstance(pdfDocument, Response.OutputStream);
            string Name = "                                                     Diagnostic Center Bill Management System";
            string moduleName = "                                                            Unpaid Bill Report";
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
            Response.AppendHeader("content-disposition", "attachment;filename=UnPaidBillReport.pdf");
            Response.Write(pdfDocument);
            Response.Flush();
            Response.End();

        }

        private void LoadTestGridView(string startDate, string endDate)
        {
            List<UmpaidBillViewModel> unpaidBill = unpaidBillManager.UnpaidBillReport(startDate, endDate);
            unpaidBillReportGridView.DataSource = unpaidBill;
            unpaidBillReportGridView.DataBind();

            if (unpaidBill.Count != 0)
            {
                unpaidBillReportGridView.DataSource = unpaidBill;
                unpaidBillReportGridView.DataBind();
                pDFButton.Visible = true;
            }
            else
            {
                unpaidBillReportGridView.DataSource = null;
                unpaidBillReportGridView.DataBind();
                pDFButton.Visible = false;
            }
        }

        protected void showButton_Click(object sender, EventArgs e)
        {
            try
            {
                string startDate = fromDateTextBox.Text;
                string endDate = toDateTextBox.Text;

                if (startDate == String.Empty || endDate == String.Empty)
                {
                    messageLabel.Text = "Please select both date";
                    return;
                }

                LoadTestGridView(startDate, endDate);

            }

            catch (Exception exception)
            {

                messageLabel.Text = exception.Message;

                pDFButton.Visible = false;
                unpaidBillReportGridView.Visible = false;
            }



        }

        private decimal total = 0;
        protected void unpaidBillReportGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[0].Text = (serialNo += 1).ToString();
                e.Row.Cells[1].Text = DataBinder.Eval(e.Row.DataItem, "PatientName").ToString();
                e.Row.Cells[2].Text = DataBinder.Eval(e.Row.DataItem, "BillNo").ToString();
                e.Row.Cells[3].Text = DataBinder.Eval(e.Row.DataItem, "MobileNo").ToString();
                e.Row.Cells[4].Text = DataBinder.Eval(e.Row.DataItem, "TotalAmount").ToString();

                total = total + Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "TotalAmount"));

            }
            else if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[0].Text = "";
                e.Row.Cells[1].Text = "";
                e.Row.Cells[2].Text = "";
                e.Row.Cells[3].Text = "Total Amount: ";
                e.Row.Cells[4].Text = total.ToString();
            }

        }
    }
}
