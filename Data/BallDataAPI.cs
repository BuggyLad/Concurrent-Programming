using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Data
{
    internal class BallDataAPI : BallDataAbstractAPI
    {
        private float x;
        private float y;
        private float xVelocity;
        private float yVelocity;
        private float radius;

        public override event EventHandler? PositionChanged;

        public override float X
        {
            get => x;
            set
            {
                if (x == value)
                {
                    return;
                }
                x = value;
                OnPositionChanged();
            }
        }

        public override float Y
        {
            get => y;
            set
            {
                if (y == value)
                {
                    return;
                }
                y = value;
                OnPositionChanged();
            }
        }

        public override float XVelocity
        {
            get => xVelocity;
            set => xVelocity = value;
        }

        public override float YVelocity
        {
            get => yVelocity;
            set => yVelocity = value;
        }

        public override float Radius
        {
            get => radius;
            set => radius = value;
        }

        private void OnPositionChanged()
        {
            PositionChanged?.Invoke(this, new EventArgs());
        }

        public BallDataAPI(float x, float y, float xVelocity, float yVelocity, float radius, bool movementEnabled)
        {
            X = x;
            Y = y;
            XVelocity = xVelocity;
            YVelocity = yVelocity;
            Radius = radius;

            while(movementEnabled)
            {
                Task.Run(Move);
            }
        }

        private async void Move()
        {
            X += XVelocity;
            Y += YVelocity;

            await Task.Delay(100);
        }
    }
}
