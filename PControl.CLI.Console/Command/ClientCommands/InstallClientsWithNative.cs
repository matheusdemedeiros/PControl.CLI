using FluentResults;
using PControl.CLI.Console.Attributes;

namespace PControl.CLI.Console.Command.ClientComands;

[CommandDocs(
  instruction: "install:native",
  docs: "Instala as dependencias de todos os clients do projeto usando o npm diretamente."
)]
public class InstallClientsWithNative : ICLICommand
{
    public Task<Result<string>> ExecuteAsync()
    {
        throw new NotImplementedException();
    }
}
