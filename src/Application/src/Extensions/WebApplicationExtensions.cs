﻿using Microsoft.AspNetCore.Mvc;
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

	private static TreeItem CreateHandler(
		[FromServices] ITreeItemRepository repository)
	{
		var item = TreeItem.Create();
		repository.Create(item);

		return item;
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

	private static void UpdateHandler()
	{
		throw new NotImplementedException();
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
