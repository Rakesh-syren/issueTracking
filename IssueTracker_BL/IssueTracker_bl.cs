using IssueTracker_DAL;
using IssueTracker_DAL.Models;

namespace IssueTracker_BL
{
    public class IssueTracker_bl
    {
        IssueTracker_dal logic;
        public IssueTracker_bl()
        {
            logic = new IssueTracker_dal();
        }
        public List<Employee> GetAllEmployeesLogic()
        {
            List<Employee> Lst = null;
            try
            {
                Lst = logic.GetAllEmployees();
            }
            catch (Exception e)
            {
                throw new Exception("Assigned Employee is not associated with this project.");
            }
            return Lst;
        }

        public Employee GetEmployeeByIdLogic(int empid)
        {
            Employee emp = null;
            try
            {
                emp = logic.GetEmployeeById(empid);
            }
            catch (Exception e)
            {
                throw new Exception("Assigned Employee is not associated with this project.");
            }
            return emp;
        }

        public List<Employee> GetEmployeeByProjectIdLogic(int projectid)
        {
            List<Employee> Lst = null;
            try
            {
                Lst = logic.GetEmployeeByProjectId(projectid);
            }
            catch (Exception e)
            {
                throw new Exception("Assigned Employee is not associated with this project.");
            }
            return Lst;
        }

        public bool AddEmployeeLogic(Employee emp)
        {
            bool result = false;
            try
            {
                result = logic.AddEmployee(emp);
            }
            catch (Exception e)
            {
                throw new Exception("Assigned Employee is not associated with this project.");
            }
            return result;
        }

        public bool DeleteEmployeeLogic(int empid)
        {
            bool result = false;
            try
            {
                result = logic.DeleteEmployee(empid);
            }
            catch (Exception ex)
            {
                throw new Exception("Assigned Employee is not associated with this project.");
            }
            return result;
        }

        public bool UpdateEmployeeLogic(int empid, string empname)
        {
            bool result = false;
            try
            {
                result = logic.UpdateEmployee(empid, empname);
            }
            catch (Exception ex)
            {
                throw new Exception("Assigned Employee is not associated with this project.");
            }
            return result;
        }
    }
}