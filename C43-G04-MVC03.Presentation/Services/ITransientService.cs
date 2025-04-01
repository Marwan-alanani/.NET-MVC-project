namespace C43_G04_MVC03.Presentation.Services;

public interface ITransientService
{
    string GetGuid();
}

public class TransientService : ITransientService
{
    private Guid guid; // unique identifier. stands for global universal identifier

    public TransientService()
    {
        guid = Guid.NewGuid();
    }

    public string GetGuid() => guid.ToString();
}
