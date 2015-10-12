using System.Collections.Specialized;

namespace sc80wffmex.Models
{
    public class ProductDisplayViewModel
    {
        public ProductMapper Product { get; set; }
        public NameValueCollection Parameters { get; set; }
    }
}