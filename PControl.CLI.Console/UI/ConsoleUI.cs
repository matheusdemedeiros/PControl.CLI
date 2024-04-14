using FluentResults;

namespace PControl.CLI.Console.UI;

public static class ConsoleUI
{
  public static void ShowResult(Result result)
  {
    try
    {
      if (result.IsFailed)
      {
        ShowFail(result);
      }
      else
      {
        ShowSuccess(result);
      }
    }
    finally
    {
      System.Console.ResetColor();
    }

  }

  private static void ShowSuccess(Result result)
  {
    var success = result.Successes.First();
    System.Console.ForegroundColor = ConsoleColor.Green;
    System.Console.WriteLine(success);
  }

  private static void ShowFail(Result result)
  {
    System.Console.ForegroundColor = ConsoleColor.Red;
    var error = result.Errors.First();
    System.Console.WriteLine($"Erro: {error.Message}");
  }
}
