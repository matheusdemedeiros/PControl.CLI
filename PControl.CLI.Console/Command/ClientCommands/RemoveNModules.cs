using FluentResults;
using PControl.CLI.Application;
using PControl.CLI.Console.Attributes;
using PControl.CLI.Domain;

namespace PControl.CLI.Console.Command.ClientComands;

[CommandDocs(
  instruction: "remove:nmodules",
  docs: "Apaga a pasta node_modules de todos os clients do projeto."
)]
public class RemoveNModules : ICLICommand
{

  private FolderService folderService;
  private PrintControlConfig config;

    public RemoveNModules(FolderService folderService, PrintControlConfig config)
    {
        this.folderService = folderService;
        this.config = config;
    }

    public async Task<Result<string>> ExecuteAsync()
  {
    var basePath = config.ProjectsFolder;
    var folderToDelete = "node_modules";
    var tasks = new List<Task>();

    foreach (var service in config.Services)
    {
      var clientsFromService = service.ChildClients;
      foreach (var client in clientsFromService)
      {
        var pathToDelete = Path.Join(basePath, service.Path, client.FullPath, folderToDelete);
        if (!Directory.Exists(pathToDelete))
        {
          break;
        }
        tasks.Add(folderService.DeleteFolder(service.Path, pathToDelete));
      }
    }

    await Task.WhenAll(tasks);

    return Result.Ok("Todas as pastas node_modules foram apagadas com sucesso!");
  }
}
