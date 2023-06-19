using IssueTracker.Controllers;
using IssueTracker.Models;
using IssueTracker_DAL.Models;
using Microsoft.AspNetCore.Components.Forms;
using System.Text.Json.Nodes;

namespace IssueTrackerTesting
{
    [TestClass]
    public class IssueAppTesting
    {
        IssueController apptest;
        public IssueAppTesting()
        {
            apptest = new IssueController();
        }
        [TestMethod]
        public void GetAllEmployeesTest()
        {
            var result = apptest.GetAllEmployees();
            List<Employee> actualvalues = (List<Employee>)result.Value;
            Assert.IsInstanceOfType(actualvalues,typeof(List<Employee>));
        }
        [TestMethod]
        public void GetEmployeeByIdTest()
        {
            var result = apptest.GetEmployeeById(1);
            Employee employee = (Employee)result.Value;
            Assert.IsInstanceOfType(employee,typeof(Employee));
        }
        [TestMethod]
        public void AddEmployeeTest()
        {
            inputemployee input= new inputemployee();
            input.EmpName = "David";
            input.Projectid = 4;
            var result = apptest.AddEmployee(input);
            bool actualvalue=(bool)result.Value;
            Assert.AreEqual(true, actualvalue);
        }
        [TestMethod]
        public void GetEmployeeByProjectIdTest()
        {
            var result = apptest.GetEmployeeByProjectId(3);
            List<Employee> actualvalues = (List<Employee>)result.Value;
            Assert.IsInstanceOfType(actualvalues, typeof(List<Employee>));
        }
        /*[TestMethod]
        public void DeleteEmployeeTest()
        {
            var result = apptest.DeleteEmployee(48);
            bool actualvalue = (bool)result.Value;
            Assert.AreEqual(true, actualvalue);
        }*/
        [TestMethod]
        public void UpdateEmployeeTest()
        {
            var result = apptest.UpdateEmployee(33,"Ursula");
            bool actualvalue = (bool)result.Value;
            Assert.AreEqual(true, actualvalue);
        }
    }
}