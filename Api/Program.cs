using Api.Extentions;
using Carter;
using Glucometer;
using MedicationPlan;

var builder = WebApplication.CreateBuilder(args);

var glucometerAssembly = typeof(GlucometerModule).Assembly;
var medicationPlanAssembly = typeof(MedicationPlanModule).Assembly;

builder.Services.AddCarterWithAssemblies(glucometerAssembly, medicationPlanAssembly);
builder.Services.AddMediatRWithAssemblies(glucometerAssembly, medicationPlanAssembly);
builder.Services.AddGlucometerModule()
                .AddMedicationPlanModule();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.MapCarter();

app.UseSwagger();
app.UseSwaggerUI();

await app.RunAsync();
