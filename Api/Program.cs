using Api.Extentions;
using Carter;
using Glucometer;
using MedicationPlan;
using User;

var builder = WebApplication.CreateBuilder(args);

var glucometerAssembly = typeof(GlucometerModule).Assembly;
var medicationPlanAssembly = typeof(MedicationPlanModule).Assembly;
var userAssembly = typeof(UserModule).Assembly;

builder.Services.AddCarterWithAssemblies(glucometerAssembly, medicationPlanAssembly, userAssembly);
builder.Services.AddMediatRWithAssemblies(glucometerAssembly, medicationPlanAssembly, userAssembly);
builder.Services.AddUserModule()
                .AddGlucometerModule()
                .AddMedicationPlanModule();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.MapCarter();

app.UseSwagger();
app.UseSwaggerUI();

await app.RunAsync();
