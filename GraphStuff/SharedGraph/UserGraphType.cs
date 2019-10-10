using HotChocolate.Types;

namespace hotchocolate_issue_1120.GraphStuff.SharedGraph
{
    public class UserGraphType : ObjectType<UserGqlOut>
    {
        public const string Name = "User";
        
        protected override void Configure(IObjectTypeDescriptor<UserGqlOut> descriptor)
        {
            descriptor
                .Name(Name)
                .Description("A User in the platform");
            
            descriptor
                .Field(f => f.Id)
                .Type<NonNullType<IdType>>()
                .Description("The ID of the user");
            
            descriptor
                .Field(f => f.Name)
                .Type<StringType>()
                .Description("The name of the user");
        }
    }
}