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
    private const string _routebasename = "glucometer";

    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost(_routebasename, ([FromBody] AddTestCommand request,
            [FromServices] GlucometerService service) =>
        {

            if (!request.Validate())
                return Results.BadRequest();
            var result = service.Handle(request);
            return Results.Created("", result);

        });
        app.MapGet(_routebasename, ([FromBody] GetGlucometerCommand request,
            [FromServices] GlucometerService service) =>
        {
            if (!request.Validate())
                return Results.BadRequest();
            var result = service.Handle(request);
            return Results.Ok(result);
        });
        app.MapPut(_routebasename, ([FromBody] UpdateTestCommand request,
            [FromServices] GlucometerService service) =>
        {
            if (!request.Validate())
                return Results.BadRequest();
            var result = service.Handle(request);
            return Results.Ok(result);
        });
        app.MapDelete(_routebasename, ([FromBody] DeleteTestCommand request,
            [FromServices] GlucometerService service) =>
        {
            if (!request.Validate())
                return Results.BadRequest();
            var result = service.Handle(request);
            return Results.Ok(result);
        });
        app.MapGet("healthcheck", () =>
        {
            return Results.Ok("Alive");
        });
    }
}
