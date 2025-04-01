namespace C43_G04_MVC03.Presentation.Services;

public interface ISingletonSerivce
{
    string GetGuid();
}

public class SingletonService : ISingletonSerivce
{
    private Guid guid; // unique identifier. stands for global universal identifier

    public SingletonService()
    {
        guid = Guid.NewGuid();
    }

    public string GetGuid() => guid.ToString();
}