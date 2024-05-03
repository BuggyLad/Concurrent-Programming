using Data;
using System.ComponentModel;

namespace Logic
{
    internal class BallLogicAPI : BallLogicAbstractAPI
    {
        private readonly BallDataAbstractAPI ball;

        public override event PropertyChangedEventHandler? PropertyChanged;

        public override float Left
        {
            get => ball.X - Radius;
            set => ball.X = value;
        }

        public override float Top
        {
            get => ball.Y - Radius;
            set => ball.Y = value;
        }

        public override float Radius
        {
            get => ball.Radius;
        }

        public override float Diameter
        {
            get => Radius * 2;
        }

        public BallLogicAPI(BallDataAbstractAPI ball)
        {
            this.ball = ball;
            ball.PropertyChanged += Update;
        }

        private void Update(object? source, PropertyChangedEventArgs eventArgs)
        {
            if (eventArgs.PropertyName == nameof(ball.X))
            {
                OnPropertyChanged(nameof(Left));
            }
            else if (eventArgs.PropertyName == nameof(ball.Y))
            {
                OnPropertyChanged(nameof(Top));
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public override void Dispose()
        {
            ball.Dispose();
        }
    }
}
