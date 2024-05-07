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

        public abstract void Dispose();
    }
}
