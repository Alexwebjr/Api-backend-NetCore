using ApiTestBK.Models;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddProblemDetails(options =>
{
    options.CustomizeProblemDetails = ctx =>
    {
        ctx.ProblemDetails.Instance = ctx.HttpContext.Request.Path;
        // En prod, evita filtrar detalles sensibles
        if (!builder.Environment.IsDevelopment())
            ctx.ProblemDetails.Detail = null;
    };
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//DBcontext
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//Sustituir por url frontend
app.UseCors(options => options.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader());

app.UseHttpsRedirection();

app.UseAuthorization();

//Manejo Global de Errores
app.UseExceptionHandler(errorApp =>
{
    errorApp.Run(async context =>
    {
        var feature = context.Features.Get<IExceptionHandlerFeature>();
        var ex = feature?.Error;

        // Mapeo de excepción → (status, title)
        (int status, string title, string? detail) MapException(Exception? e, bool isDev)
        {
            switch (e)
            {
                case OperationCanceledException:
                    return (499, "Solicitud cancelada por el cliente", null);

                case ValidationException ve: // DataAnnotations / FluentValidation (si la usas)
                    // Puedes serializar errores aquí si los tienes en ve.ValidationResult
                    return (400, "Error de validación", isDev ? ve.Message : null);

                case KeyNotFoundException:
                    return (404, "Recurso no encontrado", isDev ? e?.Message : null);

                case DbUpdateConcurrencyException:
                    return (409, "Conflicto de concurrencia", isDev ? e?.Message : null);

                case DbUpdateException dbu:
                    return (503, "Error al persistir datos", isDev ? dbu.InnerException?.Message ?? dbu.Message : null);

                case DbException dbe:
                    return (503, "Error consultando la base de datos", isDev ? dbe.Message : null);

                default:
                    return (500, "Error inesperado", isDev ? e?.ToString() : null);
            }
        }

        var (status, title, detail) = MapException(ex, app.Environment.IsDevelopment());

        // Construye y devuelve ProblemDetails estándar
        var problem = Results.Problem(
            title: title,
            detail: detail,
            statusCode: status,
            instance: context.Request.Path,
            extensions: new Dictionary<string, object?>
            {
                // Útil para rastreo (no incluyas stack en prod)
                ["traceId"] = context.TraceIdentifier
            }
        );

        await problem.ExecuteAsync(context);
    });
});

// MVC (404, 405, etc.)
app.UseStatusCodePages(async ctx =>
{
    var status = ctx.HttpContext.Response.StatusCode;
    var problem = Results.Problem(
        title: $"HTTP {status}",
        statusCode: status,
        instance: ctx.HttpContext.Request.Path
    );
    await problem.ExecuteAsync(ctx.HttpContext);
});

app.MapControllers();

app.Run();
