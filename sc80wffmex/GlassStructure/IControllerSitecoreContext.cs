namespace sc80wffmex.GlassStructure
{
    using System.Collections.Specialized;

    public interface IControllerSitecoreContext
    {
        T GetDataSource<T>() where T : class;
 
        NameValueCollection GetRenderingParameters();
    }
}