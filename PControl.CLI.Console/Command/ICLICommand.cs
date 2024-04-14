using FluentResults;

namespace PControl.CLI.Console.Command;

public interface ICLICommand
{
  Task<Result> ExecuteAsync();
}
