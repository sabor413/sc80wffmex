using System.Web.Mvc;
using sc80wffmex.GlassStructure;
using sc80wffmex.Models;

namespace sc80wffmex.Controllers
{
    public class ProductController : Controller
    {
        private readonly IControllerSitecoreContext _sitecoreContext;
        public ProductMapper PModel { get; set; }

        public ProductController(IControllerSitecoreContext psitecoreContext)
        {
            this._sitecoreContext = psitecoreContext;
        }

        public ActionResult Index()
        {
            //ISitecoreContext context = new SitecoreContext();
            //PModel = context.GetCurrentItem<ProductMapper>();

            //// This was working without IoC
            //IControllerSitecoreContext sitecoreContext = new ContextSitecoreContext();

            PModel = _sitecoreContext.GetDataSource<ProductMapper>();
            var data = new ProductDisplayViewModel
            {
                Product = PModel ?? _sitecoreContext.GetCurrentItem<ProductMapper>(),
                Parameters = _sitecoreContext.GetRenderingParameters()
            };

            return View(data);
        }
    }
}