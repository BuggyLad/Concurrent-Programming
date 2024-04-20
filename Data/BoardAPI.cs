namespace Data
{
    public abstract class BoardAPI
    {
        public static BoardAPI GetBoard()
        {
            return new Board();
        }

        public abstract BallAPI CreateBall(float x, float y, float xVelocity, float yVelocity, float radius);

        public abstract void RemoveBall();

        public abstract List<BallAPI> GetBalls();
    }
}
