using System.ComponentModel;

namespace Logic
{
    internal class BallLogicAPI : BallLogicAbstractAPI
    {
        private readonly Data.BallDataAbstractAPI ball;

        public override event PropertyChangedEventHandler? PositionChanged;

        public override float X
        {
            get => ball.X;
            set => ball.X = value;
        }

        public override float Y
        {
            get => ball.Y;
            set => ball.Y = value;
        }

        public override float Radius
        {
            get => ball.Radius;
        }

        public override float XVelocity
        {
            get => ball.XVelocity;
            set => ball.XVelocity = value;
        }
        
        public override float YVelocity
        {
            get => ball.YVelocity;
            set => ball.YVelocity = value;
        }

        public BallLogicAPI(Data.BallDataAbstractAPI ball)
        {
            this.ball = ball;
            PositionChanged += Update;
        }

        private void Update(object? source, PropertyChangedEventArgs eventArgs)
        {
            if (eventArgs.PropertyName == nameof(ball.X))
            {
                RaisePropertyChanged(nameof(ball.X));
            }
            else if (eventArgs.PropertyName == nameof(ball.Y))
            {
                RaisePropertyChanged(nameof(ball.X));
            }
        }

        private void RaisePropertyChanged(string propertyName)
        {
            PositionChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
