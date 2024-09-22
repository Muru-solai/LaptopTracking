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
        public IActionResult Index(string CDate)
        {
            //get student data
            List<UserLog> UserLogs = new List<UserLog>();
            try
            {
                // get student information
                var getUserLog = StudLogic.GetUserLogData(CDate);
                UserLogs = HtmlHelpers.ConvertDataTable<UserLog>(getUserLog);
            }
            catch (Exception ex)
            {

            }
            return View(UserLogs.ToList());
        }
        public IActionResult AppLog(string CDate)
        {
            //get student data
            List<AppLog> AppLogs = new List<AppLog>();
            try
            {
                var getAppLog = StudLogic.GetAppLogData(CDate);
                AppLogs = HtmlHelpers.ConvertDataTable<AppLog>(getAppLog);
            }
            catch (Exception ex)
            {

            }
            return View(AppLogs.ToList());
        }


        [HttpPost]
        public JsonResult SearchData(string CDate)
        {
            {
                //get student data
                List<UserLog> UserLogs = new List<UserLog>();
                try
                {
                    // get student information
                    var getStudents = StudLogic.GetUserLogData(CDate);
                    UserLogs = HtmlHelpers.ConvertDataTable<UserLog>(getStudents);

                }
                catch (Exception ex)
                {

                }
                return Json(UserLogs.ToList());
            }
        }
        [HttpPost]
        public JsonResult SearchAppData(string CDate)
        {
            {
                //get student data
                List<AppLog> AppLogs = new List<AppLog>();
                try
                {
                    // get student information
                    var getAppLog = StudLogic.GetAppLogData(CDate);
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
