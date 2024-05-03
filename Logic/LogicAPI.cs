using Data;
using System.ComponentModel;

namespace Logic
{
    internal class LogicAPI : LogicAbstractAPI
    {
        private readonly List<BallDataAbstractAPI> balls = [];

        public override void CreateBall(float radius, bool movementEnabled)
        {
            Random random = new();
            float x = ((float)random.NextDouble() * (DataAbstractAPI.maxXCoordinate - radius)) + radius;
            float y = ((float)random.NextDouble() * (DataAbstractAPI.maxYCoordinate - radius)) + radius;

            float xVelocity = ((float)random.NextDouble() * 3 + 1) * (2 * random.Next(0, 2) - 1);
            float yVelocity = ((float)random.NextDouble() * 3 + 1) * (2 * random.Next(0, 2) - 1);

            DataAbstractAPI api = DataAbstractAPI.CreateAPI();
            BallDataAbstractAPI ball = api.CreateBall(x, y, xVelocity, yVelocity, radius, movementEnabled);

            balls.Add(ball);
            ball.PropertyChanged += CollisionCheck;
        }

        public override void RemoveBall()
        {
            if (balls.Count > 0)
            {
                Random random = new();

                int randomInt = random.Next(balls.Count);

                balls[randomInt].Dispose();
                balls.RemoveAt(randomInt);
            }
        }

        private void CollisionCheck(object? sender, PropertyChangedEventArgs eventArgs)
        {
            if (sender != null)
            {
                BallDataAbstractAPI ball = (BallDataAbstractAPI)sender;

                float nextX = ball.X + ball.XVelocity;
                float nextY = ball.Y + ball.YVelocity;

                bool nextXStepInBounds = nextX - ball.Radius >= 0 && nextX + ball.Radius <= DataAbstractAPI.maxXCoordinate;
                bool nextYStepInBounds = nextY - ball.Radius >= 0 && nextY + ball.Radius <= DataAbstractAPI.maxYCoordinate;

                if (!nextXStepInBounds)
                {
                    ball.XVelocity = -ball.XVelocity;
                }

                if (!nextYStepInBounds)
                {
                    ball.YVelocity = -ball.YVelocity;
                }
            }
        }

        public override List<BallLogicAbstractAPI> GetBalls()
        {
            List<BallLogicAbstractAPI> balls = [];
            foreach (BallDataAbstractAPI ball in this.balls)
            {
                balls.Add(BallLogicAbstractAPI.CreateAPI(ball));
            }

            return balls;
        }
    }
}
