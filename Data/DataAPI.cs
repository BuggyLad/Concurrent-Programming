namespace Data
{
    internal class DataAPI : DataAbstractAPI
    {
        public override BallDataAbstractAPI CreateBall(float x, float y, float xVelocity, float yVelocity, float radius,
            bool movementEnabled)
        {
            return new BallDataAPI(x, y, xVelocity, yVelocity, radius, movementEnabled);
        }
    }
}
