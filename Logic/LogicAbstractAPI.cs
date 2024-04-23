namespace Logic
{
    public abstract class LogicAbstractAPI
    {
        public static readonly float maxXCoordinate = Data.DataAbstractAPI.maxXCoordinate;
        public static readonly float maxYCoordinate = Data.DataAbstractAPI.maxYCoordinate;

        public static LogicAbstractAPI CreateAPI()
        {
            return new LogicAPI();
        }

        public abstract void CreateBall(float radius, bool movementEnabled);

        public abstract List<BallLogicAbstractAPI> GetBalls();

        public abstract void RemoveBall();
    }
}
