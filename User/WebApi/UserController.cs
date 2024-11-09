using Carter;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using User.Application.Commands;
using User.Application.Services;

namespace User.WebApi;

public class UserController : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("", ([FromBody] CreateUserCommand request,
                    [FromServices] UserService service) =>
        {

            if (!request.Validate())
                return Results.BadRequest();
            var result = service.Handle(request);
            return Results.Created("", result);

        });
        app.MapGet("", ([FromBody] GetUserCommand request,
            [FromServices] UserService service) =>
        {
            if (!request.Validate())
                return Results.BadRequest();
            var result = service.Handle(request);
            return Results.Ok(result);
        });
    }
}
