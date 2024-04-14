using FluentResults;
using PControl.CLI.Application;
using PControl.CLI.Console.Attributes;

namespace PControl.CLI.Console.Command.RepositoryCommands;

[CommandDocs(
  instruction: "clone:main",
  docs: "Faz o clone do projeto PrintControl na pasta de workspace."
)]
public class PrintControlCloneCommand : ICLICommand
{
  private GitService gitService;

  public PrintControlCloneCommand(GitService gitService)
  {
    this.gitService = gitService;
  }

  public Task<Result<string>> ExecuteAsync()
  {
    return gitService.ClonePrintControlRepo();
  }
}
