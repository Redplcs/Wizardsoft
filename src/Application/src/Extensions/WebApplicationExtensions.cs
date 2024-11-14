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

	private static IResult CreateHandler(
		[FromQuery] Guid? id,
		[FromQuery(Name = "parent")] Guid? parentId,
		[FromQuery(Name = "children")] Guid[]? childrenIds,
		[FromServices] ITreeItemRepository repository)
	{
		var item = TreeItem.Create(id);

		if (parentId.HasValue)
		{
			var parent = repository.GetById(parentId.Value);

			if (parent is null)
			{
				return Results.NotFound();
			}

			item.Parent = parent;
		}

		if (childrenIds is not null)
		{
			foreach (var childGuid in childrenIds)
			{
				var child = repository.GetById(childGuid);

				if (child is null)
				{
					return Results.NotFound();
				}

				item.Children.Add(child);
			}
		}

		repository.Create(item);

		return Results.Ok(item);
	}

	private static IEnumerable<TreeItem> GetAllHandler(
		[FromServices] ITreeItemRepository repository)
	{
		return repository.GetAll();
	}

	private static TreeItem? GetByIdHandler(
		[FromQuery] Guid id,
		[FromServices] ITreeItemRepository repository)
	{
		return repository.GetById(id);
	}

	private static IResult UpdateHandler(
		[FromQuery] Guid id,
		[FromQuery] Guid? newParent,
		[FromQuery] Guid[]? newChildren,
		[FromServices] ITreeItemRepository repository)
	{
		var item = repository.GetById(id);

		if (item is null)
		{
			return Results.NotFound();
		}

		if (newParent.HasValue)
		{
			var parent = repository.GetById(newParent.Value);

			if (parent is null)
			{
				return Results.NotFound();
			}

			item.Parent = parent;
		}

		if (newChildren is not null)
		{
			foreach (var childGuid in newChildren)
			{
				var child = repository.GetById(childGuid);

				if (child is null)
				{
					return Results.NotFound();
				}

				item.Children.Add(child);
			}
		}

		repository.Update(item);

		return Results.Ok(item);
	}

	private static IResult DeleteHandler(
		[FromQuery] Guid id,
		[FromServices] ITreeItemRepository repository)
	{
		var item = repository.GetById(id);

		if (item is null)
		{
			return Results.NotFound();
		}

		repository.Delete(item);

		return Results.Ok();
	}
}
