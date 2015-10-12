using System.Collections.Specialized;
using Glass.Mapper.Sc;

namespace sc80wffmex.GlassStructure
{
    public interface IControllerSitecoreContext : ISitecoreContext
    {
        T GetDataSource<T>() where T : class;
 
        NameValueCollection GetRenderingParameters();
    }
}