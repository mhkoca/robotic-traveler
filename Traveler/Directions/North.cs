namespace Traveler
{
    class North : ITurn
    {
        public Direction TurnLeft()
        {
            return Direction.W;
        }

        public Direction TurnRight()
        {
            return Direction.E;
        }

        public Location Move(Location currentLocation)
        {
            Location tempLocation = currentLocation;
            currentLocation.Y++;

            if (Area.IsInside(currentLocation))
                return currentLocation;
            else
                return tempLocation;
        }
    }
}
