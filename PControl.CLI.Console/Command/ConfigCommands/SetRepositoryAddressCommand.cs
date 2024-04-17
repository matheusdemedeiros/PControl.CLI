using FluentResults;
using PControl.CLI.Console.Attributes;
using PControl.CLI.Infra;

namespace PControl.CLI.Console.Command.ConfigCommands
{
    [CommandDocs(
        instruction: "set:repository",
        docs: "Define o endereço remoto do repositório nddPrintControl."
        )]
    public class SetRepositoryAddressCommand : ICLICommand
    {
        private AppConfig appConfig;
        private string newRepositoryAddress;

        public SetRepositoryAddressCommand(AppConfig config, string newRepositoryAddress)
        {
            this.appConfig = config;
            this.newRepositoryAddress = newRepositoryAddress;
        }

        public async Task<Result<string>> ExecuteAsync()
        {
            if (string.IsNullOrEmpty(newRepositoryAddress))
            {
                return Result.Fail($"Informe o novo endereço remoto do repositório nddPrintControl.");
            }

            try
            {
                appConfig.Config.SetRepositoryAddressFolder(newRepositoryAddress);
                appConfig.SaveInServicesFile(appConfig.Config);

                return Result.Ok($"Caminho do repositório remoto alterado para {newRepositoryAddress}");
            }
            catch (Exception ex)
            {
                return Result.Fail($"Falha ao alterar o caminho do repositório remoto.").WithError(ex.Message);
            }
        }
    }
}
