using System;

namespace Traveler
{
    public class Program
    {
        #region Main
        static void Main(string[] args)
        {
            try
            {
                SetCornerCoordinats();
                SetRobotDatas();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occured. Please enter again." + Environment.NewLine + 
                                    "Error detail:" + Environment.NewLine + ex);
                SetCornerCoordinats();
                SetRobotDatas();
            }

            Console.Read();
        }

        private static void SetRobotDatas()
        {
            string infoLocation = "Please enter first robot's location and direction(ex 1 2 N):";
            string infoRoute = "Please enter first robot's moving commands(it can only include L,R and M letters):";

            string location = TakeLocation(infoLocation);
            string routeCommand = TakeRoute(infoRoute);

            Robot robot1 = new Robot(location.Split(' '));
            Move(robot1, routeCommand);

            infoLocation = "Please enter second robot's location and direction(ex 1 1 N):";
            infoRoute = "Please enter second robot's moving commands(it can only include L,R and M letters):";

            location = TakeLocation(infoLocation);
            routeCommand = TakeRoute(infoRoute);

            Robot robot2 = new Robot(location.Split(' '));
            Move(robot2, routeCommand);

            Console.WriteLine(robot1.CurrentLocation + " " + robot1.CurrentDirection);
            Console.WriteLine(robot2.CurrentLocation + " " + robot2.CurrentDirection);
        }
        #endregion

        #region Private Methods
        private static void SetCornerCoordinats()
        {
            string corner = TakeCorner();

            SetArea(corner.Split(' '));
        }

        public static void Move(Robot robot, string routeCommand)
        {
            var routeArray = routeCommand.ToCharArray();

            foreach (var turn in routeArray)
            {
                if (turn == 'L' || turn == 'R')
                    robot.Turn((TurningDirection)Enum.Parse(typeof(TurningDirection), turn.ToString()));
                else if (turn == 'M')
                    robot.Move();  
            }

        }

        private static void SetArea(string[] location)
        {
            Location endLocation = new Location(int.Parse(location[0]), int.Parse(location[1]));
            Area.EndLocation = endLocation;
        }

        private static string TakeCorner()
        {
            string info = "Enter the corner coordinats(ex. 3 7):";
            string warning = "You entered wrong the coordinat info";

            Console.Write(info);
            string corner = Console.ReadLine();

            corner = EvaluateCommand(corner, info, warning, CommandType.Corner);
            return corner;
        }

        private static string TakeLocation(string info)
        {
            string warning = "You entered wrong the location and direction commands";
            Console.Write(info);
            string location = Console.ReadLine();

            location = EvaluateCommand(location, info, warning, CommandType.Location);
            return location;
        }

        private static string TakeRoute(string info)
        {
            string warning = "You entered wrong the moving commands";
            Console.Write(info);
            string commands = Console.ReadLine();

            commands = EvaluateCommand(commands,info,warning,CommandType.Route);
            return commands;
        }

        private static string EvaluateCommand(string commandText, string info, string warning, CommandType commandType)
        {
            var command = CommandFactory.GetCommand(commandType, commandText);

            if (command.Validate())
                return commandText;
            else
            {
                Console.WriteLine(warning);
                Console.Write(info);
                string newCorner = Console.ReadLine();
                return EvaluateCommand(newCorner, info, warning, commandType);
            }
        }
        #endregion
    }
}
