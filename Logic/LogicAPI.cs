using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Reactive.Linq;

namespace Logic
{
    internal class LogicAPI : LogicAbstractAPI
    {
        private readonly List<BallLogicAbstractAPI> balls = [];

        public override void CreateBall(float radius, bool movementEnabled)
        {
            Random random = new Random();
            float x = ((float)random.NextDouble() * (Data.DataAbstractAPI.maxXCoordinate - radius)) + radius;
            float y = ((float)random.NextDouble() * (Data.DataAbstractAPI.maxYCoordinate - radius)) + radius;

            float xVelocity = ((float)random.NextDouble() * 5 + 1) * (2 * random.Next(0, 1) - 1);
            float yVelocity = ((float)random.NextDouble() * 5 + 1) * (2 * random.Next(0, 1) - 1);

            Data.DataAbstractAPI api = Data.DataAbstractAPI.CreateAPI();
            Data.BallDataAbstractAPI ball = api.CreateBall(x, y, xVelocity, yVelocity, radius, movementEnabled);
            BallLogicAbstractAPI ballLogic = new BallLogicAPI(ball);

            balls.Add(ballLogic);
            ballLogic.PositionChanged += CollisionCheck;
        }

        public override void RemoveBall()
        {
            if (balls.Count > 0)
            {
                Random random = new();

                balls.RemoveAt(random.Next(balls.Count));
            }
        }

        private void CollisionCheck(object sender, PropertyChangedEventArgs eventArgs)
        {
            BallLogicAbstractAPI ball = (BallLogicAbstractAPI)sender;

            float nextX = ball.X + ball.XVelocity;
            float nextY = ball.Y + ball.YVelocity;

            bool nextXStepInBounds = nextX - ball.Radius >= 0 && nextX + ball.Radius <= Data.DataAbstractAPI.maxXCoordinate;
            bool nextYStepInBounds = nextY - ball.Radius >= 0 && nextY + ball.Radius <= Data.DataAbstractAPI.maxYCoordinate;

            if (!nextXStepInBounds)
            {
                ball.XVelocity = -ball.XVelocity;
            }

            if (!nextYStepInBounds)
            {
                ball.YVelocity = -ball.YVelocity;
            }
        }

        public override List<BallLogicAbstractAPI> GetBalls()
        {
            ReadOnlyCollection<BallLogicAbstractAPI> readOnlyBalls = balls.AsReadOnly();

            return readOnlyBalls.ToList();
        }
    }
}
