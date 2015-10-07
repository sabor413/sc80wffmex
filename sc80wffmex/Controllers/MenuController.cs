namespace sc80wffmex.Controllers
{
    using System.Web.Mvc;
    using sc80wffmex.Models;

    public class MenuController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            var menuList = new Menu();
            //other validation processing, if we needed, such as
            //MenuList.TemplateRestriction = "Product";
            //return View (MenuList.Restricted);

            return View(menuList.All);
        }
    }
}