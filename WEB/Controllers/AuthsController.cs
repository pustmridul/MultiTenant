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
        public async Task<int> CreateUser([AsParameters] CreateUserCommand query)
        {
            return await Mediator.Send(query);
        }
    }
}
