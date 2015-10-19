namespace sc80wffmex.WindsorIoC
{
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

            // Register the MVC controllers one by one
            // container.Register(Component.For().LifestylePerWebRequest());

            // Register all the MVC controllers in the current executing assembly
            var controllers = Assembly.GetExecutingAssembly().GetTypes().Where(x => x.BaseType == typeof(Controller)).ToList();
            foreach (var controller in controllers)
            {
                container.Register(Component.For(controller).LifestylePerWebRequest());

                using (var file =
                    new System.IO.StreamWriter(@"C:\Users\Carlos\Documents\Projects\sc80wffmex\registertracking2.txt"))
                {
                    file.WriteLine("Assembly:sc80wffmex - " + controller.Name + " is registered.");
                }
            }
        }
    }
}