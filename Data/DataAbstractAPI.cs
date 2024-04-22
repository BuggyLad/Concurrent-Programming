namespace Data
{
    public abstract class DataAbstractAPI
    {
        public static readonly float maxXCoordinate = 300;
        public static readonly float maxYCoordinate = 300;

        public static DataAbstractAPI CreateAPI()
        {
            return new DataAPI();
        }

        public abstract BallDataAbstractAPI CreateBall(float x, float y, float xVelocity, float yVelocity, float radius,
            bool movementEnabled);
    }
}
