using EmployeeSystemWebAPI.Authentication;
using EmployeeSystemWebAPI.Extension;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Server.IISIntegration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ProvideApplicationDA();
builder.Services.ProvideApplicationServices();
builder.Services.AddAuthentication(IISDefaults.AuthenticationScheme);
builder.Services.AddAuthorization(Options =>
{
    Options.AddPolicy("ShouldbeAuthorizedApp", policy =>
    {
        policy.RequireAuthenticatedUser();
        policy.AuthenticationSchemes.Add(IISDefaults.AuthenticationScheme);
        policy.Requirements.Add(new ShouldbeAuthorizedAppRequirement());
    });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.MapControllers();
app.UseRouting();
app.Run();
