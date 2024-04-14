
using FluentResults;
using Microsoft.Extensions.DependencyInjection;
using PControl.CLI.Console.Command;
using PControl.CLI.Console.DI;
using PControl.CLI.Console.UI;
using PControl.CLI.Infra;

DependencyInjection.BuildServices();
var pControlConfig = DependencyInjection.ServiceProvider.GetRequiredService<AppConfig>();

ICLICommand? command = CLICommandFactory.Factory(args);
if (command is not null)
{
    var result = await command.ExecuteAsync();
    ConsoleUI.ShowResult(result);
}
else
{
    ConsoleUI.ShowResult(Result.Fail("Comando inválido!"));
}         
