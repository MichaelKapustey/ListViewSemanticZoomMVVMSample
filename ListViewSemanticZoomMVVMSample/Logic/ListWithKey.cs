using System.Collections.Generic;

namespace ListViewSemanticZoomMVVMSample
{
    public class ListWithKey<T> : List<object>
    {
        public object Key { get; set; }
    }
}
