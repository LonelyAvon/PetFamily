namespace Contracts.Requests;

public record CreatePetRequest(
    string Nickname,
    string Color,
    string City,
    string Street,
    string Building,
    string Index,
    string Place,
    float Weight,
    bool OnlyOneInFamily,
    string Health,
    string ContactPhoneNumber,
    string VolunteerPhoneNumber,
    bool onTreatment);