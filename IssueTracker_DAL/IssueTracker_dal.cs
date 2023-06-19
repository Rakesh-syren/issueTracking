using IssueTracker_DAL.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace IssueTracker_DAL
{
    public class IssueTracker_dal
    {
        IssuetrackingdbContext context;
        public IssueTracker_dal()
        {
            context = new IssuetrackingdbContext();
        }
        public List<Employee> GetAllEmployees()
        {
            List<Employee> List = null;
            Employee emp = null;
            try
            {

                List = (from e in context.Employees
                        orderby e.EmpId
                        select e).ToList();   //LinQ Query
            }
            catch (Exception ex)
            {
                throw new Exception("Assigned Employee is not associated with this project.");
            }
            return List;
        }

        public Employee GetEmployeeById(int empid)
        {
            Employee emp = null;
            try
            {
                emp = (from e in context.Employees
                       where e.EmpId == empid
                       select e).First();
            }
            catch (Exception e)
            {
                throw new Exception("Assigned Employee is not associated with this project.");
            }
            return emp;
        }

        public List<Employee> GetEmployeeByProjectId(int projectid)
        {
            List<Employee> List = null;
            //Employee emp = null;
            try
            {
                List = (from e in context.Employees
                       where e.Projectid == projectid
                       select e).ToList();
            }
            catch (Exception e)
            {
                throw new Exception("Assigned Employee is not associated with this project.");
            }
            return List;
        }

        public bool AddEmployee(Employee emp)
        {
            var count = (from e in context.Employees
                         orderby e.EmpId descending
                         select e).First();
            emp.EmpId = count.EmpId + 1;
            bool result = false;
            try
            {
                context.Add(emp);
                context.SaveChanges();
                result = true;
            }
            catch (Exception e)
            {
                throw new Exception("Assigned Employee is not associated with this project.");
            }
            return result;
        }

        public bool DeleteEmployee(int empid)
        {
            bool result = false;
            Employee e = null;
            try
            {
                e = (from pd in context.Employees
                     where pd.EmpId == empid
                     select pd).First();
                if (e != null)
                {
                    context.Employees.Remove(e);
                    context.SaveChanges();
                    result = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Assigned Employee is not associated with this project.");
            }
            return result;
        }

        public bool UpdateEmployee(int empid, string empname)
        {
            bool result = false;
            try
            {
                Employee emp = (from c in context.Employees
                                where c.EmpId == empid
                                select c).First();
                if (emp != null)
                {
                    emp.EmpName = empname;
                    context.SaveChanges();
                    result = true;
                }
            }
            catch (Exception e)
            {
                throw new Exception("Assigned Employee is not associated with this project.");
            }
            return result;
        }
    }
}



