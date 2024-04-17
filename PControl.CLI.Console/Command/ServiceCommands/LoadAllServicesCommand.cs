using PControl.CLI.Console.Attributes;
using FluentResults;
using PControl.CLI.Domain;
using PControl.CLI.Application;

namespace PControl.CLI.Console.Command.ServiceCommands
{
    [CommandDocs(
        instruction: "services:load",
        docs: "Faz o load de todos os submodulos - git presentes no projeto."
    )]
    public class LoadAllServicesCommand : ICLICommand
    {

        private PrintControlConfig config;
        private TerminalService terminalService;

        public LoadAllServicesCommand(TerminalService terminalService, PrintControlConfig config)
        {
            this.terminalService = terminalService;
            this.config = config;
        }

        public async Task<Result<string>> ExecuteAsync()
        {
            var services = config.Services;
            if(!services.Any()){
                return Result.Fail($"Nenhum serviço encontrado no caminho {config.ProjectsFolder}");
            }

            try
            {
                foreach (var service in services)
                {
                    var loadCommand = service.LoadCommand;

                    terminalService.ExecuteCommand(service.LoadCommand, config.ProjectsFolder);
                }

                return Result.Ok($"Comando executado com sucesso.");
            }
            catch (Exception ex)
            {
                return Result.Fail($"Falha ao tentar executar o comando de load").WithError(ex.Message);
            }
        }
    }
}
