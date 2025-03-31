using Dropper.Presentation;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPresentation();

var app = builder.Build();

app.ConfigureWebApplication();

app.Run();
