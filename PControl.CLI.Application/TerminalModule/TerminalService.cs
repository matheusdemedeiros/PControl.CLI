
using System.Diagnostics;
using FluentResults;

namespace PControl.CLI.Application;

public class TerminalService
{
  public async Task<Result<string>> ExecuteCommand(string mainCommand, string pathToExecute)
  {
    var splitedCommand = mainCommand.Trim().Split(" ");
    var command = splitedCommand[0];
    var args = mainCommand.Substring(command.Length).ToString().TrimStart().TrimEnd();

    try
    {
      RunCommand(command, args, pathToExecute);
      return Result.Ok($"Comando {command} executado com suceso.").WithSuccess($"Comando {command} executado com suceso.");

    }
    catch (Exception ex)
    {

      return Result.Fail($"Falha ao tentar executar o comando {command}").WithError(ex.Message);
    }

  }

  private static void RunCommand(string command, string args, string pathToExecute)
  {
    var process = new Process();

    process.StartInfo.FileName = command;
    process.StartInfo.Arguments = args;
    // set additional process start info as necessary
    process.StartInfo.UseShellExecute = false;
    process.StartInfo.RedirectStandardOutput = true;
    process.StartInfo.WorkingDirectory = pathToExecute;
    // start the process
    process.Start();

    string output = process.StandardOutput.ReadToEnd();

    process.WaitForExit();
  }
}
