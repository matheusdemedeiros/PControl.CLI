namespace PControl.CLI.Console.Attributes;

[AttributeUsage(AttributeTargets.Class)]
public sealed class CommandDocs : Attribute
{
  public CommandDocs(string instruction, string docs)
  {
    Instruction = instruction;
    Docs = docs;
  }

  public string Instruction { get; set; }
  public string Docs { get; set; }

}
