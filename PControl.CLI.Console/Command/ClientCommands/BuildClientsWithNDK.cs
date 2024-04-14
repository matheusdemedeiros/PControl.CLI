using FluentResults;
using PControl.CLI.Console.Attributes;

namespace PControl.CLI.Console.Command.ClientComands;

[CommandDocs(
  instruction: "build:ndk",
  docs: "Faz o build de todos os clients do projeto usando o NDK."
)]
public class BuildClientsWithNDK : ICLICommand
{
    public Task<Result> ExecuteAsync()
    {
        throw new NotImplementedException();
    }
}
