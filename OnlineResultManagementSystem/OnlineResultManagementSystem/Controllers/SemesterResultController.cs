using OnlineResultManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Reporting.WebForms;
using System.IO;

namespace OnlineResultManagementSystem.Controllers
{
    public class SemesterResultController : Controller
    {
        // GET: SemesterResult
        private ReportModel rm;
        public ActionResult Index()
        {
            using(var context = new OnlineResultDBEntities())
            {
                 ViewBag.departments = context.tblDepartments.ToList();
                 ViewBag.semesters = context.tblSemesters.ToList();
            }
            
            return View();
        }

        public ActionResult SemesterResultReport(int departmentId, int SemesterId)
        {
            LocalReport lr = new LocalReport();
    
            string path = Path.Combine(Server.MapPath("~/Reports/SemesterResultReport.rdlc"));
            if (System.IO.File.Exists(path))
            {
                lr.ReportPath = path;
            }

            
            ReportParameterCollection reportParameters = new ReportParameterCollection();

            reportParameters.Add(new ReportParameter("semester_id", SemesterId.ToString()));
            reportParameters.Add(new ReportParameter("departmant_id", departmentId.ToString()));
            
            
            
            
            lr.SetParameters(reportParameters);
            ReportDataSource rd;
            List<sp_generate_result_Result> result = new List<sp_generate_result_Result>();
            using(var context = new OnlineResultDBEntities())
            {
                result = context.sp_generate_result(SemesterId, departmentId).ToList();
                rd = new ReportDataSource("DataSet2", result);
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