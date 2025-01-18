namespace Barrage;

internal static class ThrowHelper
{
    public static void ThrowOutOfRangeException()
    {
        throw new ArgumentOutOfRangeException();
    }

    public static void ThrowIndexOutOfRangeException()
    {
        throw new IndexOutOfRangeException();
    }

    public static void ThrowArchetypeWithDuplicateComponents()
    {
        throw new ArgumentException("Cannot create an archetype with duplicate components.");
    }

    public static void ThrowDestinationIsTooShort()
    {
        throw new ArgumentException("Destination is too short.", "destination");
    }

    public static void ThrowChunkIsFull()
    {
        throw new InvalidOperationException("The chunk is full.");
    }

    public static void ThrowEntityDoesNotExists()
    {
        throw new ArgumentException("The entity does not exist.");
    }

    public static void ThrowCannotAddEntityAsComponent()
    {
        throw new ArgumentException("Cannot add Entity as a component.");
    }

    public static void ThrowComponentHasNotBeenAddedToEntity(Type type)
    {
        throw new ArgumentException($"A component with type:{type.FullName} has not been added to the entity.");
    }

    public static void ThrowArchetypeDoesNotHaveComponent(Type type)
    {
        throw new ArgumentException($"Archetype does not have component {type.FullName}.");
    }
}