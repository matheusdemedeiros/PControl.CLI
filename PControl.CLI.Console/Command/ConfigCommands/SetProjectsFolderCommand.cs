using FluentResults;
using PControl.CLI.Console.Attributes;
using PControl.CLI.Infra;

namespace PControl.CLI.Console.Command.ConfigCommands
{

    [CommandDocs(
        instruction: "set:projects",
        docs: "Define o endereço da pasta projects"
        )]
    public class SetProjectsFolderCommand : ICLICommand
    {

        private AppConfig appConfig;
        private string newProjectsPath;

        public SetProjectsFolderCommand(AppConfig config, string newProjectsPath)
        {
            this.appConfig = config;
            this.newProjectsPath = newProjectsPath;
        }

        public async Task<Result<string>> ExecuteAsync()
        {
            System.Console.WriteLine(newProjectsPath);

            if (string.IsNullOrEmpty(newProjectsPath))
            {
                return Result.Fail($"Informe o novo caminho da pasta projects.");
            }

            if (!Directory.Exists(newProjectsPath))
            {
                return Result.Fail($"O caminho {newProjectsPath} não foi encontrado.");
            }

            try
            {
                System.Console.WriteLine(appConfig.Config.ProjectsFolder);
                System.Console.WriteLine(appConfig.Config.WorkspaceFolder);
                System.Console.WriteLine(appConfig.ServicesFile);


                appConfig.Config.SetProjectsFolder(newProjectsPath);
                appConfig.SaveInServicesFile(appConfig.Config);

                return Result.Ok($"Caminho da pasta projects alterado para {newProjectsPath}");
            }
            catch (Exception ex)
            {
                return Result.Fail($"Falha ao alterar o caminho da pasta projects.").WithError(ex.Message);
            }
        }
    }
}
