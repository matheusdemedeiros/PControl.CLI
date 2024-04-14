using FluentResults;
using PControl.CLI.Application;
using PControl.CLI.Console.Attributes;
using PControl.CLI.Console.Command;
using PControl.CLI.Domain;

namespace PControl.CLI.Console;

[CommandDocs(
  instruction: "remove:main",
  docs: "Apaga a o repositorio 'nddPrintControl' principal com todo o seu conteudo."
)]
public class RemovePrintControlRepoCommand : ICLICommand
{
  private FolderService folderService;
  private PrintControlConfig config;

  public RemovePrintControlRepoCommand(FolderService folderService, PrintControlConfig config)
  {
    this.folderService = folderService;
    this.config = config;
  }

  public Task<Result<string>> ExecuteAsync()
  {
    var basePath = config.WorkspaceFolder;
    var folderToDelete = "nddPrintControl";
    return folderService.DeleteFolder(basePath, folderToDelete);
  }
}
