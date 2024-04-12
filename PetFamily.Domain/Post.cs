namespace PetFamily.Domain;

public class Post
{
    private Post()
    {
    }
    
    public Post(
        string name,
        string breed,
        int height,
        bool vaccine,
        DateOnly birthDate,
        MainPhoto mainPhoto,
        string description,
        string adress)
    {
        Name = name;
        Breed = breed;
        Height = height;
        Vaccine = vaccine;
        BirthDate = birthDate;
        MainPhoto = mainPhoto;
        Description = description;
        Adress = adress;
    }
    
    public Guid Id { get; private set; }

    public string Name { get; private set; }

    public string Breed { get; private set; }

    public Weight Weight { get; private set; }

    public int Height { get; private set; }

    public bool Vaccine { get; private set; }

    public DateOnly BirthDate { get; private set; }

    public MainPhoto MainPhoto { get; private set; }

    public string Description { get; private set; }
    
    public string Adress { get; private set; }
    
    public List<Photo> Photos { get; private set; } = [];
}
