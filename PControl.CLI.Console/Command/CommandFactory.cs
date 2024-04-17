using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using PControl.CLI.Application;
using PControl.CLI.Console.Attributes;
using PControl.CLI.Console.Command.ClientComands;
using PControl.CLI.Console.Command.ConfigCommands;
using PControl.CLI.Console.Command.RepositoryCommands;
using PControl.CLI.Console.Command.ServiceCommands;
using PControl.CLI.Console.DI;
using PControl.CLI.Infra;

namespace PControl.CLI.Console.Command;

public static class CLICommandFactory
{
    private static Dictionary<string, CommandDocs> _commandDocs;
    public static ICLICommand? Factory(string[] args)
    {
        if (args is null || args.Length == 0)
        {
            return null;
        }

        var inputCommand = args[0].ToLower();
        var appConfig = DependencyInjection.ServiceProvider.GetRequiredService<AppConfig>();

        switch (inputCommand)
        {
            case "remove:dist":
                return new RemoveDist(new FolderService(), appConfig.Config);
            case "remove:nmodules":
                return new RemoveNModules(new FolderService(), appConfig.Config);
            case "build:ndk":
                return new BuildClientsWithNDK();
            case "install:native":
                return new InstallClientsWithNative();
            case "install:ndk":
                return new InstallClientsWithNDK();
            case "clone:main":
                var terminalService = new TerminalService();
                var gitService = new GitService(appConfig.Config, terminalService);
                return new PrintControlCloneCommand(gitService);
            case "remove:main":
                return new RemovePrintControlRepoCommand(new FolderService(), appConfig.Config);
            case "services:load":
                return new LoadAllServicesCommand(new TerminalService(), appConfig.Config);
            case "set:projects":
                var newProjectsPath = args[1] ?? "";
                return new SetProjectsFolderCommand(appConfig, newProjectsPath);
            case "set:workspace":
                var newWorkspacePath = args[1] ?? "";
                return new SetWorkspaceFolderCommand(appConfig, newWorkspacePath);
            case "set:repository":
                var newRepositoryAddress = args[1] ?? "";
                return new SetRepositoryAddressCommand(appConfig, newRepositoryAddress);
            default:
                return null;
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
