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

        public bool AddComment(Comment commentObject)
        {
            bool result = false;
            if (commentObject.Comment1 == "")
            {
                return result;
            }


            try
            {

                var comobj = (from c in context.Comments
                              orderby c.CommentId descending
                              select c).First();
                commentObject.CommentId = comobj.CommentId + 1;
            }
            catch (Exception e)
            {
                commentObject.CommentId = 1;
            }



            var currTime = DateTime.Now;

            commentObject.CommentedOn = currTime;
            try
            {
                context.Add(commentObject);
                context.SaveChanges();
                result = true;

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);



            }
            return result;


        }

        public List<Comment> GetCommentByIssueId(int IssueId)
        {
            List<Comment> comments = null;
            try
            {
                comments = (from c in context.Comments
                            where c.IssueId == IssueId
                            orderby c.CommentedOn
                            select c).ToList();


            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return comments;
        }

    }
}



