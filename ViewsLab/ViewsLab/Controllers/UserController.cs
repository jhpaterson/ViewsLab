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
            // TODO: complete this method
            return View();
        }

        public ActionResult UserGrid(string pageSize, string page, string sort)
        {
            // TODO: complete this method

            return PartialView();
        }

        public ActionResult UserDetail(string username)
        {
            ViewBag.Username = username;
            return View();
        }
  
    }
}
