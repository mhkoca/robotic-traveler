using System;
using System.Text.RegularExpressions;

namespace Traveler
{
    public class CornerCommand : ICommand
    {
        public CornerCommand(string corner)
        {
            this.Command = corner;
        }

        public string Pattern { get { return "([0-9][ ][0-9])"; } }

        public string Command { get; set; }

        public bool Validate()
        {
            return Regex.IsMatch(Command, Pattern) && Command.Split(' ').Length == 2 && Helper.IsNumeric(Command.Replace(" ", string.Empty));
        }
    }
}
