using FluentResults;
using PControl.CLI.Console.Attributes;

namespace PControl.CLI.Console.Command.ClientComands;

[CommandDocs(
  instruction: "remove:nmodules",
  docs: "Apaga a pasta node_modules de todos os clients do projeto."
)]
public class RemoveNModules : ICLICommand
{
  public Task<Result> ExecuteAsync()
  {
    throw new NotImplementedException();
  }
}
