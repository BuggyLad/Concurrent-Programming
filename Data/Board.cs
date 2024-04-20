using System.Collections.Immutable;
using System.Collections.ObjectModel;
using System.Numerics;

namespace Data
{
    internal class Board : BoardAPI
    {
        private readonly List<BallAPI> balls = [];

        public static Vector2 GetDimensions()
        {
            return BallAPI.maxCoordinates;
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

        public override List<BallAPI> GetBalls()
        {
            ReadOnlyCollection<BallAPI> readOnlyBalls = balls.AsReadOnly();

            return readOnlyBalls.ToList();
        }
    }
}
