using System.Text.RegularExpressions;

namespace Traveler
{
    public class RouteCommand : ICommand
    {
        public RouteCommand(string route)
        {
            this.Command = route;
        }

        public string Pattern { get { return "([LRM]+)"; } }

        public string Command { get; set; }

        public bool Validate()
        {
            return Regex.IsMatch(Command, Pattern) && !Regex.IsMatch(Command, "([^LRM])") ;
        }
    }
}