using System.Linq;
using System.Reflection;
using System.Web.Mvc;

namespace sc80wffmexviews.WindsorIoC
{
    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;
    
    using sc80wffmex.GlassStructure;
    using sc80wffmex.Controllers;

    public class ApplicationCastleInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            // Register working dependencies
            container.Register(Component.For<IControllerSitecoreContext>().ImplementedBy<ContextSitecoreContext>().LifestylePerWebRequest());

             // Register the MVC controllers one by one
            container.Register(Component.For(typeof (MenuController)).LifestylePerWebRequest());
            container.Register(Component.For(typeof(ProductController)).LifestylePerWebRequest());

            // Register all the MVC controllers in the current executing assembly
            //var controllers =
            //    from t in Assembly.GetCallingAssembly().GetTypes()
            //    where typeof(IController).IsAssignableFrom(t)
            //    select t;

            //foreach (Type t in controllers)
            //    container.AddComponentLifeStyle(
            //        t.FullName, t, LifestyleType.Transient);

            //var controllers = Assembly.GetExecutingAssembly().GetTypes().Where(x => x.BaseType == typeof(Controller)).ToList();
            //foreach (var controller in controllers)
            //{
            //    container.Register(Component.For(controller).LifestylePerWebRequest());

            //}
        }
    }
}