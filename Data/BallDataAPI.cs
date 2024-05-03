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

        private readonly Task timer;

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

            timer = Task.Run(async () =>
            {
                while (movementEnabled)
                {
                    await Move();
                }
            });
        }

        private async Task Move()
        {
            X += XVelocity;
            Y += YVelocity;

            await Task.Delay(20);
        }

        public override void Dispose()
        {
            timer.Dispose();
        }
    }
}
