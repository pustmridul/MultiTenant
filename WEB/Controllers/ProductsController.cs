using Application.Com.Products.Commands.CreateProduct;
using Application.Com.Products.Commands.DeleteProduct;
using Application.Com.Products.Commands.UpdateProduct;
using Application.Com.Products.Models;
using Application.Com.Products.Queries.GetProduct;
using Application.Common.Models;
using Microsoft.AspNetCore.Mvc;

namespace WEB.Controllers
{
    [ApiController]
    public class ProductsController : ApiControllerBase
    {
        public ProductsController()
        {
        }

        [HttpGet]
        public async Task<PaginatedList<ProductDto>> GetAll([FromQuery] GetProductQuery query)
        {
            return await Mediator.Send(query);
        }

        [HttpPost]
        public async Task<int> Create([AsParameters] CreateProductCommand query)
        {
            return await Mediator.Send(query);
        }
        [HttpPost]
        public async Task<IResult> Update(UpdateProductCommand command)
        {
            if (command.Id == 0) return Results.BadRequest();

            await Mediator.Send(command);
            return Results.Ok();
        }

        [HttpDelete]
        public async Task<IResult> Delete(int id)
        {
            await Mediator.Send(new DeleteProductCommand(id));
            return Results.NoContent();
        }
    }
}
