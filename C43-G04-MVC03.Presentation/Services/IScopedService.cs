namespace C43_G04_MVC03.Presentation.Services;

public interface IScopedService
{
    string GetGuid();
}

public class ScopedService : IScopedService
{
    private Guid guid; // unique identifier. stands for global universal identifier

    public ScopedService()
    {
        guid = Guid.NewGuid();
    }

    public string GetGuid() => guid.ToString();
}