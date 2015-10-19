using Glass.Mapper.Sc;

namespace sc80wffmexviews.WindsorIoC
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Web.Mvc;

    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;
    
    using sc80wffmex.GlassStructure;

    public class ApplicationCastleInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            // Register working dependencies
            container.Register(Component.For<IControllerSitecoreContext>().ImplementedBy<ContextSitecoreContext>().LifestylePerWebRequest());

            container.Register(Component.For<ISitecoreContext>().ImplementedBy<SitecoreContext>().LifestylePerWebRequest());

             // Register the MVC controllers one by one
            //container.Register(Component.For(typeof (MenuController)).LifestylePerWebRequest());
            //container.Register(Component.For(typeof(ProductController)).LifestylePerWebRequest());

            // MVC Controllers are found and registered - Logging it
            using (var file =
                new System.IO.StreamWriter(@"C:\Users\Carlos\Documents\Projects\sc80wffmex\RegisteredControllers.txt", true))
            {
                foreach (
                    Assembly b in
                        AppDomain.CurrentDomain.GetAssemblies().Where(x => x.GetName().ToString().Contains("sc80")))
                {
                    file.WriteLine("Found Assembly = " + b.GetName());

                    var controllers = b.GetTypes().Where(x => x.BaseType == typeof (Controller)).ToList();

                    foreach (var controller in controllers)
                    {
                        container.Register(Component.For(controller).LifestylePerWebRequest());

                        file.WriteLine("Found Controller = " + controller.Name);
                    }
                }

                #region Commented Out Code
                //var controllers =
                //    Assembly.GetReferencedAssemblies().GetTypes().Where(t => typeof(IController).IsAssignableFrom(t));

                //foreach (Type t in controllers)
                //    container.AddComponentLifeStyle(
                //        t.FullName, t, LifestyleType.Transient);

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
                #endregion
            }
        }
    }
}