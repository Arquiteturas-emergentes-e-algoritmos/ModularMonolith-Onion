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

    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("medicationplan", ([FromBody] AddMedicationCommand request,
            [FromServices] MedicationPlanService service) =>
        {

            if (!request.Validate())
                return Results.BadRequest();
            var result = service.Handle(request);
            return Results.Created("", result);

        });
        app.MapGet("medicationplan", ([FromBody] GetMedicationPlanCommand request,
            [FromServices] MedicationPlanService service) =>
        {
            if (!request.Validate())
                return Results.BadRequest();
            var result = service.Handle(request);
            return Results.Ok(result);
        });
        app.MapPut("medicationplan", ([FromBody] UpdateMedicationCommand request,
            [FromServices] MedicationPlanService service) =>
        {
            if (!request.Validate())
                return Results.BadRequest();
            var result = service.Handle(request);
            return Results.Ok(result);
        });
        app.MapDelete("medicationplan", ([FromBody] DeleteMedicationCommand request,
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
