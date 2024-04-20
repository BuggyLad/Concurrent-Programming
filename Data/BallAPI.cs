using System.Numerics;

namespace Data
{
    public abstract class BallAPI
    {
        public static readonly Vector2 maxCoordinates = new(300, 300);

        public static BallAPI GetBall(float x, float y, float xVelocity, float yVelocity, float radius)
        {
            return new Ball(x, y, xVelocity, yVelocity, radius);
        }

        public abstract void Move();

        #region getters & setters
        public abstract Vector2 GetCoordinates();

        public abstract Vector2 GetVelocity();

        public abstract float GetRadius();

        public abstract Vector2 GetMaxCoordinates();
        #endregion getters & setters
    }
}
