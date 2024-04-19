using CSharpFunctionalExtensions;
using PetFamily.Domain.Common;
using PetFamily.Domain.ValueObjects;

namespace PetFamily.Domain.Entities;

public class Pet
{
    public const int MAX_NAME_LENGTH = 100;
    public const int MAX_HEIGHT = 300;
    public const int MAX_DESCRIPTION_LENGTH = 300;

    private Pet()
    {
    }

    private Pet(
        string nickname,
        string description,
        DateTimeOffset birthDate,
        string breed,
        string color,
        Address address,
        Place place,
        bool castration,
        string peopleAttitude,
        string animalAttitude,
        bool onlyOneInFamily,
        string health,
        int? height,
        Weight weight,
        PhoneNumber contactPhoneNumber,
        PhoneNumber volunteerPhoneNumber,
        bool onTreatment,
        DateTimeOffset createdDate)
    {
        Nickname = nickname;
        Description = description;
        BirthDate = birthDate;
        Breed = breed;
        Color = color;
        Address = address;
        Place = place;
        Castration = castration;
        PeopleAttitude = peopleAttitude;
        AnimalAttitude = animalAttitude;
        OnlyOneInFamily = onlyOneInFamily;
        Health = health;
        Height = height;
        Weight = weight;
        ContactPhoneNumber = contactPhoneNumber;
        VolunteerPhoneNumber = volunteerPhoneNumber;
        OnTreatment = onTreatment;
        CreatedDate = createdDate;
    }

    public Guid Id { get; private set; }

    public string Nickname { get; private set; }
    public string Description { get; private set; }
    public string Breed { get; private set; }
    public string Color { get; private set; }
    public string PeopleAttitude { get; private set; }
    public string AnimalAttitude { get; private set; }
    public string Health { get; private set; }

    public Address Address { get; private set; }
    public Place Place { get; private set; }
    public Weight Weight { get; private set; }
    public PhoneNumber ContactPhoneNumber { get; private set; }
    public PhoneNumber VolunteerPhoneNumber { get; private set; }

    public bool Castration { get; private set; }
    public bool OnlyOneInFamily { get; private set; }
    public bool OnTreatment { get; private set; }

    public int? Height { get; private set; }

    public DateTimeOffset BirthDate { get; private set; }
    public DateTimeOffset CreatedDate { get; private set; }

    public IReadOnlyList<Vaccination> Vaccinations => _vaccinations;
    private readonly List<Vaccination> _vaccinations = [];

    public IReadOnlyList<Photo> Photos => _photos;
    private readonly List<Photo> _photos = [];

    public static Result<Pet, Error> Create(
        string nickname, 
        string description,
        string breed,
        string color,
        string peopleAttitude,
        string animalAttitude,
        string health,

        int height,

        DateTimeOffset birthDate,

        Address address,
        Place place,
        Weight weight,
        PhoneNumber contactPhoneNumber,
        PhoneNumber volunteerPhoneNumber,

        bool onTreatment,
        bool onlyOneInFamily,
        bool castration
        )       
    {
        if (nickname.IsEmpty() || nickname.Length > MAX_NAME_LENGTH)
            return Errors.General.InvalidLength(nameof(Nickname));

        if (description.IsEmpty() || nickname.Length > MAX_DESCRIPTION_LENGTH)
            return Errors.General.InvalidLength(nameof(Description));

        if (breed.IsEmpty())
            return Errors.General.InvalidLength(nameof(Breed));

        if (color.IsEmpty())
            return Errors.General.InvalidLength(nameof(Color));

        if (peopleAttitude.IsEmpty())
            return Errors.General.InvalidLength(nameof(PeopleAttitude));

        if (animalAttitude.IsEmpty())
            return Errors.General.InvalidLength(nameof(AnimalAttitude));

        if (height > MAX_HEIGHT ||  height<=0)
            return Errors.General.InvalidLength(nameof(Height));

        return new Pet(
            nickname,
            description,
            birthDate,
            breed,
            color,
            address,
            place,
            castration,
            peopleAttitude,
            animalAttitude,
            onlyOneInFamily,
            health,
            height,
            weight,
            contactPhoneNumber,
            volunteerPhoneNumber,
            onTreatment,
            DateTimeOffset.Now);
    }
}