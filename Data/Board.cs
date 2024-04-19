using System.Numerics;

namespace Data
{
    internal class Board : BoardAPI
    {
        private Vector2 dimensions;
        private readonly List<BallAPI> balls = [];

        public Board(float x, float y)
        {
            dimensions = new Vector2(x, y);
        }

        public Vector2 GetDimensions()
        {
            return dimensions;
        }

        public void SetDimensions(float x, float y)
        {
            dimensions.X = x;
            dimensions.Y = y;
        }

        public override BallAPI CreateBall(float x, float y, float xVelocity, float yVelocity, float radius)
        {
            BallAPI newBall = BallAPI.GetBall(x, y, xVelocity, yVelocity, radius);
            balls.Add(newBall);

            return newBall;
        }

        public override void RemoveBall()
        {
            if (balls.Count > 0)
            {
                Random random = new();

                balls.RemoveAt(random.Next(balls.Count));
            }
        }
    }
}
