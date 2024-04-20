using Data;

namespace Logic
{
    internal class BoardLogic : BoardLogicAPI
    {
        private readonly List<BallAPI> balls = [];

        public override void CreateBall(float radius)
        {
            Random random = new Random();
            float x = ((float)random.NextDouble() * (BallAPI.maxCoordinates.X - radius)) + radius;
            float y = ((float)random.NextDouble() * (BallAPI.maxCoordinates.Y - radius)) + radius;

            float xVelocity = ((float)random.NextDouble() * 5 + 1) * (2 * random.Next(0, 1) - 1);
            float yVelocity = ((float)random.NextDouble() * 5 + 1) * (2 * random.Next(0, 1) - 1);

            balls.Add(BallAPI.GetBall(x, y, xVelocity, yVelocity, radius));
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
