using IssueTracker.Models;
using IssueTracker_BL;
using IssueTracker_DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace IssueTracker.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CommentController : Controller
    {
        public IssueTracker_bl bLObject;
        public CommentController()
        {
            bLObject = new IssueTracker_bl();
        }

        [HttpGet]
        public JsonResult GetCommentByIssueId(int IssueId)
        {
            List<Comment> result = null;
            List<NewComment> output = new List<NewComment>();
            try
            {
                result = bLObject.GetCommentByIssueIdBL(IssueId);
                foreach (Comment comment in result)
                {
                    NewComment newComment = new NewComment();
                    newComment.Comment1 = comment.Comment1;
                    newComment.CommentedOn = comment.CommentedOn;
                    newComment.CommentId = comment.CommentId;
                    newComment.IssueId = comment.IssueId;
                    newComment.EmpId = comment.EmpId;
                    output.Add(newComment);
                }

            }
            catch (Exception e)
            {
                var errorResponse = new
                {
                    error = "Error while fetching comments data from database",
                    message = e.Message
                };



                return Json(errorResponse);

            }
            return Json(output);

        }



        [HttpPost]

        public JsonResult AddComment(InputComment commentObject)
        {
            if (commentObject.Comment1 == "")
            {
                return Json(false);
            }
            bool result = false;
            Comment comment = new Comment();
            comment.Comment1 = commentObject.Comment1;
            comment.IssueId = commentObject.IssueId;
            comment.EmpId = commentObject.EmpId;
            try
            {
                result = bLObject.AddCommentBL(comment);

            }
            catch (Exception e)
            {

                var errorResponse = new
                {
                    error = "Error while fetching comments data from database",
                    message = e.Message
                };



                return Json(errorResponse);
            }
            return Json(result);
        }

    }
}



