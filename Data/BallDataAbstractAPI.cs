using System.ComponentModel;

namespace Data
{
    public abstract class BallDataAbstractAPI : INotifyPropertyChanged, IDisposable
    {
        public abstract float X { get; set; }
        public abstract float Y { get; set; }
        public abstract float XVelocity { get; set; }
        public abstract float YVelocity { get; set; }
        public abstract float Radius { get; set; }

        public abstract event PropertyChangedEventHandler? PropertyChanged;

        public static BallDataAbstractAPI CreateAPI(float x, float y, float xVelocity, float yVelocity, float radius,
            bool movementEnabled)
        {
            return new BallDataAPI(x, y, xVelocity, yVelocity, radius, movementEnabled);
        }

        public abstract void Dispose();
    }
}
