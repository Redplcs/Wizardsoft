using Microsoft.EntityFrameworkCore;
using Redplcs.Wizardsoft.Application;
using Redplcs.Wizardsoft.Database;
using Redplcs.Wizardsoft.Domain;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationContext>(options =>
{
	options.UseInMemoryDatabase(databaseName: "Database");
});
builder.Services.AddScoped<ITreeItemRepository, TreeItemRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapCrudOperations();
app.Run();
