using System.Numerics;

namespace Data
{
    internal class Ball : BallAPI
    {
        private Vector2 coordinates;
        private Vector2 velocity;
        private readonly float radius;

        public Ball(float x, float y, float xVelocity, float yVelocity, float radius)
        {
            coordinates = new Vector2(x, y);
            velocity = new Vector2(xVelocity, yVelocity);
            this.radius = radius;
        }

        public override void Move()
        {
            float nextX = coordinates.X + velocity.X;
            float nextY = coordinates.Y + velocity.Y;

            bool nextXStepInBounds = nextX - radius >= 0 && nextX + radius <= maxCoordinates.X;
            bool nextYStepInBounds = nextY - radius >= 0 && nextY + radius <= maxCoordinates.Y;

            if (!nextXStepInBounds)
            {
                velocity.X = -velocity.X;
            }

            if (!nextYStepInBounds)
            {
                velocity.Y = -velocity.Y;
            }

            coordinates.X += velocity.X;
            coordinates.Y += velocity.Y;
        }

        #region getters & setters
        public override Vector2 GetCoordinates()
        {
            return coordinates;
        }

        public override Vector2 GetVelocity()
        {
            return velocity;
        }

        public override float GetRadius()
        {
            return radius;
        }

        public override Vector2 GetMaxCoordinates()
        {
            return maxCoordinates;
        }
        #endregion getters & setters
    }
}
