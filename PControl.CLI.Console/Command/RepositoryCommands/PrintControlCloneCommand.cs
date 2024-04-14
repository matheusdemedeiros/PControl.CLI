using FluentResults;
using PControl.CLI.Console.Attributes;

namespace PControl.CLI.Console.Command.RepositoryCommands;

[CommandDocs(
  instruction: "clone:main",
  docs: "Faz o clone do projeto PrintControl na pasta de workspace."
)]
public class PrintControlCloneCommand : ICLICommand
{
    public Task<Result> ExecuteAsync()
    {
        throw new NotImplementedException();
    }
}
