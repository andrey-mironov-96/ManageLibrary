namespace Domain.Exceptions
{
    public class NoShelfPlaceException(Guid guid) : Exception($"No shelf place in bookcase {guid}")
    {
    }
}