namespace Data
{
    public abstract class BoardAPI
    {
        public static BoardAPI CreateBoard(float x, float y)
        {
            return new Board(x, y);
        }

        public abstract BallAPI CreateBall(float x, float y, float xVelocity, float yVelocity, float radius);

        public abstract void RemoveBall();
    }
}
