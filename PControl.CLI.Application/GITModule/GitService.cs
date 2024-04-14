using FluentResults;
using PControl.CLI.Domain;

namespace PControl.CLI.Application;

public class GitService
{
  private readonly PrintControlConfig config;
  private readonly TerminalService terminalService;

  public GitService(PrintControlConfig config, TerminalService terminalService)
  {
    this.config = config;
    this.terminalService = terminalService;
  }

  public async Task<Result<string>> ClonePrintControlRepo()
  {
    var repo = config.Repository;
    var workspace = config.WorkspaceFolder;
    if (!Path.Exists(workspace))
    {
      return Result.Fail($"Não foi possível localizar o caminho {workspace}");
    }

    if (Directory.Exists(Path.Combine(workspace, "nddPrintControl")))
    {
      return Result.Fail($"O repositorio nddPrintControl já existe na pasta {workspace}");
    }
    var command = $"git clone {repo}";

    return await terminalService.ExecuteCommand(command, workspace);
  }
}
