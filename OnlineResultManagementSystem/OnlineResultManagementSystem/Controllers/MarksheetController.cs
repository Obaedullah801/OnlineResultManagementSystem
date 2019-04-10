using Microsoft.Reporting.WebForms;
using OnlineResultManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineResultManagementSystem.Controllers
{
    public class MarksheetController : Controller
    {
        // GET: Marksheet
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ShowmarksheetReport(int regNo)
        {
            LocalReport lr = new LocalReport();

            string path = Path.Combine(Server.MapPath("~/Reports/IndivisualResultReport.rdlc"));
            if (System.IO.File.Exists(path))
            {
                lr.ReportPath = path;
            }


            ReportParameterCollection reportParameters = new ReportParameterCollection();

            reportParameters.Add(new ReportParameter("reg_no", regNo.ToString()));
            




            lr.SetParameters(reportParameters);
            ReportDataSource rd;
            List<sp_generate_mark_sheet_Result> result = new List<sp_generate_mark_sheet_Result>();
            using (var context = new OnlineResultDBEntities())
            {
                result = context.sp_generate_mark_sheet(regNo).ToList();
                rd = new ReportDataSource("DataSet1", result);
            }


            lr.DataSources.Add(rd);

            string reportType = "pdf";
            string mimeType;
            string encoding;
            string fileNameExtension;
            string deviceInfo =

            "<DeviceInfo>" +
            "  <OutputFormat>" + "pdf" + "</OutputFormat>" +
            "</DeviceInfo>";

            Warning[] warnings;
            string[] streams;
            byte[] renderedBytes;
            //lr.Refresh();

            renderedBytes = lr.Render(
                reportType,
                deviceInfo,
                out mimeType,
                out encoding,
                out fileNameExtension,
                out streams,
                out warnings);

            return File(renderedBytes, mimeType);
        }
    }
}