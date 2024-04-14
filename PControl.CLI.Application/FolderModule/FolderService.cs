using System.Security.AccessControl;
using FluentResults;

namespace PControl.CLI.Application;

public class FolderService
{
  public async Task<Result<string>> DeleteFolder(string basePath, string folderToDelete)
  {
    var pathToDelete = Path.Combine(basePath, folderToDelete);
    if (!Path.Exists(pathToDelete))
    {
      return Result.Fail($"Não foi possível localizar o caminho {pathToDelete}");
    }
    try
    {
      Directory.Delete(pathToDelete, recursive: true);


      return Result.Ok($"Pasta {pathToDelete} removida com sucesso.");
    }
    catch (Exception ex)
    {
      return Result.Fail($"Falha ao tentar remover a pasta {pathToDelete}").WithError(ex.Message);
    }
  }
}
