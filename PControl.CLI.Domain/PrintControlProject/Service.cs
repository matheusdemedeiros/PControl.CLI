namespace PControl.CLI.Domain;

public class Service
{
  public string Name { get; set; }
  public string Path { get; set; }
  public string LoadCommand { get; set; }
  public List<ChildApi> ChildApis { get; set; }
  public List<ChildClient> ChildClients { get; set; }

}
