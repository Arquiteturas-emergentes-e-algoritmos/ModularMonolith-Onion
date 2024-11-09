using Carter;
using Glucometer.Application.Command;
using Glucometer.Application.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace Glucometer.WebApi;

public class GlucometerController : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("glucometer", ([FromBody] AddTestCommand request,
            [FromServices] GlucometerService service) =>
        {

            if (!request.Validate())
                return Results.BadRequest();
            var result = service.Handle(request);
            return Results.Created("", result);

        });
        app.MapGet("glucometer", ([FromBody] GetGlucometerCommand request,
            [FromServices] GlucometerService service) =>
        {
            if (!request.Validate())
                return Results.BadRequest();
            var result = service.Handle(request);
            return Results.Ok(result);
        });
        app.MapPut("glucometer", ([FromBody] UpdateTestCommand request,
            [FromServices] GlucometerService service) =>
        {
            if (!request.Validate())
                return Results.BadRequest();
            var result = service.Handle(request);
            return Results.Ok(result);
        });
        app.MapDelete("glucometer", ([FromBody] DeleteTestCommand request,
            [FromServices] GlucometerService service) =>
        {
            if (!request.Validate())
                return Results.BadRequest();
            var result = service.Handle(request);
            return Results.Ok(result);
        });
    }
}
