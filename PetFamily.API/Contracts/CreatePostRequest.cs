namespace PetFamily.API.Contracts;

public record CreatePostRequest(
    string Name,
    string Breed,
    float Weight,
    int Height,
    bool Vaccine,
    DateOnly BirthDate,
    string Photo,
    string Description,
    string Adress);