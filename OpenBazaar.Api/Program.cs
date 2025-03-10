using OpenBazaar.Repository.Extensions;
using OpenBazaar.Service;
using OpenBazaar.Service.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

builder.Services.AddRepositoryExtension(builder.Configuration).AddServiceExtension(typeof(ServiceAssembly));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
