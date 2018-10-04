namespace Traveler
{
    public static class CommandFactory
    {
        private static CornerCommand _cornerCommandInstance = null;
        private static LocationCommand _locationCommandInstance = null;
        private static RouteCommand _routeCommandInstance = null;

        public static ICommand GetCommand(CommandType commandType, string command)
        {
            switch (commandType)
            {
                case CommandType.Corner:
                    return CornerCommandInstance(command);
                case CommandType.Location:
                    return LocationCommandInstance(command);
                case CommandType.Route:
                    return RouteCommandInstance(command);
                default:
                    return null;
            }
        }

        private static CornerCommand CornerCommandInstance(string command)
        {
            if (_cornerCommandInstance == null)
            {
                return new CornerCommand(command);
            }
            else
            {
                _cornerCommandInstance.Command = command;
                return _cornerCommandInstance;
            }
        }

        private static LocationCommand LocationCommandInstance(string command)
        {
            if (_locationCommandInstance == null)
            {
                return new LocationCommand(command);
            }
            else
            {
                _locationCommandInstance.Command = command;
                return _locationCommandInstance;
            }
        }

        private static RouteCommand RouteCommandInstance(string command)
        {
            if (_routeCommandInstance == null)
            {
                return new RouteCommand(command);
            }
            else
            {
                _routeCommandInstance.Command = command;
                return _routeCommandInstance;
            }
        }

    }
}
