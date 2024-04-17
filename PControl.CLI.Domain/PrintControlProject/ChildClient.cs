namespace PControl.CLI.Domain;

[Serializable]
public class ChildClient
{
  public string Name { get; set; }
  public string FullPath { get; set; }
  public string InstallCommand { get; set; }
  public string BuildCommand { get; set; }
  public string NdkBuildCommand { get; set; }
  public string StartCommand { get; set; }
  public string RemoveDistCommand { get; set; }
  public string RemoveNodeModulesCommand { get; set; }
}
