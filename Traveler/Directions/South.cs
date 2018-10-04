namespace Traveler
{
    class South : ITurn
    {
        public Direction TurnLeft()
        {
            return Direction.E;
        }

        public Direction TurnRight()
        {
            return Direction.W;
        }

        public Location Move(Location currentLocation)
        {
            Location tempLocation = currentLocation;
            currentLocation.Y--;

            if (Area.IsInside(currentLocation))
                return currentLocation;
            else
                return tempLocation;
        }
    }
}
