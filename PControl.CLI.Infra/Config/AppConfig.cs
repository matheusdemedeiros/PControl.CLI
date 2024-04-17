using Newtonsoft.Json;
using PControl.CLI.Domain;

namespace PControl.CLI.Infra;

public class AppConfig
{
    private PrintControlConfig _config;
    private string _servicesFile = Path.Combine(AppContext.BaseDirectory, "services.json");

    public AppConfig()
    {
        using (StreamReader file = File.OpenText(ServicesFile))
        {
            var serializer = new JsonSerializer();
            Config = (PrintControlConfig)serializer.Deserialize(file, typeof(PrintControlConfig));
        }
    }

    public PrintControlConfig Config { get => _config; set => _config = value; }
    public string ServicesFile { get => _servicesFile; set => _servicesFile = value; }

    public void SaveInServicesFile(PrintControlConfig newConfig)
    {
        var serializer = new JsonSerializer();

        using (StreamWriter file = File.CreateText(ServicesFile))
        {
            serializer.Serialize(file, newConfig);
        }
    }
}
