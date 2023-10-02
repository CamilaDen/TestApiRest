using NLog;
using NLog.Web;
using TestApiRest;
var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
logger.Debug("init main");
try
{
    var builder = WebApplication.CreateBuilder(args);
    builder.Logging.ClearProviders();
    builder.Host.UseNLog();
    var startup = new Startup(builder.Configuration);
    startup.ConfigureServices(builder.Services);
    var app = builder.Build();
    startup.Configure(app, app.Environment);

    app.Run();

}
catch (Exception ex)
{
    logger.Error(ex, "El programa se detuvo porque hubo una excepcion");
	throw;
}
finally
{
    NLog.LogManager.Shutdown();
}
