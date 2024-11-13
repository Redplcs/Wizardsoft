namespace Redplcs.Wizardsoft.Application.Extensions;

public static class WebApplicationExtensions
{
    public static WebApplication MapGetCrudEndpoints(this WebApplication app)
    {
        app.MapGet("/create", CreateHandler);
        app.MapGet("/read", ReadHandler);
        app.MapGet("/update", UpdateHandler);
        app.MapGet("/delete", DeleteHandler);

        return app;
    }

    private static void CreateHandler()
    {
        throw new NotImplementedException();
    }

    private static void ReadHandler()
    {
        throw new NotImplementedException();
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
