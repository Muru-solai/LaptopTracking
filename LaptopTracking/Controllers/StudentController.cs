using LaptopTracking.BusLogic;
using LaptopTracking.Helpers;
using LaptopTracking.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;

namespace LaptopTracking.Controllers
{
    public class StudentController : Controller
    {

        //get student list
        public IActionResult Index(string FDate, string TDate)
        {
            //get student data
            List<UserLog> UserLogs = new List<UserLog>();
            try
            {
                string CDate = "";
                CDate = @ViewBag.SelectedDate;
                // get student information
                var getUserLog = StudLogic.GetUserLogData(FDate, TDate);
                UserLogs = HtmlHelpers.ConvertDataTable<UserLog>(getUserLog);
            }
            catch (Exception ex)
            {

            }
            return View(UserLogs.ToList());
        }
        public IActionResult AppLog(string FDate, string TDate)
        {
            //get student data
            List<AppLog> AppLogs = new List<AppLog>();
            try
            {
                string CDate = "";
                var getAppLog = StudLogic.GetAppLogData(FDate,TDate);
                AppLogs = HtmlHelpers.ConvertDataTable<AppLog>(getAppLog);
            }
            catch (Exception ex)
            {

            }
            return View(AppLogs.ToList());
        }
        public IActionResult Notification()
        {
            //get student data
            List<UserBreachLog> AppLogs = new List<UserBreachLog>();
            try
            {
                var userBreachLog = StudLogic.GetUserBreachData();
                AppLogs = HtmlHelpers.ConvertDataTable<UserBreachLog>(userBreachLog);
            }
            catch (Exception ex)
            {

            }
            return View(AppLogs.ToList());
        }

        [HttpPost]
        public JsonResult SearchData(string FDate, string TDate)
        {
            {
                //get student data
                List<UserLog> UserLogs = new List<UserLog>();
                try
                {
                    // get student information
                    var getStudents = StudLogic.GetUserLogData(FDate, TDate);
                    UserLogs = HtmlHelpers.ConvertDataTable<UserLog>(getStudents);

                }
                catch (Exception ex)
                {

                }
                return Json(UserLogs.ToList());
            }
        }
        [HttpPost]
        public JsonResult SearchAppData(string FDate, string TDate)
        {
            {
                
                //get student data
                List<AppLog> AppLogs = new List<AppLog>();
                try
                {
                    // get student information
                    var getAppLog = StudLogic.GetAppLogData(FDate,TDate);
                    AppLogs = HtmlHelpers.ConvertDataTable<AppLog>(getAppLog);

                }
                catch (Exception ex)
                {

                }
                return Json(AppLogs.ToList());
            }
        }
    }
}
