using IssueTracker.Models;
using IssueTracker_BL;
using IssueTracker_DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace IssueTracker.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class IssueController : Controller
    {
        IssueTracker_bl issue;
        public IssueController()
        {
            issue = new IssueTracker_bl();
        }
        [HttpGet]
        public JsonResult GetAllEmployees()
        { 
            List<Employee> Lst = null;
            try
            {
                Lst = issue.GetAllEmployeesLogic();
            }
            catch (Exception e)
            {
                var errorResponse = new
                {
                    error = "An error occurred while fetching the issues.",
                    message = e.Message
                };
                return Json(errorResponse);
            }
            return Json(Lst);
        }

        [HttpGet]
        public JsonResult GetEmployeeById(int empid)
        {
            Employee emp = null;
            try
            {
                emp = issue.GetEmployeeByIdLogic(empid);
            }
            catch (Exception e)
            {
                var errorResponse = new
                {
                    error = "An error occurred while fetching the issues.",
                    message = e.Message
                };
                return Json(errorResponse);
            }
            return Json(emp);
        }

        [HttpGet]
        public JsonResult GetEmployeeByProjectId(int projectid)
        {
            List<Employee> Lst = null;
            try
            {
                Lst = issue.GetEmployeeByProjectIdLogic(projectid);
            }
            catch (Exception e)
            {
                var errorResponse = new
                {
                    error = "An error occurred while fetching the issues.",
                    message = e.Message
                };
                return Json(errorResponse);
            }
            return Json(Lst);
        }
        [HttpPost]
        public JsonResult AddEmployee(inputemployee emp)
        {
            bool result = false;
            try
            {
                Employee employee =new Employee();
                employee.EmpId = emp.EmpId;
                employee.EmpName = emp.EmpName;
                employee.Projectid = emp.Projectid;
                result = issue.AddEmployeeLogic(employee);
            }
            catch (Exception ex)
            {
                var errorResponse = new
                {
                    error = "An error occurred while fetching the issues.",
                    message = ex.Message
                };
                return Json(errorResponse);
            }
            return Json(result);
        }

        [HttpDelete]
        public JsonResult DeleteEmployee(int empid)
        {
            bool result = false;
            try
            {
                result = issue.DeleteEmployeeLogic(empid);
            }
            catch (Exception ex)
            {
                var errorResponse = new
                {
                    error = "An error occurred while fetching the issues.",
                    message = ex.Message
                };
                return Json(errorResponse);
            }
            return Json(result);
        }

        [HttpPut]
        public JsonResult UpdateEmployee(int empid, string empname)
        {
            bool result = false;
            try
            {
                result = issue.UpdateEmployeeLogic(empid, empname);
            }
            catch (Exception ex)
            {
                var errorResponse = new
                {
                    error = "An error occurred while fetching the issues.",
                    message = ex.Message
                };
                return Json(errorResponse);
            }
            return Json(result);
        }
    }
}
