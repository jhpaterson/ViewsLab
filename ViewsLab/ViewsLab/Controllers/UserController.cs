using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ViewsLab.Domain;
using ViewsLab.Models;

namespace ViewsLab.Controllers
{
    public class UserController : Controller
    {
        IUserRepository repository;

        public UserController(IUserRepository repository)
        {
            this.repository = repository;
        }

        //
        // GET: /User/

        public ActionResult Index(string pageSize, string page, string sort)
        {
            ViewBag.pageSize = pageSize;
            ViewBag.page = page;
            ViewBag.sort = sort;
            return View();
        }

        public ActionResult UserGrid(string pageSize, string page, string sort)
        {
            int pageSizeNo = 5;   // default page size
            if (!string.IsNullOrEmpty(pageSize))
            {
                pageSizeNo = int.Parse(pageSize);
            }
            
            int pageNo = 0;   // first page by default
            if (!string.IsNullOrEmpty(page))
            {
                pageNo = int.Parse(page) - 1;
            }

            // get page from repository
            var users = repository.Get(pageSizeNo, pageNo, sort);

            // get total number of users in repository
            var userCount = repository.Count();

            // set up view model
            var model = new UserGridModel();
            model.Users = users;
            model.RowCount = userCount;
            model.CurrentPage = pageNo;
            model.PageSize = pageSizeNo;

            return PartialView(model);
        }

        public ActionResult UserDetail(string username)
        {
            ViewBag.Username = username;
            return View();
        }
  
    }
}
