using Libros;
using Libros.Services;

var myAllowCorsOrigin = "*";  

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSqlServer<LibrosContext>(builder.Configuration.GetConnectionString("conexiondb"));
builder.Services.AddScoped<ILibreriaService, LibreriaService>();

builder.Services.AddCors(options => {
    options.AddPolicy(name: myAllowCorsOrigin,
    policy => {
        policy.WithOrigins("*").AllowAnyHeader().AllowAnyMethod();
    });
}); 

var app = builder.Build();

app.UseCors(myAllowCorsOrigin); 

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
