using System;
using System.Threading.Tasks;
using Funq;
using HotChocolate;
using HotChocolate.Configuration;
using HotChocolate.Execution;
using HotChocolate.Execution.Configuration;
using HotChocolate.Types;
using hotchocolate_issue_1120.GraphStuff.PrivateGraph;
using hotchocolate_issue_1120.GraphStuff.PublicGraph;
using ServiceStack;

namespace hotchocolate_issue_1120.GraphStuff.Endpoint
{
    public class GraphQlService : Service
    {
        private readonly Container _container;

        public GraphQlService(Container container)
        {
            _container = container;
        }

        private async Task<object> ProcessRequestAsync<TQuery>(GraphQlRequestBase requestBase, Action<ISchemaBuilder> schemaExtender) where TQuery : class
        {
            var builder = SchemaBuilder
                .New()
                .SetOptions(new SchemaOptions
                {
                    DefaultBindingBehavior = BindingBehavior.Explicit
                })
                .AddServices(_container)
                .AddQueryType<TQuery>();
            
            schemaExtender.Invoke(builder);

            var schema = builder.Create();
            
            IQueryExecutor executor = schema.MakeExecutable(new QueryExecutionOptions
            {
                IncludeExceptionDetails = true
            });

            var result = await executor.ExecuteAsync(x =>
            {
                x.SetQuery(requestBase.Query);
                x.SetVariableValues(requestBase.Variables);
            });

            return result.ToJson(true);
        }
        
        
        public async Task<object> Post(PublicGraphQlRequest request)
        {
            return await ProcessRequestAsync<PublicQueryGraphType>(request, PublicQueryGraphType.ModifySchemaDuringBuild);
        }
        
        public async Task<object> Post(PrivateGraphQlRequest request)
        {
            return await ProcessRequestAsync<PrivateQueryGraphType>(request, PrivateQueryGraphType.ModifySchemaDuringBuild);
        }
    }
}