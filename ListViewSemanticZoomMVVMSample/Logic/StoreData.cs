using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace ListViewSemanticZoomMVVMSample
{
    public class StoreData
    {
        public ObservableCollection<ICategorizable> Collection { get; private set; } = new ObservableCollection<ICategorizable>();

        internal List<ListWithKey<object>> GetGroupsByCategory()
        {
            List<ListWithKey<object>> groups = new List<ListWithKey<object>>();

            var query = from item in Collection
                        orderby item.Category
                        group item by item.Category into g
                        select new { GroupName = g.Key, Items = g };
            foreach (var g in query)
            {
                ListWithKey<object> info = new ListWithKey<object>();
                info.Key = g.GroupName;
                foreach (var item in g.Items)
                {
                    info.Add(item);
                }
                groups.Add(info);
            }

            return groups;
        }
    }
}
