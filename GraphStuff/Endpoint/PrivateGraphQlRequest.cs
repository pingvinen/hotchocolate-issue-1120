using ServiceStack;

namespace hotchocolate_issue_1120.GraphStuff.Endpoint
{
    [Route("/private_graphql", "POST")]
    public class PrivateGraphQlRequest : GraphQlRequestBase
    {
    }
}