using System.Threading.Tasks;
using Common.ValidationHelpers;
using DataAccess;
using DataAccess.EntitiesRepositories.SecurityRepositories;
using GraphQL;
using GraphQL.Types;
using GraphQLModels;
using GraphQLModels.Mutations;
using GraphQLModels.SecurityQuery;
using Microsoft.AspNetCore.Mvc;

namespace Beety.Controllers.Api
{
    [Route("api/graphql")]
    public class GraphQLController : Controller
    {
        protected ApplicationDbContext DbContext { get; }

        public GraphQLController(ApplicationDbContext dbContext)
        {
            DbContext = dbContext;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] GraphQLQuery query)
        {
            var schema = new Schema { Query = new UserQuery(), Mutation = new UserMutation(new UserValidationHelper(DbContext))};
            var inputs = query.Variables.ToInputs();
            var queryToExecute = query.Query;

            var result = await new DocumentExecuter().ExecuteAsync(_ =>
            {
                _.Schema = schema;
                _.Query = queryToExecute;
                _.Inputs = inputs;
            }).ConfigureAwait(false);

            return Ok(result);
        }
    }
}