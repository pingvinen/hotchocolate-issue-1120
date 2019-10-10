using HotChocolate.Types;
using hotchocolate_issue_1120.GraphStuff.SharedGraph;

namespace hotchocolate_issue_1120.GraphStuff.PublicGraph
{
    public class PublicUserGraphTypeExtension : ObjectTypeExtension
    {
        protected override void Configure(IObjectTypeDescriptor descriptor)
        {
            descriptor.Name(UserGraphType.GraphName);
            descriptor.Field<UserGqlOut>(t => t.RelationToMe);
        }
    }
}