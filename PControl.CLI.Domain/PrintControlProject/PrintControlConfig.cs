namespace PControl.CLI.Domain;

public class PrintControlConfig
{
  public string WorkspaceFolder { get; set; }
  public string ProjectsFolder { get; set; }
  public string Repository { get; set; }
  public List<Service> Services { get; set; }
}
