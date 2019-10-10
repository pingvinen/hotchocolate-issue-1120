using HotChocolate;
using HotChocolate.Types;
using hotchocolate_issue_1120.GraphStuff.SharedGraph;

namespace hotchocolate_issue_1120.GraphStuff.PrivateGraph
{
    public class PrivateQueryGraphType : SharedQueryGraphType
    {
        protected override void Configure(IObjectTypeDescriptor descriptor)
        {
            // this adds the queries from the SHARED graph
            base.Configure(descriptor);
            
            //
            // now add the PRIVATE-only queries to the graph
            //
            descriptor
                .Field("users")
                .Description("Get a list of users")
                .Type<ListType<UserGraphType>>()
                .Resolver(ctx => null);
        }
        
        public static void ModifySchemaDuringBuild(ISchemaBuilder schemaBuilder)
        {
            // add "forAdminEyesOnly" to the User graph... but how?
            schemaBuilder.AddType<PrivateUserGraphTypeExtension>();
        }
    }
}