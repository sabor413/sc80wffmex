using System.Web.Mvc;
using Glass.Mapper.Sc;
using sc80wffmex.GlassStructure;
using sc80wffmex.Models;
using Sitecore.Data.Items;
using Sitecore.Sites;

namespace sc80wffmex.Controllers
{
    public class ProductController : Controller
    {
        //private readonly IControllerSitecoreContext _sitecoreContext;
        public ProductMapper PModel { get; set; }

        public ProductController() : base()
        {
        }

        //public ProductController(IControllerSitecoreContext sitecoreContext)
        //{
        //    this._sitecoreContext = sitecoreContext;
        //}

        public ActionResult Index()
        {
            //ISitecoreContext context = new SitecoreContext();
            //PModel = context.GetCurrentItem<ProductMapper>();

            IControllerSitecoreContext sitecoreContext = new ContextSitecoreContext();

            PModel = sitecoreContext.GetDataSource<ProductMapper>();
            var data = new ProductDisplayViewModel
            {
                Product = PModel ?? sitecoreContext.GetCurrentItem<ProductMapper>(),
                Parameters = sitecoreContext.GetRenderingParameters()
            };

            return View(data);
        }
    }
}