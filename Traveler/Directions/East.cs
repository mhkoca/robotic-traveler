namespace Traveler
{
    class East : ITurn
    {
        public Direction TurnLeft()
        {
            return Direction.N;
        }

        public Direction TurnRight()
        {
            return Direction.S;
        }

        public Location Move(Location currentLocation)
        {
            Location tempLocation = currentLocation;
            currentLocation.X++;

            if (Area.IsInside(currentLocation))
                return currentLocation;
            else
                return tempLocation;
        }
    }
}
