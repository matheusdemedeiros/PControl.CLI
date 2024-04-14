namespace PControl.CLI.Domain;

public class ChildApi
{
  public string Name { get; set; }
  public string FullPath { get; set; }
  public string RestoreCommand { get; set; }
  public string BuildCommand { get; set; }
  public string RunCommand { get; set; }
}
