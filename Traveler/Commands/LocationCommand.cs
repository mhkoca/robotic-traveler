using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Traveler
{
    public class LocationCommand : ICommand
    {
        public LocationCommand(string corner)
        {
            this.Command = corner;
        }

        public string Pattern { get { return "([0-9]+[ ][0-9]+[ ][NWES])"; } }

        public string Command { get; set; }

        public bool Validate()
        {
            var commandArray = Command.Split(' ');
            return Regex.IsMatch(Command, Pattern) && commandArray.Length == 3 && CheckNumerics(commandArray) 
                      && CheckLocation(commandArray) && CheckDirection(commandArray);
        }

        private bool CheckNumerics(string[] directions)
        {
            for (int i = 0; i < 2; i++)
            {
                if (!Helper.IsNumeric(directions[i]))
                    return false;
            }
            return true;
        }

        private bool CheckDirection(string[] directions)
        {
            List<string> allDirections = new List<string> { "N", "E", "W", "S" };
            return allDirections.Contains(directions[2]);
        }

        private bool CheckLocation(string[] directions)
        {
            Location location = new Location(int.Parse(directions[0]), int.Parse(directions[1]));
            return Area.IsInside(location);
        }
    }
}
