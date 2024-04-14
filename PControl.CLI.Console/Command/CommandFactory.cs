﻿using System.Reflection;
using PControl.CLI.Console.Attributes;
using PControl.CLI.Console.Command.ClientComands;

namespace PControl.CLI.Console.Command;

public static class CLICommandFactory
{
  private static Dictionary<string, CommandDocs> _commandDocs;
  private static Dictionary<string, Type> _validCommands;
  public static ICLICommand? Factory(string[] args)
  {
    if (args is null || args.Length == 0)
    {
      return null;
    }

    var inputCommand = args[0].ToLower();

    switch(inputCommand){
      case "remove:dist": 
        return new RemoveDist();
      case "remove:nmodules": 
        return new RemoveNModules();
      case "build:ndk": 
        return new BuildClientsWithNDK();
      case "install:native": 
        return new InstallClientsWithNative();
      case "install:ndk": 
        return new InstallClientsWithNDK();
      default:
        return null;
    }
    // GetAcceptedCommands(typeof(ICLICommand).Assembly);
    // if (!_validCommands.ContainsKey(inputCommand))
    // {
    //   return null;
    // }

    // return (ICLICommand) Activator.CreateInstance(_validCommands[inputCommand]);
  }

  private static void GetAcceptedCommands(Assembly commandAssembly)
  {
    _validCommands = new Dictionary<string, Type>();
    var filteredTypes =
      commandAssembly.GetTypes()
      .Where(t => typeof(ICLICommand).IsAssignableFrom(t));

    foreach (var type in filteredTypes)
    {
      var commandDocsAttribute = (CommandDocs)type.GetCustomAttribute(typeof(CommandDocs), false);
      if (commandDocsAttribute is not null)
      {
        _validCommands.Add(commandDocsAttribute.Instruction, type);
      }
    }
  }

  private static void GetCommandDocs(Assembly commandAssembly)
  {
    _commandDocs = commandAssembly.GetTypes()
      .Where(command => command.GetCustomAttributes<CommandDocs>().Any())
      .Select(command => command.GetCustomAttribute<CommandDocs>()!)
      .ToDictionary(command => command.Instruction);
  }
}
