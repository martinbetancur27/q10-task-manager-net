namespace Q10.TaskManager.Infrastructure.Interfaces
{
    public interface IConfig
    {
        string GetValue(string key);
    }
}