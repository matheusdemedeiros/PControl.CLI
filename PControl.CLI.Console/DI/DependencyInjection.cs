using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using PControl.CLI.Console.Attributes;
using PControl.CLI.Console.Command;
using PControl.CLI.Infra;

namespace PControl.CLI.Console.DI;

public static class DependencyInjection
{
  public static ServiceProvider ServiceProvider { get; private set; }

  public static void BuildServices()
  {
    var serviceCollection = new ServiceCollection()
       .AddSingleton<AppConfig>();

    RegisterCommands(serviceCollection);
    ServiceProvider = serviceCollection.BuildServiceProvider();

  }

  private static void RegisterCommands(IServiceCollection serviceCollection)
  {
    var filteredTypes = typeof(ICLICommand).Assembly.GetTypes()
    .Where(t => typeof(ICLICommand).IsAssignableFrom(t));

    foreach (var type in filteredTypes)
    {
      var commandDocsAttribute = (CommandDocs)type.GetCustomAttribute(typeof(CommandDocs), false);
      if (commandDocsAttribute is not null)
      {
        serviceCollection.AddTransient(type.GetType());
      }
    }
  }
}
