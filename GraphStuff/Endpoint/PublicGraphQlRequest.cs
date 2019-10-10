using ServiceStack;

namespace hotchocolate_issue_1120.GraphStuff.Endpoint
{
    [Route("/graphql", "POST")]
    public class PublicGraphQlRequest : GraphQlRequestBase
    {
    }
}