using Application.Com.Login.Commands;
using Application.Com.PaymentMethods.Models;
using Application.Com.PaymentMethods.Queries.GetAllPaymentMethod;
using Application.Com.Users.Commands.CreateUser;
using Application.Common.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WEB.Controllers
{
    [ApiController]
    public class AuthsController : ApiControllerBase
    {
        [HttpPost]
        public async Task<IResult> CreateUser(CreateUserCommand query)
        {
            
            return Results.Ok(await Mediator.Send(query));
        }
        [HttpPost]
        public async Task<IActionResult> Authenticate(LoginCommand model)
        {
            var result = await Mediator.Send(model);

            return Ok(result);

        }
    }
}
