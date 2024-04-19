using System.Numerics;

namespace Data
{
    internal class Ball : BallAPI
    {
        private Vector2 coordinates;
        private Vector2 velocity;
        private readonly float radius;
        private Vector2 maxCoordinates = new(300, 300);

        public Ball(float x, float y, float xVelocity, float yVelocity, float radius)
        {
            coordinates = new Vector2(x, y);
            velocity = new Vector2(xVelocity, yVelocity);
            this.radius = radius;
        }

        public override void Move(float xDifference, float yDifference)
        {
            float nextX = coordinates.X + radius + velocity.X;
            float nextY = coordinates.Y + radius + velocity.Y;

            bool nextXStepInBounds = nextX >= 0 && nextX <= maxCoordinates.X;
            bool nextYStepInBounds = nextY >= 0 && nextY <= maxCoordinates.Y;

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

        public override void SetMaxCoordinates(float x, float y)
        {
            maxCoordinates.X = x;
            maxCoordinates.Y = y;
        }
        #endregion getters & setters
    }
}
