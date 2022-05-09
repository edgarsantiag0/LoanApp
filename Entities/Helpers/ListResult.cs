using Entities.RequestFeatures;
using System.Collections.Generic;

namespace Entities.Helpers
{
    public class ListResult<T>
    {
        public IEnumerable<T> Items { get; set; }
        public RequestParameters Parameters { get; set; }
        public MetaData MetaData { get; set; }

        public ListResult(IEnumerable<T> items, RequestParameters parameters, MetaData metaData)
        {
            Items = items;
            Parameters = parameters;
            MetaData = metaData;
        }
    }
}
