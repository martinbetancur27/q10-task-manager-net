namespace Q10.TaskManager.Infrastructure.Interfaces
{
    public interface ICacheRepository
    {
        string? Get(string key);
        void Set(string key, string? value);
        void Remove(string key);
        bool Exists(string key);
    }
}
