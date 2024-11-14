using Microsoft.AspNetCore.Mvc;
using Redplcs.Wizardsoft.Domain;

namespace Redplcs.Wizardsoft.Application.Extensions;

public static class WebApplicationExtensions
{
	public static WebApplication MapGetCrudEndpoints(this WebApplication app)
	{
		app.MapGet("/create", CreateHandler);
		app.MapGet("/get-all", GetAllHandler);
		app.MapGet("/get-by-id", GetByIdHandler);
		app.MapGet("/update", UpdateHandler);
		app.MapGet("/delete", DeleteHandler);

		return app;
	}

	private static void CreateHandler()
	{
		throw new NotImplementedException();
	}

	private static IEnumerable<TreeItem> GetAllHandler([FromServices] ITreeItemRepository repository)
	{
		return repository.GetAll();
	}

	private static TreeItem? GetByIdHandler(
		[FromQuery] Guid id,
		[FromServices] ITreeItemRepository repository)
	{
		return repository.GetById(id);
	}

	private static void UpdateHandler()
	{
		throw new NotImplementedException();
	}

	private static void DeleteHandler()
	{
		throw new NotImplementedException();
	}
}
