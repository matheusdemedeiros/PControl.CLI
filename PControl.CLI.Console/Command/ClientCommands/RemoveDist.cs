using FluentResults;
using PControl.CLI.Console.Attributes;

namespace PControl.CLI.Console.Command.ClientComands;

[CommandDocs(
  instruction: "remove:dist",
  docs: "Apaga a pasta dist de todos os clients do projeto."
)]
public class RemoveDist : ICLICommand
{
  public Task<Result<string>> ExecuteAsync()
  {
    return RemoveDistFolderFromAllClientsAsync();
  }

  private async Task<Result<string>> RemoveDistFolderFromAllClientsAsync(){
    return Result.Ok().WithSuccess("sucesso!");
  }

}
