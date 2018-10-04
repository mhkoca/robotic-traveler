namespace Traveler
{
    public static class Area
    {
        private static Location _startLocation = new Location(0, 0);
        private static Location _endLocation;

        public static Location StartLocation {
            get { return _startLocation; }
        }

        public static Location EndLocation {
            get { return _endLocation ?? new Location(0, 0); }
            set { _endLocation = value; }
        }

        public static bool IsInside(Location location)
        {
            return location.X <= EndLocation.X && location.Y <= EndLocation.Y;
        }
    }
}
