using Carter;
using MedicationPlan.Application.Command;
using MedicationPlan.Application.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace MedicationPlan.WebApi;

public class MedicationPlanController : ICarterModule
{
    private const string _routebasename = "medicationplan";
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost(_routebasename, ([FromBody] AddMedicationCommand request,
            [FromServices] MedicationPlanService service) =>
        {

            if (!request.Validate())
                return Results.BadRequest();
            var result = service.Handle(request);
            return Results.Created("", result);

        });
        app.MapGet(_routebasename, ([FromBody] GetMedicationPlanCommand request,
            [FromServices] MedicationPlanService service) =>
        {
            if (!request.Validate())
                return Results.BadRequest();
            var result = service.Handle(request);
            return Results.Ok(result);
        });
        app.MapPut(_routebasename, ([FromBody] UpdateMedicationCommand request,
            [FromServices] MedicationPlanService service) =>
        {
            if (!request.Validate())
                return Results.BadRequest();
            var result = service.Handle(request);
            return Results.Ok(result);
        });
        app.MapDelete(_routebasename, ([FromBody] DeleteMedicationCommand request,
            [FromServices] MedicationPlanService service) =>
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
