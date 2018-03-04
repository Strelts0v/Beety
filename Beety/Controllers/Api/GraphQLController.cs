using System.Threading.Tasks;
using AutoMapper;
using GraphQL;
using GraphQL.Types;
using DataAccess.EntitiesRepositories;
using DataAccess.EntitiesRepositories.SecurityRepositories;
using Microsoft.AspNetCore.Mvc;
using Services.Commands.Mutations.SecurityMutations;
using Services.Queries;
using Services.Queries.SecurityQueries;

namespace Beety.Controllers.Api
{
    [Route("api/graphql")]
    public class GraphQLController : Controller
    {
        public IUserRepository UserRepository { get; set; }
        public IRoleRepository RoleRepository { get; set; }

        public GraphQLController(IUserRepository userRepository, IRoleRepository roleRepository)
        {
            UserRepository = userRepository;
            RoleRepository = roleRepository;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateUser([FromBody] GraphQLQuery query)
        {
            var schema = new Schema { Mutation = new UserCreateMutation(UserRepository, RoleRepository) };
            var inputs = query.Variables.ToInputs();
            var queryToExecute = query.Query;

            var result = await new DocumentExecuter().ExecuteAsync(_ =>
            {
                _.Schema = schema;
                _.Query = queryToExecute;
                _.Inputs = inputs;
            }).ConfigureAwait(false);

            //if (result.Errors?.Count > 0)
            //{
            //    return BadRequest();
            //}

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