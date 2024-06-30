﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Controller;
using RequisitionSystemApi.Controllers;
using RequisitionSystemApi.Data;
using System.Reflection;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<RequisitionSystemApiContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("RequisitionSystemApiContext") ?? throw new InvalidOperationException("Connection string 'RequisitionSystemApiContext' not found.")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen( c =>
{
    c.SwaggerDoc("v1",
    new OpenApiInfo
    {
        Title = "Requisition System API - v1",
        Version = "v1"
    }
 );

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);

});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
