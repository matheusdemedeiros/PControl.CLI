namespace PControl.CLI.Domain;

[Serializable]
public class PrintControlConfig
{
  public string WorkspaceFolder { get; set; }
  public string ProjectsFolder { get; set; }
  public string Repository { get;  set; }
  public List<Service> Services { get; set; }

    public void SetProjectsFolder (string newProjectsPath)
    {
        ProjectsFolder = newProjectsPath;
    }

    public void SetWorkspaceFolder(string newWorkspacePath)
    {
        WorkspaceFolder = newWorkspacePath;
    }

    public void SetRepositoryAddressFolder(string newRepositoryAddress)
    {
        Repository = newRepositoryAddress;
    }
}
