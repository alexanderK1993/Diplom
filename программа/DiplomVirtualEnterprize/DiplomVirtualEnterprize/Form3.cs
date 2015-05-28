using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiplomVirtualEnterprize
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
         
            this.reportViewer1.RefreshReport();
        }
       
        private void button1_Click(object sender, EventArgs e)
        {
        
          /*
            Table table1 = new Table("333", "3333", 23);
            DataGrid dataGrid = new DataGrid();
            List<Table> table = new List<Table>();
            string sqlQuery = @"select *
                               from employees";

            DataSet MyDataSet = new DataSet();
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
               using (var cmd = new SqlCommand(sqlQuery, connection))
                        {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Table myReport = new Table((string)reader["name"], (string)reader["family"], (int)reader["employeeId"]);
                            table.Add(myReport);
                        }
                    }
                }
            }
            dataGrid.DataSource = table;

            ReportDataSource rDataSource = new ReportDataSource("data", table);
         //   reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(rDataSource);
            
            this.reportViewer1.RefreshReport();
            */

           /* LocalReport report = new LocalReport();
            report.ReportPath = Application.StartupPath + "\\Report1.rdlc";
            report.ReportEmbeddedResource = "RepView.Report1.rdlc";
            report.DataSources.Clear();
            
            ReportDataSource dtSourceHeader = new ReportDataSource("DSINVOICE_TABLE_INVOICE",MyDataSet.Tables["Employees"]);
         //   ReportDataSource dtSourceGoods = new ReportDataSource("DSINVOICE_TABLE_CALCULATE", bs);
            ReportParameter p1 = new
            ReportParameter("ShowDescriptions",MyDataSet.Tables["table"].Columns["name"].ToString());
            List<ReportParameter> reportParam= new List<ReportParameter>();
            reportParam.Add(p1);
            reportViewer1.LocalReport.ReportPath = Application.StartupPath + "\\Report1.rdlc";
            reportViewer1.LocalReport.ReportEmbeddedResource = "RepView.Report1.rdlc";
            reportViewer1.LocalReport.SetParameters(reportParam);
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(dtSourceHeader);/*
         
           // reportViewer1.LocalReport.DataSources.Add(dtSourceGoods);
            reportViewer1.LocalReport.Refresh();
            

           /* reportViewer1.ProcessingMode = ProcessingMode.Local;
            
            reportViewer1.LocalReport.ReportEmbeddedResource = "RepView.Report1.rdlc";
            this.reportViewer1.LocalReport.DataSources.Add(
                 new ReportDataSource("AnimalsDataSet_ThisAnimals", MyDataSet.Tables[0]));
            this.reportViewer1.RefreshReport();*/
        }
    }
}
