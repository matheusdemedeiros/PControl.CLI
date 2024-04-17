using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using PControl.CLI.Application;
using PControl.CLI.Console.Attributes;
using PControl.CLI.Console.Command.ClientComands;
using PControl.CLI.Console.Command.RepositoryCommands;
using PControl.CLI.Console.Command.ServiceCommands;
using PControl.CLI.Console.DI;
using PControl.CLI.Infra;

namespace PControl.CLI.Console.Command;

public static class CLICommandFactory
{
  private static Dictionary<string, CommandDocs> _commandDocs;
  private static Dictionary<string, Type> _validCommands;
  public static ICLICommand? Factory(string[] args)
  {
    if (args is null || args.Length == 0)
    {
      return null;
    }

    var inputCommand = args[0].ToLower();
    var pControlConfig = DependencyInjection.ServiceProvider.GetRequiredService<AppConfig>();

    switch (inputCommand)
    {
      case "remove:dist":
        return new RemoveDist(new FolderService(), pControlConfig.Config);
      case "remove:nmodules":
        return new RemoveNModules(new FolderService(), pControlConfig.Config);
      case "build:ndk":
        return new BuildClientsWithNDK();
      case "install:native":
        return new InstallClientsWithNative();
      case "install:ndk":
        return new InstallClientsWithNDK();
      case "clone:main":
        var terminalService = new TerminalService();
        var gitService = new GitService(pControlConfig.Config, terminalService);
        return new PrintControlCloneCommand(gitService);
      case "remove:main":
        return new RemovePrintControlRepoCommand(new FolderService(), pControlConfig.Config);
      case "services:load":
        return new LoadAllServicesCommand(new TerminalService(), pControlConfig.Config);
      default:
        return null;
    }
    // GetAcceptedCommands(typeof(ICLICommand).Assembly);
    // if (!_validCommands.ContainsKey(inputCommand))
    // {
    //   return null;
    // }

    // return (ICLICommand) Activator.CreateInstance(_validCommands[inputCommand]);
  }

  private static void GetAcceptedCommands(Assembly commandAssembly)
  {
    _validCommands = new Dictionary<string, Type>();
    var filteredTypes =
      commandAssembly.GetTypes()
      .Where(t => typeof(ICLICommand).IsAssignableFrom(t));

    foreach (var type in filteredTypes)
    {
      var commandDocsAttribute = (CommandDocs)type.GetCustomAttribute(typeof(CommandDocs), false);
      if (commandDocsAttribute is not null)
      {
        _validCommands.Add(commandDocsAttribute.Instruction, type);
      }
    }
  }

  private static void GetCommandDocs(Assembly commandAssembly)
  {
    _commandDocs = commandAssembly.GetTypes()
      .Where(command => command.GetCustomAttributes<CommandDocs>().Any())
      .Select(command => command.GetCustomAttribute<CommandDocs>()!)
      .ToDictionary(command => command.Instruction);
  }
}
