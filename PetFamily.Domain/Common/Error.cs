namespace PetFamily.Domain.Common;

public class Error
{
    public string Code { get; set; }

    public string Message { get; set; }

    public Error(string code, string message)
    {
        Code = code;
        Message = message;
    }
}

public static class Errors
{
    public static class General
    {
        public static Error NotFound(Guid? id = null)
        {
            var forId = id == null ? "" : $" for Id '{id}'";
            return new("record.not.found", $"Record not found{forId}");
        }
        
        public static Error ValueIsInvalid(string name) =>
            new("value.is.invalid", $"{name} is invalid");

        public static Error ValueIsRequried(string? name = null)
        {
            var label = name == null ? "Value " : name + " ";
            return new("value.is.required", $"{name} is required");
        }

        public static Error InvalidLength(string? name = null)
        {
            var label = name == null ? " " : " " + name + " ";
            return new("invalid.string.length", $"Invalid{label}length");
        }
    }
    
    public static class Place
    {
        public static Error ValueIsRequried() =>
            new("place.is.required", "Place is required");
    }
    public static class BirthDate
    {
        public static Error ValueIsUnderYears() =>
            new("birthdate.is.under", "You must be over 18 y.o.");
    }
}