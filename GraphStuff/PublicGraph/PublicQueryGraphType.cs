using HotChocolate;
using HotChocolate.Types;
using hotchocolate_issue_1120.GraphStuff.SharedGraph;

namespace hotchocolate_issue_1120.GraphStuff.PublicGraph
{
    public class PublicQueryGraphType : SharedQueryGraphType
    {
        protected override void Configure(IObjectTypeDescriptor descriptor)
        {
            // this adds the queries from the SHARED graph
            base.Configure(descriptor);
            
            //
            // now add the PUBLIC-only queries to the graph
            //
        }

        public static void ModifySchemaDuringBuild(ISchemaBuilder schemaBuilder)
        {
            // TODO add "relationToMe" to the User graph... but how?
        }
    }
}