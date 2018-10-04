namespace Traveler
{
    public interface ICommand
    {
        string Pattern { get; }
        string Command { get; set; }

        bool Validate();
    }
}
