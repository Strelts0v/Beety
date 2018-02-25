using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using DataAccess.EntitiesRepositories;
using GraphQLModels;
using GraphQLModels.SecurityQuery;
using Models.Security;

namespace StarWars.Api.Controllers
{
    [Route("api/graphql")]
    public class GraphQLController : Controller
    {
        public IUserRepository UserRepository { get; set; }

        public GraphQLController(IUserRepository userRepository)
        {
            UserRepository = userRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] GraphQLQuery query)
        {
            var schema = new Schema { Query = new UserQuery() };

            var result = await new DocumentExecuter().ExecuteAsync(_ =>
            {
                _.Schema = schema;
                _.Query = query.Query;

            }).ConfigureAwait(false);

            //if (result.Errors?.Count > 0)
            //{
            //    return BadRequest();
            //}

            return Ok(result);
        }
    }
}