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

        public override event PropertyChangedEventHandler? PropertyChanged;

        private readonly Timer timer;

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
                OnPropertyChanged();
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
                OnPropertyChanged();
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

        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public BallDataAPI(float x, float y, float xVelocity, float yVelocity, float radius, bool movementEnabled)
        {
            X = x;
            Y = y;
            XVelocity = xVelocity;
            YVelocity = yVelocity;
            Radius = radius;

            if (movementEnabled)
            {
                timer = new(Move, null, TimeSpan.Zero, TimeSpan.FromMilliseconds(20));
            }
            else
            {
                timer = new(Move, null, Timeout.Infinite, Timeout.Infinite);
            }
        }

        private void Move(object? state)
        {
            if (state != null)
            {
                throw new ArgumentOutOfRangeException(nameof(state));
            }

            X += XVelocity;
            Y += YVelocity;
        }

        public override void Dispose()
        {
            timer.Dispose();
        }
    }
}
