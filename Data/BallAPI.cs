using System.Numerics;

namespace Data
{
    public abstract class BallAPI
    {
        public static BallAPI GetBall(float x, float y, float xVelocity, float yVelocity, float radius)
        {
            return new Ball(x, y, xVelocity, yVelocity, radius);
        }

        public abstract void Move(float xDifference, float yDifference);

        #region getters & setters
        public abstract Vector2 GetCoordinates();

        public abstract Vector2 GetVelocity();

        public abstract float GetRadius();

        public abstract Vector2 GetMaxCoordinates();

        public abstract void SetMaxCoordinates(float x, float y);
        #endregion getters & setters
    }
}
