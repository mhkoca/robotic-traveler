using System;
using System.Collections.Generic;

namespace Traveler
{
    public class Robot
    {
        #region Fields
        private Dictionary<Direction, ITurn> _mapDirection;
        #endregion

        #region Properties

        public Location CurrentLocation { get; set; }
        public Direction CurrentDirection { get; set; }

        #endregion,

        #region Initialize

        public Robot(string[] location)
        {
            CurrentLocation = new Location(int.Parse(location[0]), int.Parse(location[1]));
            CurrentDirection = (Direction)Enum.Parse(typeof(Direction), location[2]);

            InitializeMapping();
        }

        private void InitializeMapping()
        {
            _mapDirection = new Dictionary<Direction, ITurn>();
            _mapDirection.Add(Direction.E, new East());
            _mapDirection.Add(Direction.W, new West());
            _mapDirection.Add(Direction.N, new North());
            _mapDirection.Add(Direction.S, new South());
        }

        #endregion

        #region Public Methods

        public void Turn(TurningDirection turningDirection)
        {
            ITurn turning = _mapDirection[CurrentDirection];

            if (turningDirection == TurningDirection.R)
                CurrentDirection = turning.TurnRight();
            if (turningDirection == TurningDirection.L)
                CurrentDirection = turning.TurnLeft();
        }

        public void Move()
        {
            ITurn turning = _mapDirection[CurrentDirection];
            CurrentLocation = turning.Move(CurrentLocation);
        }

        #endregion
    }  
}
