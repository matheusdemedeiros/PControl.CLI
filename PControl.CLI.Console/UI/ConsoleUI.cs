using FluentResults;

namespace PControl.CLI.Console.UI;

public static class ConsoleUI
{
  public static void ShowResult(Result<string> result)
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

  private static void ShowSuccess(Result<string> result)
  {
    System.Console.ForegroundColor = ConsoleColor.Green;

    if (result.Successes.Any())
    {
      result.Successes.ForEach(succes => System.Console.WriteLine($"Sucesso: {succes.Message}"));
    }
  }

  private static void ShowFail(Result<string> result)
  {
    System.Console.ForegroundColor = ConsoleColor.Red;
    if (result.Errors.Any())
    {
      result.Errors.ForEach(error => System.Console.WriteLine($"Erro: {error.Message}"));
    }
  }
}
