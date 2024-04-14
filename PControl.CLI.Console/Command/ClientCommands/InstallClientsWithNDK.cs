using FluentResults;
using PControl.CLI.Console.Attributes;

namespace PControl.CLI.Console.Command.ClientComands;

[CommandDocs(
  instruction: "install:ndk",
  docs: "Instala as dependencias de todos os clients do projeto usando o NDK."
)]
public class InstallClientsWithNDK : ICLICommand
{
    public Task<Result<string>> ExecuteAsync()
    {
        throw new NotImplementedException();
    }
}
