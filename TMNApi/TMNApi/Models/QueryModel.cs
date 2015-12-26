using System.Collections.Generic;

namespace TMNApi.Models
{
    public class QueryModel
    {
        public string WhereClause { get; set; }
        public List<object> Values { get; set; }
    }
}