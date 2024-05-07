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

                bool nextXStepInLeftBounds = nextX - ball.Radius >= 0;
                bool nextYStepInLeftBounds = nextY - ball.Radius >= 0;
                bool nextXStepInRightBounds =nextX + ball.Radius <= DataAbstractAPI.maxXCoordinate;
                bool nextYStepInRightBounds =nextY + ball.Radius <= DataAbstractAPI.maxYCoordinate;

                if (!nextXStepInLeftBounds)
                {
                    ball.X = ball.Radius;
                    ball.XVelocity = -ball.XVelocity;
                }

                if (!nextYStepInLeftBounds)
                {
                    ball.Y = ball.Radius;
                    ball.YVelocity = -ball.YVelocity;
                }

                if (!nextXStepInRightBounds)
                {
                    ball.X = DataAbstractAPI.maxXCoordinate - ball.Radius;
                    ball.XVelocity = -ball.XVelocity;
                }
                
                if (!nextYStepInRightBounds)
                {
                    ball.Y = DataAbstractAPI.maxYCoordinate - ball.Radius;
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
