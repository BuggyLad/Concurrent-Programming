using System.ComponentModel;

namespace Logic
{
    public abstract class BallLogicAbstractAPI
    {
        public abstract float X { get; set; }
        public abstract float Y { get; set; }
        public abstract float XVelocity { get; set; }
        public abstract float YVelocity { get; set; }
        public abstract float Radius { get; }

        public abstract event PropertyChangedEventHandler? PositionChanged;

        public static BallLogicAbstractAPI CreateAPI(Data.BallDataAbstractAPI ball)
        {
            return new BallLogicAPI(ball);
        }
    }
}
