using System.Collections.Generic;
using ServiceStack;

namespace hotchocolate_issue_1120.GraphStuff.Endpoint
{
    public abstract class GraphQlRequestBase : IReturn<string>
    {
        public string Query { get; set; }
        public Dictionary<string, object> Variables { get; set; }
    }
}