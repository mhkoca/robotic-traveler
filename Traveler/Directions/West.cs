namespace Traveler
{
    class West : ITurn
    {
        public Direction TurnLeft()
        {
            return Direction.S;
        }

        public Direction TurnRight()
        {
            return Direction.N;
        }

        public Location Move(Location currentLocation)
        {
            Location tempLocation = currentLocation;
            currentLocation.X--;

            if (Area.IsInside(currentLocation))
                return currentLocation;
            else
                return tempLocation;
        }
    }
}
