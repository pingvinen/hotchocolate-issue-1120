using HotChocolate.Types;

namespace hotchocolate_issue_1120.GraphStuff.SharedGraph
{
    public class SharedQueryGraphType : ObjectType
    {
        protected override void Configure(IObjectTypeDescriptor descriptor)
        {
            descriptor.Name("Query");
            
            descriptor
                .Field("userById")
                .Description("Get a specific user")
                .Type<UserGraphType>()
                .Argument(
                    "id",
                    arg => arg
                        .Description("The ID of the user to get")
                        .Type<NonNullType<IdType>>()
                )
                .Resolver(ctx => new UserGqlOut
                {
                    Id = "hohoho",
                    Name = "Santa",
                    RelationToMe = "Childhood memory",
                    ForAdminEyesOnly = "this is soooo secret"
                });
        }
    }
}