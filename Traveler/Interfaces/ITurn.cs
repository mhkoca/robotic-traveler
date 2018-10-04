namespace Traveler
{
    interface ITurn
    {
        Direction TurnRight();
        Direction TurnLeft();
        Location Move(Location currentLocation);
    }
}
