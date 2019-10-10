using System.Reflection;
using Funq;
using ServiceStack;

namespace hotchocolate_issue_1120
{
    public class AppHost : AppHostBase
    {
        public AppHost(params Assembly[] assembliesWithServices) : base("Myes", assembliesWithServices)
        {
        }

        public override void Configure(Container container)
        {
        }
    }
}