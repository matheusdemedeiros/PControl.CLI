using FluentResults;
using PControl.CLI.Console.Attributes;
using PControl.CLI.Infra;

namespace PControl.CLI.Console.Command.ConfigCommands
{
    [CommandDocs(
        instruction: "set:workspace",
        docs: "Define o endereço da pasta workspace (pasta em que o repositório está clonado)."
        )]
    public class SetWorkspaceFolderCommand : ICLICommand
    {
        private AppConfig appConfig;
        private string newWorkspacePath;

        public SetWorkspaceFolderCommand(AppConfig config, string newWorkspacePath)
        {
            this.appConfig = config;
            this.newWorkspacePath = newWorkspacePath;
        }

        public async Task<Result<string>> ExecuteAsync()
        {
            if (string.IsNullOrEmpty(newWorkspacePath))
            {
                return Result.Fail($"Informe o novo caminho de workspace (pasta em que o repositório está clonado).");
            }

            if (!Directory.Exists(newWorkspacePath))
            {
                return Result.Fail($"O caminho {newWorkspacePath} não foi encontrado.");
            }

            try
            {
                appConfig.Config.SetWorkspaceFolder(newWorkspacePath);
                appConfig.SaveInServicesFile(appConfig.Config);

                return Result.Ok($"Caminho da workspace projects alterado para {newWorkspacePath}");
            }
            catch (Exception ex)
            {
                return Result.Fail($"Falha ao alterar o caminho da pasta workspace.").WithError(ex.Message);
            }
        }
    }
}
