namespace PetFamily.Domain.Entities;

public class Photo
{
    private Photo()
    {
    }
    
    public Photo(Guid id, string path)
    {
        Id = id;
        Path = path;
    }

    public Guid Id { get; private set; }

    public string Path { get; private set; }

    public bool IsMain { get; private set; }
}