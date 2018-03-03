using System.Threading.Tasks;
using Common.ValidationHelpers;
using DataAccess;
using DataAccess.EntitiesRepositories.SecurityRepositories;
using GraphQL;
using GraphQL.Types;
using DataAccess.EntitiesRepositories;
using GraphQLModels;
using GraphQLModels.Mutations;
using GraphQLModels.SecurityQuery;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.KeyVault.Models;
using Microsoft.EntityFrameworkCore;
using Models.Security;

namespace Beety.Controllers.Api
{
    [Route("api/graphql")]
    public class GraphQLController : Controller
    {
        public IUserRepository UserRepository { get; set; }

        public GraphQLController(IUserRepository userRepository)
        {
            UserRepository = userRepository;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateUser([FromBody] GraphQLQuery query)
        {
            var schema = new Schema { Query = new UserQuery(UserRepository), Mutation = new UserMutation(UserRepository) };
            var inputs = query.Variables.ToInputs();
            var queryToExecute = query.Query;

            var result = await new DocumentExecuter().ExecuteAsync(_ =>
            {
                _.Schema = schema;
                _.Query = queryToExecute;
                _.Inputs = inputs;
            }).ConfigureAwait(false);

            if (result.Errors?.Count > 0)
            {
                return BadRequest();
            }

            return Ok(result);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> GetUsers([FromBody] GraphQLQuery query)
        {
            var schema = new Schema { Query = new UserQuery(UserRepository)};
            var queryToExecute = query.Query;
            var result = await new DocumentExecuter().ExecuteAsync(_ =>
            {
                _.Schema = schema;
                _.Query = queryToExecute;
            }).ConfigureAwait(false);

            //if (result.Errors?.Count > 0)
            //{
            //    return BadRequest();
            //}

            return Ok(result);
        }
    }
}